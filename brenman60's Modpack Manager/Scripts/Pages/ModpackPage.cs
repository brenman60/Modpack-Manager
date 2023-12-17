using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace brenman60_s_Modpack_Manager.Scripts.Pages
{
    public class ModpackPage : Window, IPage
    {
        public void UpdateStackPanel(StackPanel list)
        {
            list.Children.Clear();

            string pathToModpacks = "../../Modpacks/";
            DirectoryInfo modpackDirectory = new DirectoryInfo(pathToModpacks);
            foreach (FileInfo modpack in modpackDirectory.GetFiles())
            {
                using (StreamReader modpackReader = new StreamReader(modpack.FullName))
                {
                    string modpackRaw = modpackReader.ReadToEnd();
                    Dictionary<string, object>? modpackInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(modpackRaw);
                    if (modpackInfo == null) continue;

                    if (modpackInfo["loader"].ToString() == ModManager.saveData["selectedLoader"])
                    {

                    }
                }
            }
        }
    }
}
