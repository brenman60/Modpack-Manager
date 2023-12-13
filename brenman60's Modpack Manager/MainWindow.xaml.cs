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
        private List<Grid> tabContents = new List<Grid>();

        public MainWindow()
        {
            InitializeComponent();

            tabContents.Add(launcherContent);
            tabContents.Add(modpacksContent);
            tabContents.Add(modSettingsContent);
        }

        private void SwitchTab(object sender, RoutedEventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton == null)
                return;

            switch (clickedButton.Name)
            {
                case "launcherButton":
                    ChangeTabVisiblity(launcherContent);
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
    }
}