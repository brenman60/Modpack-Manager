using brenman60_s_Modpack_Manager.Scripts;
using brenman60_s_Modpack_Manager.Scripts.Pages;
using brenman60s_Modpack_Manager.Scripts.Pages;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace brenman60_s_Modpack_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool workingJob = false;

        private List<IPage> pages = new List<IPage>();
        private List<Grid> tabContents = new List<Grid>();

        public MainWindow()
        {
            InitializeComponent();
            RegisterPages();
            ModManager modManager = new();
            modManager.LoadData();
            EnsureModStash();

            Closing += MainWindow_Closing;
        }

        private void EnsureModStash()
        {
            if (!Directory.Exists(ModManager.modStashPath))
                Directory.CreateDirectory(ModManager.modStashPath);
        }

        private void RegisterTab(object sender, RoutedEventArgs e)
        {
            Grid? registeredGrid = sender as Grid;
            if (registeredGrid == null) return;
            tabContents.Add(registeredGrid);
        }

        private void RegisterPages()
        {
            pages.Add(new ModsPage());
            pages.Add(new ModpackPage());
            pages.Add(new ModSettingsPage());
        }

        private Button activeTab;
        private void SwitchTab(object sender, RoutedEventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton == null) return;
            activeTab = clickedButton;

            switch (clickedButton.Name)
            {
                case "launcherButton":
                    ChangeTabVisiblity(launcherContent);
                    pages[0].UpdateText(modLoaderText);
                    pages[0].UpdateStackPanel(activeModList);
                    break;
                case "modpacksButton":
                    ChangeTabVisiblity(modpacksContent);
                    pages[1].UpdateStackPanel(modpackList);
                    break;
                case "modSettingsButton":
                    ChangeTabVisiblity(modSettingsContent);
                    pages[2].UpdateStackPanel(modSettingsList);
                    break;
                default:
                    ChangeTabVisiblity(launcherContent);
                    break;
            }
        }

        private void ChangeTabVisiblity(Grid selectedTab)
        {
            foreach (Grid item in tabContents)
                if (item != selectedTab)
                    item.Visibility = Visibility.Collapsed;
                else
                    item.Visibility = Visibility.Visible;
        }

        private void SwitchLoader(object sender, RoutedEventArgs e)
        {
            if (!CheckIfFree()) return;

            ToggleProgressBar(true);

            // Probably call the reload mods function in the ModManager
            ModManager modManager = new ModManager();
            modManager.ClearMods();

            Button? button = sender as Button;
            if (button == null) return;

            switch (button.Name)
            {
                case "forgeSwitchButton":
                    ModManager.saveData["selectedLoader"] = "Forge";
                    modManager.ReloadMods();
                    break;
                case "fabricSwitchButton":
                    ModManager.saveData["selectedLoader"] = "Fabric";
                    modManager.ReloadMods();
                    break;
            }

            SwitchTab(activeTab, null);
        }

        public void ChangeModpack(object sender, RoutedEventArgs e)
        {
            if (!CheckIfFree()) return;

            Button? button = sender as Button;
            if (button == null) return;

            switch (button.Name)
            {
                case "modpack1Select":
                    ModManager.modSettings[ModManager.saveData["selectedLoader"]][ModManager.saveData["selectedVersion"]]["selectedModpack"] = "modpack1";
                    break;
                case "modpack2Select":
                    ModManager.modSettings[ModManager.saveData["selectedLoader"]][ModManager.saveData["selectedVersion"]]["selectedModpack"] = "modpack2";
                    break;
            }

            updateMods.Visibility = Visibility.Visible;
        }

        private void ReloadMods(object sender, RoutedEventArgs e)
        {
            if (!CheckIfFree()) return;

            ModManager manager = new ModManager();
            manager.ReloadMods();
            updateMods.Visibility = Visibility.Hidden;
        }

        private void ScrollModList(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            float speed = 1f;
            ScrollViewer? scrollViewer = sender as ScrollViewer;
            if (scrollViewer == null) return;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta * (0.01 * speed));
            e.Handled = true;
        }

        public void ChangeProgressText(string newText)
        {
            progressbarText.Text = newText;
        }

        public void ToggleProgressBar(bool status)
        {
            DoubleAnimation animation = new DoubleAnimation(status ? 75 : 0, new Duration(TimeSpan.FromSeconds(.25)));
            downloadBar.BeginAnimation(HeightProperty, animation);
        }

        private bool CheckIfFree()
        {
            return !workingJob;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            ModManager modManager = new();
            modManager.SaveData();
        }
    }
}