using System.Diagnostics;
using System.IO;
using System.Windows;
using ModpackManager.Utils;

namespace brenman60_s_Modpack_Manager_Updater
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            FileManager fileManager = new FileManager();
            Downloader downloader = new Downloader();
            if (e.Args.Length > 0)
            {
                // If there are args, that means that an update should be downloaded
            }
            else if (File.Exists(FileManager.versionFilePath))
            {
                // If there are no args, that means we should check if there is an update
                // If there isn't an update, start the main program with args
                // If there is an update, copy this exe into a sub folder, stop this current program, and start the copied version with args to make this if statement true
                string? currentVersion = await fileManager.ReadFile(FileManager.versionFilePath);
                string? latestVersion = await fileManager.ReadFile(await downloader.DownloadFile(await downloader.GetDownloadLink(DownloadLink.LatestVersionText)));
                if (currentVersion != latestVersion)
                {
                    // If there is a new version available

                }
                else
                {
                    // Current version is up to date
                    StartMain();
                }
            }
            else
            {
                // Version file doesn't exist, so this is probably a first time startup, so just download the newest version file and open the program
                string? latestVersion = await fileManager.ReadFile(await downloader.DownloadFile(await downloader.GetDownloadLink(DownloadLink.LatestVersionText)));
                await fileManager.WriteToFile(await downloader.GetDownloadLink(DownloadLink.LatestVersionText), latestVersion);
                StartMain();
            }

            base.OnStartup(e);
        }

        private void StartMain()
        {
            ProcessStartInfo bmmStartInfo = new ProcessStartInfo()
            {
                Arguments = "verified",
                CreateNoWindow = false,
                FileName = "brenman60's Modpack Manager.exe",
                WindowStyle = ProcessWindowStyle.Normal,
            };

            Process.Start(bmmStartInfo);

            Environment.Exit(0);
        }
    }
}
