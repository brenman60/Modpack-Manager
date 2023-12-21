﻿using System.IO;
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
        /// <param name="fileExtension">An additional file extension to add when needed</param>
        /// <returns>Downloaded file's location</returns>
        public async Task<string?> DownloadFile(string downloadLink, string fileExtension = "")
        {
            if (downloadLink == null || string.IsNullOrEmpty(downloadLink) || string.IsNullOrWhiteSpace(downloadLink)) return null;

            string? task = await Task.Run(DownloadFile_);
            return task;
            async Task<string?> DownloadFile_()
            {
                using (var http = new HttpClient())
                {
                    using (var download = await http.GetStreamAsync(downloadLink))
                    {
                        if (download == null) return null;

                        string tempFileLocation = Path.Combine(Path.GetTempPath(), "downloadedFileModpackManager" + RandomNumberGenerator.GetInt32(999999) + fileExtension);
                        using (var stream = new FileStream(tempFileLocation, FileMode.OpenOrCreate))
                        {
                            byte[] buffer = new byte[81920];
                            int bytesRead;

                            while ((bytesRead = await download.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await stream.WriteAsync(buffer, 0, bytesRead);
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
}

public enum ModpackLinks
{
    jacobfartman60_aternos_me,
    brenbro60_aternos_me,
}
