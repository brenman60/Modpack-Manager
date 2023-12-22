using ModpackManager.Utils;
using Newtonsoft.Json;
using System.IO;

namespace brenman60_s_Modpack_Manager.Scripts
{
    public class ModManager
    {
        Downloader downloader = new Downloader();

        public static readonly string modStashPath = Path.Combine(Directory.GetCurrentDirectory(), "mods");

        private readonly string saveDataLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "brenman60's Mod Manager");
        private readonly string saveDataFile = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "brenman60's Mod Manager"), "settings.bmm");

        // Dictionary that contains the currently selected loader, modpack, and mod settings that will be used later
        public static Dictionary<string, string> saveData = new Dictionary<string, string>()
        {
            ["settings"] = SettingsManager.GetSettingsText(),
            ["modSettings"] = JsonConvert.SerializeObject(modSettings),
            ["selectedLoader"] = "Forge",
            ["selectedVersion"] = "1.19.2",
            ["userCreatedModpacks"] = "{}",
        };

        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> modSettings = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>()
        {
            ["Forge"] = new Dictionary<string, Dictionary<string, string>>()
            {
                ["1.19.2"] = new Dictionary<string, string>()
                {
                    ["selectedModpack"] = "None",
                    ["modSettings"] = "[]",
                },
                ["1.20.1"] = new Dictionary<string, string>()
                {
                    ["selectedModpack"] = "None",
                    ["modSettings"] = "[]",
                },
            },
            ["Fabric"] = new Dictionary<string, Dictionary<string, string>>()
            {
                ["1.19.2"] = new Dictionary<string, string>()
                {
                    ["selectedModpack"] = "None",
                    ["modSettings"] = "[]",
                },
                ["1.20.1"] = new Dictionary<string, string>()
                {
                    ["selectedModpack"] = "None",
                    ["modSettings"] = "[]",
                },
            },
        };

        public async void ReloadMods()
        {
            MainWindow.workingJob = true;
            ((MainWindow)App.Current.MainWindow).ToggleProgressBar(true);
            ClearMods();
            Task<bool> placeModpack = PlaceModpackMods();
            Task<bool> placeSettingMods = PlaceSettingMods();

            await placeModpack;
            await placeSettingMods;

            ((MainWindow)App.Current.MainWindow).ToggleProgressBar(false);
            MainWindow.workingJob = false;
        }

        // Delete or move all the current mods in the mods folder
        public void ClearMods()
        {
            // Loop through the currently enabled modpacks' mods and delete it (as it still exists in the mod stash)
            // Then loop through the enabled mod settings' mods and delete it (as it still exists in the mod stash)
            string selectedModpack = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["selectedModpack"];
            string selectedMods = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["modSettings"];

            ClearModpackMods(selectedModpack);
            ClearModSettings(selectedMods);
        }

        public void ClearModpackMods(string selectedModpack)
        {
            if (selectedModpack != "None")
            {
                foreach (Dictionary<string, object> modpack in ModpackManager.modpacks)
                {
                    foreach (string mod in modpack["mods"] as List<string>)
                    {
                        ((MainWindow)App.Current.MainWindow).ChangeProgressText("Checking " + mod + ".jar...");
                        if (File.Exists(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar")))
                            File.Delete(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                    }
                }
            }
        }

        public void ClearModSettings(string selectedMods)
        {
            List<string> includedMods = JsonConvert.DeserializeObject<List<string>>(selectedMods);
            foreach (string mod in includedMods)
            {
                ((MainWindow)App.Current.MainWindow).ChangeProgressText("Checking " + mod + ".jar...");
                if (File.Exists(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar")))
                    File.Delete(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
            }
        }

        // Copy the mods from the currently selected modpack into the mods folder
        public async Task<bool> PlaceModpackMods()
        {
            string selectedModpack_ = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["selectedModpack"];
            if (selectedModpack_ != "None")
            {
                Dictionary<string, object>? selectedModpack = null;
                foreach (Dictionary<string, object> modpack in ModpackManager.modpacks)
                    if (modpack["id"].ToString() == selectedModpack_)
                        selectedModpack = modpack;

                if (selectedModpack == null) return false;

                List<string>? mods = selectedModpack["mods"] as List<string>;
                if (mods == null) return false;

                foreach (string mod in mods)
                {
                    if (File.Exists(Path.Combine(modStashPath, mod + ".jar")))
                    {
                        ((MainWindow)App.Current.MainWindow).ChangeProgressText("Copying " + mod + ".jar...");
                        File.Copy(Path.Combine(modStashPath, mod + ".jar"), Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                    }
                    else
                    {
                        ((MainWindow)App.Current.MainWindow).ChangeProgressText("Downloading " + mod + ".jar...");
                        string downloadLink = Mods.directDownloads[saveData["selectedLoader"]][saveData["selectedVersion"]][mod];
                        string? downloadedPath = await downloader.DownloadFile(downloadLink, ".jar");
                        if (downloadedPath == null) continue;

                        ((MainWindow)App.Current.MainWindow).ChangeProgressText("Configuring " + mod + ".jar...");
                        File.Copy(downloadedPath, Path.Combine(modStashPath, mod + ".jar"));
                        File.Copy(downloadedPath, Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                        File.Delete(downloadedPath);
                    }
                }

                return true;
            }
            else
                return true;
        }

        // Copy the mods enabled in the settings into the mods folder
        public async Task<bool> PlaceSettingMods()
        {
            string selectedMods = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["modSettings"];
            List<string>? includedMods = JsonConvert.DeserializeObject<List<string>>(selectedMods);
            if (includedMods == null) return false;

            foreach (string mod in includedMods)
            {
                if (File.Exists(Path.Combine(modStashPath, mod + ".jar")))
                {
                    ((MainWindow)App.Current.MainWindow).ChangeProgressText("Copying " + mod + ".jar...");
                    File.Copy(Path.Combine(modStashPath, mod + ".jar"), Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                }
                else
                {
                    ((MainWindow)App.Current.MainWindow).ChangeProgressText("Downloading " + mod + ".jar...");
                    string downloadLink = Mods.directDownloads[saveData["selectedLoader"]][saveData["selectedVersion"]][mod];
                    string? downloadedPath = await downloader.DownloadFile(downloadLink, ".jar");
                    if (downloadedPath == null) continue;

                    ((MainWindow)App.Current.MainWindow).ChangeProgressText("Configuring " + mod + ".jar...");
                    if (!File.Exists(Path.Combine(modStashPath, mod + ".jar")))
                        File.Copy(downloadedPath, Path.Combine(modStashPath, mod + ".jar"));

                    if (!File.Exists(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar")))
                        File.Copy(downloadedPath, Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));

                    File.Delete(downloadedPath);

                }
            }

            return true;
        }

        public async void SaveData()
        {
            FileManager fileManager = new();
            saveData["modSettings"] = JsonConvert.SerializeObject(modSettings);
            string text = JsonConvert.SerializeObject(saveData);

            if (!Directory.Exists(saveDataLocation)) Directory.CreateDirectory(saveDataLocation);

            await fileManager.WriteToFile(saveDataFile, text);
        }
        
        public async void LoadData()
        {
            if (!File.Exists(saveDataFile)) { SaveData(); return; }

            FileManager fileManager = new();
            string saveDataRaw = fileManager.ReadFile(saveDataFile);
            saveData = JsonConvert.DeserializeObject<Dictionary<string, string>>(saveDataRaw);
            SettingsManager.settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(saveData["settings"]);
            modSettings = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(saveData["modSettings"]);
        }
    }
}
