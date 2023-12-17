using brenman60_s_Modpack_Manager.Scripts;
using brenman60_s_Modpack_Manager.Scripts.Pages;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace brenman60_s_Modpack_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IPage> pages = new List<IPage>();
        private List<Grid> tabContents = new List<Grid>();

        public MainWindow()
        {
            InitializeComponent();
            RegisterPages();
            SwitchTab(pages[0], null);
            EnsureModStash();
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
        }

        private void SwitchTab(object sender, RoutedEventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton == null) return;

            switch (clickedButton.Name)
            {
                case "launcherButton":
                    ChangeTabVisiblity(launcherContent);
                    pages[0].UpdateText(modLoaderText);
                    pages[0].UpdateStackPanel(activeModList);
                    break;
                case "modpacksButton":
                    ChangeTabVisiblity(modpacksContent);
                    break;
                case "modSettingsButton":
                    ChangeTabVisiblity(modSettingsContent);
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
            // Probably call the reload mods function in the ModManager
        }

        private void ScrollModList(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            float speed = 1f;
            ScrollViewer? scrollViewer = sender as ScrollViewer;
            if (scrollViewer == null) return;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta * (0.01 * speed));
            e.Handled = true;
        }
    }
}