using ModpackManager.Utils;
using Newtonsoft.Json;
using System.IO;

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
            ["selectedVersion"] = "1.20.1",
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

        public void ReloadMods()
        {
            ClearMods();
            PlaceModpackMods();
            PlaceSettingMods();
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
                string modpackJsonPath = Path.Combine("../Modpacks/", selectedModpack);
                using (StreamReader reader = new StreamReader(modpackJsonPath))
                {
                    string text = reader.ReadToEnd();
                    Dictionary<string, object>? modpackInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
                    if (modpackInfo == null) return;

                    List<string> mods = JsonConvert.DeserializeObject<List<string>>(modpackInfo["mods"].ToString());
                    if (mods == null) return;

                    foreach (string mod in mods)
                    {
                        if (File.Exists(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar")))
                            File.Delete(Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                    }
                }
            }

            List<string> includedMods = JsonConvert.DeserializeObject<List<string>>(selectedMods);
            foreach (string mod in includedMods)
            {
                if (File.Exists(Path.Combine(SettingsManager.settings["modsPath"], mod)))
                    File.Delete(Path.Combine(SettingsManager.settings["modsPath"], mod));
            }
        }

        // Copy the mods from the currently selected modpack into the mods folder
        private async void PlaceModpackMods()
        {
            string selectedModpack = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["selectedModpack"];
            if (selectedModpack != "None")
            {
                string modpackJsonPath = Path.Combine("../Modpacks/", selectedModpack);
                using (StreamReader reader = new StreamReader(modpackJsonPath))
                {
                    string text = reader.ReadToEnd();
                    Dictionary<string, object>? modpackInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
                    if (modpackInfo == null) return;

                    List<string> mods = JsonConvert.DeserializeObject<List<string>>(modpackInfo["mods"].ToString());
                    foreach (string mod in mods)
                    {
                        if (File.Exists(Path.Combine(modStashPath, mod)))
                            File.Copy(Path.Combine(modStashPath, mod), Path.Combine(SettingsManager.settings["modsPath"], mod));
                        else
                        {
                            string modsJson = Path.Combine("../Mods/" + mod + ".json");
                            using (StreamReader modInfo = new StreamReader(modsJson))
                            {
                                string modInfoText = modInfo.ReadToEnd();
                                Dictionary<string, object> modInfoDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(modInfoText);
                                if (modInfoDict == null) continue;

                                string? downloadedPath = await downloader.DownloadFile(modInfoDict["directLink"].ToString(), ".jar");
                                if (downloadedPath == null) continue;

                                File.Copy(downloadedPath, Path.Combine(modStashPath, mod + ".jar"));
                                File.Copy(downloadedPath, Path.Combine(SettingsManager.settings["modsPath"], mod + ".jar"));
                                File.Delete(downloadedPath);
                            }
                        }
                    }
                }
            }
        }

        // Copy the mods enabled in the settings into the mods folder
        private async void PlaceSettingMods()
        {
            string selectedMods = modSettings[saveData["selectedLoader"]][saveData["selectedVersion"]]["modSettings"];
            List<string> includedMods = JsonConvert.DeserializeObject<List<string>>(selectedMods);
            foreach (string mod in includedMods)
            {
                if (File.Exists(Path.Combine(modStashPath, mod)))
                    File.Copy(Path.Combine(modStashPath, mod), Path.Combine(SettingsManager.settings["modsPath"], mod));
                else
                {
                    string modsJson = Path.Combine("../Mods/" + mod + ".json");
                    using (StreamReader modReader = new StreamReader(modsJson))
                    {
                        string modInfoText = modReader.ReadToEnd();
                        Dictionary<string, object> modInfoDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(modInfoText);
                        if (modInfoDict == null) continue;

                        string downloadedPath = await downloader.DownloadFile(modInfoDict["directLink"].ToString(), ".jar");
                        if (downloadedPath == null) continue;

                        File.Copy(downloadedPath, Path.Combine(modStashPath, mod));
                        File.Copy(downloadedPath, Path.Combine(SettingsManager.settings["modsPath"], mod));
                        File.Delete(downloadedPath);
                    }
                }
            }
        }
    }
}

public enum Loader
{
    Forge,
    Fabric,
}