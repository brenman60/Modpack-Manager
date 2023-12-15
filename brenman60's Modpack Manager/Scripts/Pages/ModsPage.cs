using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace brenman60_s_Modpack_Manager.Scripts.Pages
{
    public class ModsPage : Window, IPage
    {
        public string PageName { get; set; }

        public void UpdateText(TextBlock textBlock)
        {
            textBlock.Text = "Active Loader: " + ModManager.saveData["selectedLoader"] + " " + ModManager.saveData["selectedVersion"];
        }
    }
}
