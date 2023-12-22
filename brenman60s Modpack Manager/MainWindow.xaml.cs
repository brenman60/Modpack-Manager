using brenman60_s_Modpack_Manager.Scripts;
using brenman60_s_Modpack_Manager.Scripts.Pages;
using brenman60s_Modpack_Manager.Scripts.Pages;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace brenman60_s_Modpack_Manager
{
    /* Window Shell Publish Command 1
     dotnet publish "C:\Users\Brennan\source\repos\brenman60s Modpack Manager\brenman60s Modpack Manager\brenman60s Modpack Manager.csproj" --runtime win-x86 --framework net8.0-windows --self-contained true -c Release -p:PublishSingleFile=true
     */

    /* Window Shell Publish Command 2 (1 MUST BE DONE FIRST)
     dotnet publish "C:\Users\Brennan\source\repos\brenman60s Modpack Manager\brenman60s Modpack Manager Loader\brenman60s Modpack Manager Loader.csproj" --runtime win-x86 --framework net8.0-windows --self-contained true -c Release -p:PublishSingleFile=true
     */

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
                case "versionsButton":
                    ChangeTabVisiblity(versionsContent);
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

            QuickSave();
            SwitchTab(activeTab, null);
        }

        private void SwitchVersion(object sender, RoutedEventArgs e)
        {
            if (!CheckIfFree()) return;

            ToggleProgressBar(true);

            ModManager modManager = new ModManager();
            modManager.ClearMods();

            Button? button = sender as Button;
            if (button == null) return;

            switch (button.Name)
            {
                case "version1192Select":
                    ModManager.saveData["selectedVersion"] = "1.19.2";
                    modManager.ReloadMods();
                    break;
                case "version1201Select":
                    ModManager.saveData["selectedVersion"] = "1.20.1";
                    modManager.ReloadMods();
                    break;
            }

            QuickSave();
            SwitchTab(activeTab, null);
        }

        public void ChangeModpack(object sender, RoutedEventArgs e)
        {
            if (!CheckIfFree()) return;

            Button? button = sender as Button;
            if (button == null) return;

            ModManager.modSettings[ModManager.saveData["selectedLoader"]][ModManager.saveData["selectedVersion"]]["selectedModpack"] = button.Name.Replace("Select", string.Empty);

            updateMods.Visibility = Visibility.Visible;
        }

        private void ReloadMods(object sender, RoutedEventArgs e)
        {
            if (!CheckIfFree()) return;

            ModManager manager = new ModManager();
            manager.ReloadMods();
            QuickSave();
            updateMods.Visibility = Visibility.Hidden;
        }

        public async void ToggleModSetting(object sender, RoutedEventArgs e)
        {
            if (!CheckIfFree()) return;

            workingJob = true;
            ToggleProgressBar(true);

            TextBlock fileNameText = ((sender as Button).Parent as Grid).Children[1] as TextBlock;
            Image checkmark = (sender as Button).Content as Image;
            if (fileNameText == null || checkmark == null) { MessageBox.Show("REMOVE THIS!!!!!!!!!!!!!!!!!!!!!"); return; }
            bool isOn = checkmark.Visibility == Visibility.Visible;

            string selectedLoader = brenman60_s_Modpack_Manager.Scripts.ModManager.saveData["selectedLoader"];
            string selectedVersion = brenman60_s_Modpack_Manager.Scripts.ModManager.saveData["selectedVersion"];
            List<string> activeModSettings = JsonConvert.DeserializeObject<List<string>>(brenman60_s_Modpack_Manager.Scripts.ModManager.modSettings[selectedLoader][selectedVersion]["modSettings"]);

            ModManager modManager = new ModManager();
            modManager.ClearModSettings(brenman60_s_Modpack_Manager.Scripts.ModManager.modSettings[selectedLoader][selectedVersion]["modSettings"]);

            if (isOn)
            {
                activeModSettings.Remove(fileNameText.Text);
                checkmark.Visibility = Visibility.Hidden;
            }
            else
            {
                activeModSettings.Add(fileNameText.Text);
                checkmark.Visibility = Visibility.Visible;
            }

            brenman60_s_Modpack_Manager.Scripts.ModManager.modSettings[selectedLoader][selectedVersion]["modSettings"] = JsonConvert.SerializeObject(activeModSettings);

            await modManager.PlaceSettingMods();

            ToggleProgressBar(false);
            QuickSave();
            workingJob = false;
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
            if (workingJob)
                e.Cancel = true;

            QuickSave();

            Application.Current.Shutdown();
        }

        private void QuickSave()
        {
            ModManager modManager = new();
            modManager.SaveData();
        }
    }
}