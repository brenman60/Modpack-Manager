using System.IO;
using System.Net.Http;
using System.Security.Cryptography;

namespace ModpackManager.Utils
{
    public class Downloader
    {
        /// <summary>
        /// Downloads the file specified at the downloadLink.
        /// </summary>
        /// <param name="downloadLink">The link to the online file to be downloaded</param>
        /// <param name="fileExtension">An additional file extension to add when needed (You need to include the period!)</param>
        /// <returns>Downloaded file's location</returns>
        public async Task<string?> DownloadFile(string downloadLink, IProgress<int> progress, string fileExtension = "")
        {
            if (downloadLink == null || string.IsNullOrEmpty(downloadLink) || string.IsNullOrWhiteSpace(downloadLink))
                return null;

            string? task = await Task.Run(() => DownloadFile_(downloadLink, progress, fileExtension));
            return task;
        }

        private async Task<string?> DownloadFile_(string downloadLink, IProgress<int> progress, string fileExtension)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.GetAsync(downloadLink, HttpCompletionOption.ResponseHeadersRead))
                {
                    using (var download = await response.Content.ReadAsStreamAsync())
                    {
                        if (download == null)
                            return null;

                        string tempFileLocation = Path.Combine(Path.GetTempPath(), "downloadedFileModpackManager" + RandomNumberGenerator.GetInt32(999999) + fileExtension);
                        using (var stream = new FileStream(tempFileLocation, FileMode.OpenOrCreate))
                        {
                            byte[] buffer = new byte[81920];
                            int bytesRead;
                            long totalBytesRead = 0;
                            long totalBytes = response.Content.Headers.ContentLength ?? -1;

                            while ((bytesRead = await download.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await stream.WriteAsync(buffer, 0, bytesRead);
                                totalBytesRead += bytesRead;

                                if (totalBytes != -1)
                                {
                                    int percentage = (int)((double)totalBytesRead / totalBytes * 100);
                                    progress.Report(percentage);
                                }
                            }

                            stream.Close();
                        }

                        return tempFileLocation;
                    }
                }
            }
        }
    }
}

public enum DownloadLink
{
    LatestVersionText,
    LatestVersion,
    ModpacksList,
}

public enum ModpackLinks
{
    jacobfartman60_aternos_me,
    brenbro60_aternos_me,
}
