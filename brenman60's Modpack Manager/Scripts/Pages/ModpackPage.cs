using System.Windows;
using System.Windows.Controls;

namespace brenman60_s_Modpack_Manager.Scripts.Pages
{
    public class ModpackPage : Window, IPage
    {
        public void UpdateStackPanel(StackPanel list)
        {
            list.Children.Clear();

            foreach (Dictionary<string, object> modpack in ModpackManager.modpacks)
            {
                if (modpack["loader"].ToString() == ModManager.saveData["selectedLoader"])
                {
                    List<string> modAmount_ = modpack["mods"] as List<string>;
                    int modAmount = modAmount_.Count;
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
