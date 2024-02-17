using System.IO;

namespace ModpackManager.Utils
{
    public class FileManager
    {
        public static readonly string versionFilePath = Path.Combine(Directory.GetCurrentDirectory(), "version.txt");

        public static readonly Dictionary<DownloadLink, string> downloadLinks = new Dictionary<DownloadLink, string>()
        {
            [DownloadLink.LatestVersionText] = "https://dl.dropboxusercontent.com/scl/fi/a24v6aqodr5nmi572wpp7/c-codermodsprogramversion.txt?rlkey=5kvn0te9sq2rbscjmsndy2ncj&dl=0",
            [DownloadLink.LatestVersion] = "https://dl.dropboxusercontent.com/scl/fi/w613bi57egarbkoudmt9s/C-CodersModsProgram.zip?rlkey=7sw906fr33yugkfgcr16cr51j&dl=0",
            [DownloadLink.ModpacksList] = "https://dl.dropboxusercontent.com/scl/fi/a4r5rximp9l4knz37k55n/modpacks.txt?rlkey=dc6w1tr3io6hwigpid1ry7h94&dl=0",
        };

        /// <summary>
        /// Reads and returns the content of the specified file
        /// </summary>
        /// <param name="filePath">The path of the file to be read</param>
        /// <returns>The content of the file</returns>
        public string? ReadFile(string filePath)
        {
            if (!File.Exists(filePath) || filePath == null)
                return null;

            string fileContent = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
                reader.Close();
            }

            return fileContent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="newText"></param>
        /// <returns></returns>
        public async Task<bool> WriteToFile(string filePath, string newText)
        {
            using (FileStream creationStream = File.Create(filePath))
                creationStream.Close();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteLineAsync(newText);
                writer.Close();
            }

            return true;
        }
    }
}
