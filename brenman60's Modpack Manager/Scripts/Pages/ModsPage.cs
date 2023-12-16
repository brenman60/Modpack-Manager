using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
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

        public void GetAllMods()
        {
            DirectoryInfo modsDirectoryInfo = new DirectoryInfo(SettingsManager.settings["modsPath"]);
            foreach (FileInfo modFile in modsDirectoryInfo.GetFiles())
            {
                string zipFileFullPath = modFile.FullName;
                string targetFileName = "mods.toml";

                Dictionary<string, string> modInfo = new Dictionary<string, string>();

                using (ZipArchive zip = ZipFile.OpenRead(zipFileFullPath))
                {
                    foreach (ZipArchiveEntry e in zip.Entries)
                    {
                        if (e.Name == targetFileName)
                        {
                            using (Stream stream = e.Open())
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    bool _ = false;
                                    string text = reader.ReadToEnd();
                                    string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                    foreach (string line in lines)
                                    {
                                        string[] lineParts = line.Split(new[] { "=", "#" }, StringSplitOptions.None);
                                        if (lineParts.Length > 1)
                                            switch (lineParts[0])
                                            {
                                                case "displayName":
                                                    _ = true;
                                                    modInfo.Add("displayName", lineParts[1]);
                                                    break;
                                                case "version":
                                                    _ = true;
                                                    modInfo.Add("version", lineParts[1]);
                                                    break;
                                            }
                                    }

                                    if (!_)
                                        MessageBox.Show("Missed mod: " + modFile.Name + " - " + text);
                                    else
                                        MessageBox.Show(JsonConvert.SerializeObject(modInfo));
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateStackPanel(StackPanel list)
        {
            GetAllMods();
        }
    }
}
