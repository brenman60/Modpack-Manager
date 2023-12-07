using System.IO;
using System.Windows;
using System.Diagnostics;

namespace brenman60_s_Modpack_Manager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Length == 0)
            {
                // Start the updater and close this application
                string updaterPath = Path.Combine(Directory.GetCurrentDirectory(), "brenman60's Modpack Manager Updater.exe");
                ProcessStartInfo updaterStartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = false,
                    FileName = updaterPath,
                    WindowStyle = ProcessWindowStyle.Normal,
                };

                Process.Start(updaterStartInfo);

                Environment.Exit(0);
            }

            base.OnStartup(e);
        }
    }
}
