using brenman60_s_Modpack_Manager.Scripts;
using brenman60_s_Modpack_Manager.Scripts.Pages;
using System.Windows;
using System.Windows.Controls;

namespace brenman60s_Modpack_Manager.Scripts.Pages
{
    public class ModSettingsPage : Window, IPage
    {
        public void UpdateStackPanel(StackPanel list)
        {
            list.Children.Clear();

            int modCategory_ = 0;
            foreach (KeyValuePair<string, List<string>> modCategory in brenman60_s_Modpack_Manager.Scripts.ModpackManager.modSettings[ModManager.saveData["selectedLoader"]][ModManager.saveData["selectedVersion"]])
            {
                TextBlock categoryText = UIItemTemplates.CreateModCategoryText("category" + modCategory_, modCategory.Key);
                list.Children.Add(categoryText);

                int modId = 0;
                foreach (string mod in modCategory.Value)
                {
                    string modName = Mods.modSettingsInfo[ModManager.saveData["selectedLoader"]][ModManager.saveData["selectedVersion"]][mod]["modName"];
                    Grid modItem = UIItemTemplates.CreateModSettingItem("modSetting" + modId, modName, mod);
                    list.Children.Add(modItem);
                    modId++;
                }

                modCategory_++;
            }
        }
    }
}
