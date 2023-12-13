using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows;
using ModpackManager.Utils;

namespace brenman60_s_Modpack_Manager_Updater
{
    public partial class App : Application
    {
        TextData data;

        FileManager fileManager = new FileManager();
        Downloader downloader = new Downloader();

        protected override void OnStartup(StartupEventArgs e)
        {
            data = new TextData();

            if (e.Args.Length != 0)
            {
                if (e.Args[0] != "start")
                {
                    // If there are args, that means that an update should be downloaded
                    // First arg should be the path of the original program
                    string fullPath = string.Empty;
                    foreach (string arg in e.Args)
                        fullPath += arg + " ";

                    fullPath.TrimEnd();

                    DownloadLatestProgram(fullPath);
                }
                else
                    FirstTimeDownload();
            }
            else if (File.Exists(FileManager.versionFilePath))
                TestVersions();
            else
                FirstTimeDownload();

            base.OnStartup(e);
        }

        async void DownloadLatestProgram(string programPath)
        {
            //this.MainWindow.Title = "Downloading Newest Version";

            // Download program as zip
            string downloadedProgram = await downloader.DownloadFile(FileManager.downloadLinks[DownloadLink.LatestVersion], ".zip");

            // Remove all files in program path
            DirectoryInfo programDirectoryInfo = new DirectoryInfo(programPath);
            foreach (FileInfo fi in programDirectoryInfo.GetFiles())
                fi.Delete();

            foreach (DirectoryInfo di in programDirectoryInfo.GetDirectories())
                Directory.Delete(di.FullName, true);

            // Extract newly downloaded program zip into program directory
            //this.MainWindow.Title = "Extracting Zip";
            ZipFile.ExtractToDirectory(downloadedProgram, programPath, true);
            File.Delete(downloadedProgram);

            ProcessStartInfo newProgramStartInfo = new ProcessStartInfo()
            {
                Arguments = "start",
                CreateNoWindow = false,
                FileName = Path.Combine(programPath.Trim(), Process.GetCurrentProcess().MainModule.ModuleName.Trim()),
                WindowStyle = ProcessWindowStyle.Normal,
            };

            Process.Start(newProgramStartInfo);

            Environment.Exit(0);
        }

        async void TestVersions()
        {
            // If there are no args, that means we should check if there is an update
            // If there isn't an update, start the main program with args
            // If there is an update, copy this exe into a sub folder, stop this current program, and start the copied version with args to make this if statement true
            string? currentVersion = fileManager.ReadFile(FileManager.versionFilePath);
            string? latestVersion = fileManager.ReadFile(await downloader.DownloadFile(FileManager.downloadLinks[DownloadLink.LatestVersionText]));
            if (latestVersion == null)
            {
                StartMain();
                return;
            }

            if (currentVersion.Trim() != latestVersion.Trim())
            {
                // Program really doesn't techincally need to be up to date at all times, so it can be a choice
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Update now?", "A new version is available", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    //this.MainWindow.Title = "Beginning Update";

                    // If there is a new version available
                    void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
                    {
                        if (!destination.Exists)
                            destination.Create();

                        FileInfo[] files = source.GetFiles();
                        foreach (FileInfo file in files)
                            file.CopyTo(Path.Combine(destination.FullName, file.Name));

                        DirectoryInfo[] dirs = source.GetDirectories();
                        foreach (DirectoryInfo dir in dirs)
                        {
                            string destinationDir = Path.Combine(destination.FullName, dir.Name);
                            CopyDirectory(dir, new DirectoryInfo(destinationDir));
                        }
                    }

                    DirectoryInfo newFolderInfo = Directory.CreateTempSubdirectory();
                    DirectoryInfo current = new DirectoryInfo(Directory.GetCurrentDirectory());
                    CopyDirectory(current, newFolderInfo);

                    ProcessStartInfo updaterStartInfo = new ProcessStartInfo()
                    {
                        Arguments = current.FullName,
                        CreateNoWindow = false,
                        FileName = Path.Combine(newFolderInfo.FullName, Process.GetCurrentProcess().MainModule.ModuleName),
                        WindowStyle = ProcessWindowStyle.Normal,
                    };

                    Process.Start(updaterStartInfo);

                    Environment.Exit(0);
                }
                else
                    StartMain();
            }
            else
            {
                // Current version is up to date
                StartMain();
            }
        }

        async void FirstTimeDownload()
        {
            //this.MainWindow.Title = "Downloading File";

            // Version file doesn't exist, so this is probably a first time startup, so just download the newest version file and open the program
            string? latestVersion = fileManager.ReadFile(await downloader.DownloadFile(FileManager.downloadLinks[DownloadLink.LatestVersionText]));
            bool written = await fileManager.WriteToFile(FileManager.versionFilePath, latestVersion);
            StartMain();
        }

        private void StartMain()
        {
            data.DisplayText = "Starting...";

            ProcessStartInfo bmmStartInfo = new ProcessStartInfo()
            {
                Arguments = "verified",
                CreateNoWindow = false,
                FileName = Path.Combine(Directory.GetCurrentDirectory(), "brenman60's Modpack Manager.exe"),
                WindowStyle = ProcessWindowStyle.Normal,
            };

            Process.Start(bmmStartInfo);

            Environment.Exit(0);
        }
    }
}
