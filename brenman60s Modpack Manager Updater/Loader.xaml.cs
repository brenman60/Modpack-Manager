using System.Windows;

namespace brenman60_s_Modpack_Manager_Updater
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loader : Window
    {
        public Loader()
        {
            InitializeComponent();
        }

        public static void ChangeStatus(string newStatus)
        {
            //progressText.Text = newStatus;
        }
    }
}
