using System.IO;
using System.Windows;
using System.Diagnostics;
using brenman60_s_Modpack_Manager.Scripts;
using ModpackManager.Utils;
using Newtonsoft.Json;

namespace brenman60_s_Modpack_Manager
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            FileManager fileManager = new FileManager();
            Downloader downloader = new Downloader();
            string dd_downloadedFile = await downloader.DownloadFile("https://dl.dropboxusercontent.com/scl/fi/ap7lmeh2plcchfpl4x1bt/directModDownloads.txt?rlkey=4clebota1r6q1ss7661rripyb&dl=0", new Progress<int>(), ".txt");
            string dd_downloadedFileContent = fileManager.ReadFile(dd_downloadedFile);
            Mods.directDownloads = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(dd_downloadedFileContent);

            string msi_downloadedFile = await downloader.DownloadFile("https://dl.dropboxusercontent.com/scl/fi/a4omdo8c06mev7qih03g8/modSettingsInfo.txt?rlkey=nsoq5rdxlrg1occpyoec1ie0o&dl=0", new Progress<int>(), ".txt");
            string msi_downloadedFileContet = fileManager.ReadFile(msi_downloadedFile);
            Mods.modSettingsInfo = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>>(msi_downloadedFileContet);

            if (e.Args.Length == 0)
            {
                bool startUpdater = true;

#if DEBUG
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Start Updater?", "You're in debug", System.Windows.MessageBoxButton.YesNo);
                startUpdater = messageBoxResult == MessageBoxResult.Yes;
#endif

                if (startUpdater)
                {
                    // Start the updater and close this application
                    string updaterPath = Path.Combine(Directory.GetCurrentDirectory(), "brenman60s Modpack Manager Loader.exe");
                    ProcessStartInfo updaterStartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = false,
                        FileName = updaterPath,
                        WindowStyle = ProcessWindowStyle.Normal,
                    };

                    Process.Start(updaterStartInfo);

                    Environment.Exit(0);
                }
            }

            base.OnStartup(e);
        }
    }
}
