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
        };

        public static readonly Dictionary<ModpackLinks, string> modpackDownloadLinks = new Dictionary<ModpackLinks, string>()
        {
            [ModpackLinks.jacobfartman60_aternos_me] = "https://dl.dropboxusercontent.com/scl/fi/gnfhae41co5uohxbi98tj/jacobfartman60.aternos.me_Modpack.zip?rlkey=am2d6b9vvvyvegp3ztbue5q1z&dl=0",
            [ModpackLinks.brenbro60_aternos_me] = "https://dl.dropboxusercontent.com/scl/fi/gr2ek9ojavipyhanr7r4v/brenbro60.aternos.me_Modpack.zip?rlkey=az0s80euagmrgbza4c0fwp0ca&dl=0",
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
