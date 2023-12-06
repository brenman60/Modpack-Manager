using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace ModpackManager.Utils
{
    public class Downloader
    {
        FileManager fileManager = new FileManager();
        private readonly string downloadLinksFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, Path.Combine("Misc", "downloadLinks.json"));

        public async Task<string?> GetDownloadLink(DownloadLink selectedLink)
        {
            Dictionary<string, string>? downloadLinksDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(await fileManager.ReadFile(downloadLinksFile));
            if (downloadLinksDict == null)
                return null;

            switch (selectedLink)
            {
                case DownloadLink.LatestVersionText:
                    return downloadLinksDict["programVersion"];
                case DownloadLink.LatestVersion:
                    return downloadLinksDict["program"];
                default:
                    return null;
            }
        }

        /// <summary>
        /// Downloads the file specified at the downloadLink.
        /// </summary>
        /// <param name="downloadLink">The link to the online file to be downloaded</param>
        /// <returns>Downloaded file's location</returns>
        public async Task<string?> DownloadFile(string downloadLink)
        {
            if (downloadLink == null || string.IsNullOrEmpty(downloadLink) || string.IsNullOrWhiteSpace(downloadLink)) return null;

            using (var http = new HttpClient())
            {
                using (var download = await http.GetStreamAsync(downloadLink))
                {
                    if (download == null) return null;

                    string tempFileLocation = Path.Combine(Path.GetTempPath(), "downloadedFileModpackManager" + RandomNumberGenerator.GetInt32(999999));
                    using (var stream = new FileStream(tempFileLocation, FileMode.OpenOrCreate))
                        await download.CopyToAsync(stream);

                    return tempFileLocation;
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
