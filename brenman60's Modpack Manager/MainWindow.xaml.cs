using brenman60_s_Modpack_Manager.Scripts.Pages;
using System.Runtime.CompilerServices;
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
    }
}