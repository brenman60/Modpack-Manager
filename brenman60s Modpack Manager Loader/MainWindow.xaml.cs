using System.Windows;

namespace brenman60_s_Modpack_Manager_Loader
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetProgressBar(double progress, double maxValue)
        {
            this.loadingProgressBar.Value = progress;
            this.loadingProgressBar.Maximum = maxValue;
            this.loadingProgressBar.IsIndeterminate = false;
        }

        public void SetText(string newText)
        {
            this.progressText.Text = newText;
        }
    }
}
