using ModpackManager.Utils;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

///////////////////////////////////// Add downloading bar at the bottom of the screen ////////////////////////////////////////////


namespace brenman60_s_Modpack_Manager.Scripts
{
    public class ModManager
    {
        Downloader downloader = new Downloader();

        public static readonly string modStashPath = Path.Combine(Directory.GetCurrentDirectory(), "mods");

        // Dictionary that contains the currently selected loader, modpack, and mod settings that will be used later
        public static Dictionary<string, string> saveData = new Dictionary<string, string>()
        {
            ["settings"] = SettingsManager.GetSettingsText(),
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
                ["1.20.1"] = new Dictionary<string, string>()
                {
                    ["selectedModpack"] = "None",
                    ["modSettings"] = "[]",
                },
            },
        };

        public async void ReloadMods()
        {
            ClearMods();
            Process? visual = StartLoadingVisual();
            Task<bool> placeModpack = PlaceModpackMods();
            Task<bool> placeSettingMods = PlaceSettingMods();

            await placeModpack;
            await placeSettingMods;

            if (visual != null) 
                visual.Kill();
        }

        private Process? StartLoadingVisual()
        {
            string updaterPath = Path.Combine(Directory.GetCurrentDirectory(), "brenman60's Modpack Manager Loader.exe");
            ProcessStartInfo updaterStartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = false,
                Arguments = "onlyVisual",
                FileName = updaterPath,
                WindowStyle = ProcessWindowStyle.Normal,
            };

            return Process.Start(updaterStartInfo);
        }

        // Delete or move all the current mods in the mods folder
        private void ClearMods()
        {
            // Loop through the currently enabled modpacks' mods and delete it (as it still exists in the mod stash)
            // Then loop through the enabled mod settings' mods and delete it (as it still exists in the mod stash)
            string selectedModpack = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["selectedModpack"];
            string selectedMods = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["modSettings"];

            if (selectedModpack != "None")
            {
                foreach (Dictionary<string, object> modpack in ModpackManager.modpacks)
                {
                    foreach (string mod in modpack["mods"] as List<string>)
                    {
                        if (File.Exists(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar")))
                            File.Delete(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                    }
                }
            }

            List<string> includedMods = JsonConvert.DeserializeObject<List<string>>(selectedMods);
            foreach (string mod in includedMods)
            {
                if (File.Exists(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar")))
                    File.Delete(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
            }
        }

        // Copy the mods from the currently selected modpack into the mods folder
        private async Task<bool> PlaceModpackMods()
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
                        File.Copy(Path.Combine(modStashPath, mod + ".jar"), Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                    }
                    else
                    {
                        string downloadLink = Mods.directDownloads[saveData["selectedLoader"]][saveData["selectedVersion"]][mod];
                        string? downloadedPath = await downloader.DownloadFile(downloadLink, ".jar");
                        if (downloadedPath == null) continue;

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
        private async Task<bool> PlaceSettingMods()
        {
            string selectedMods = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["modSettings"];
            List<string>? includedMods = JsonConvert.DeserializeObject<List<string>>(selectedMods);
            if (includedMods == null) return false;

            foreach (string mod in includedMods)
            {
                if (File.Exists(Path.Combine(modStashPath, mod + ".jar")))
                {
                    File.Copy(Path.Combine(modStashPath, mod + ".jar"), Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                }
                else
                {
                    string downloadLink = Mods.directDownloads[saveData["selectedLoader"]][saveData["selectedVersion"]][mod];
                    string? downloadedPath = await downloader.DownloadFile(downloadLink, ".jar");
                    if (downloadedPath == null) continue;

                    File.Copy(downloadedPath, Path.Combine(modStashPath, mod + ".jar"));
                    File.Copy(downloadedPath, Path.Combine(SettingsManager.settings["modsPath"], mod));
                    File.Delete(downloadedPath);
                }
            }

            return true;
        }
    }
}
