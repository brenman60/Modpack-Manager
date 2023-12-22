using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Controls;

namespace brenman60_s_Modpack_Manager.Scripts.Pages
{
    public class ModsPage : Window, IPage
    {
        public void UpdateText(TextBlock textBlock)
        {
            textBlock.Text = "Active Loader: " + ModManager.saveData["selectedLoader"] + " " + ModManager.saveData["selectedVersion"];
        }

        public List<string> GetAllMods()
        {
            List<string> mods = new List<string>();
            DirectoryInfo modsDirectoryInfo = new DirectoryInfo(SettingsManager.settings["modsPath"]);
            foreach (FileInfo modFile in modsDirectoryInfo.GetFiles())
            {
                string zipFileFullPath = modFile.FullName;

                Dictionary<string, string> modInfo = new Dictionary<string, string>();

                using (ZipArchive zip = ZipFile.OpenRead(zipFileFullPath))
                {
                    foreach (ZipArchiveEntry e in zip.Entries)
                    {
                        if (e.Name == "mods.toml")
                        {
                            using (Stream stream = e.Open())
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    string text = reader.ReadToEnd();
                                    string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                    foreach (string line in lines)
                                    {
                                        string[] lineParts = line.Split(new[] { "=", "#" }, StringSplitOptions.None);
                                        if (lineParts.Length > 1)
                                            switch (lineParts[0].Trim())
                                            {
                                                case "modId":
                                                    if (!modInfo.ContainsKey("modId"))
                                                        modInfo.Add("modId", lineParts[1].Trim().Replace('"'.ToString(), string.Empty));
                                                    break;
                                                case "displayName":
                                                    if (!modInfo.ContainsKey("displayName"))
                                                        modInfo.Add("displayName", lineParts[1].Trim().Replace('"'.ToString(), string.Empty));
                                                    break;
                                                case "version":
                                                    if (!modInfo.ContainsKey("version"))
                                                        modInfo.Add("version", lineParts[1].Trim().Replace('"'.ToString(), string.Empty));
                                                    break;
                                                case "description":
                                                    if (!modInfo.ContainsKey("description"))
                                                        modInfo.Add("description", lineParts[1].Trim().Replace('"'.ToString(), string.Empty));
                                                    break;
                                            }
                                    }
                                }
                            }
                        }
                        else if (e.Name == "MANIFEST.MF")
                        {
                            using (Stream stream = e.Open())
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    string text = reader.ReadToEnd();
                                    string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                    foreach (string line in lines)
                                    {
                                        string[] lineParts = line.Split(new[] { ":" }, StringSplitOptions.None);
                                        if (lineParts.Length > 1)
                                            switch (lineParts[0].Trim())
                                            {
                                                case "Implementation-Version":
                                                    if (!modInfo.ContainsKey("version"))
                                                        modInfo.Add("version", lineParts[1].Trim().Replace('"'.ToString(), string.Empty));
                                                    break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                }

                if (modInfo.Count == 0)
                {
                    // Debugging purposes
                    using (Stream stream = modFile.OpenRead())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string text = reader.ReadToEnd();
                            //MessageBox.Show("Mod: " + modFile.Name + " broken: " + text);
                        }
                    }
                }

                mods.Add(JsonConvert.SerializeObject(modInfo));
            }

            return mods;
        }

        void makeSureKeyExists(Dictionary<string, string> dict, string key, string defaultValue)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key, defaultValue);
        }

        public void UpdateStackPanel(StackPanel list)
        {
            list.Children.Clear();

            List<string> mods = GetAllMods();
            foreach (string mod in mods)
            {
                Dictionary<string, string>? modInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(mod);
                if (modInfo == null)
                    continue;

                makeSureKeyExists(modInfo, "modId", "modIdNotFound");
                makeSureKeyExists(modInfo, "displayName", "[name not found]");
                makeSureKeyExists(modInfo, "version", "[version not found]");
                makeSureKeyExists(modInfo, "description", "[description not found]");

                Grid modItem = UIItemTemplates.CreateModItem(modInfo["modId"], modInfo["displayName"], modInfo["version"], modInfo["description"]);
                list.Children.Add(modItem);
            }
        }
    }
}
