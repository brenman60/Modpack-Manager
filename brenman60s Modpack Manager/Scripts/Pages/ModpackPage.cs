using ModpackManager.Utils;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;

namespace brenman60_s_Modpack_Manager.Scripts.Pages
{
    public class ModpackPage : Window, IPage
    {
        public async void UpdateStackPanel(StackPanel list)
        {
            list.Children.Clear();

            Downloader downloader = new Downloader();
            FileManager fileManager = new FileManager();

            if (ModpackManager.currentModpacksJSON == string.Empty)
            {
                string modpacksRaw = fileManager.ReadFile(await downloader.DownloadFile(FileManager.downloadLinks[DownloadLink.ModpacksList], new Progress<int>(), ".txt"));
                ModpackManager.currentModpacksJSON = modpacksRaw;
            }

            List<Dictionary<string, object>> modpacks = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ModpackManager.currentModpacksJSON);
            foreach (Dictionary<string, object> modpack in modpacks)
            {
                if (modpack["loader"].ToString() == ModManager.saveData["selectedLoader"] && modpack["version"].ToString() == ModManager.saveData["selectedVersion"])
                {
                    int modAmount = 0;
                    string modsRaw = fileManager.ReadFile(await downloader.DownloadFile(modpack["mods"].ToString(), new Progress<int>(), ".txt"));
                    if (modsRaw != null)
                        if (modsRaw.Trim() != string.Empty)
                        {
                            List<string> modAmount_ = JsonConvert.DeserializeObject<List<string>>(modsRaw);
                            modAmount = modAmount_.Count;
                        }

                    Grid modpackItem = UIItemTemplates.CreateModpackItem(
                        modpack["id"].ToString(), 
                        modpack["modpackName"].ToString(),
                        modpack["version"].ToString(),
                        modpack["description"].ToString(),
                        modAmount);

                    list.Children.Add(modpackItem);
                }
            }
        }
    }
}
