using System.IO;

namespace ModpackManager.Utils
{
    public class FileManager
    {
        public static readonly string versionFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "version.txt");

        /// <summary>
        /// Reads and returns the content of the specified file
        /// </summary>
        /// <param name="filePath">The path of the file to be read</param>
        /// <returns>The content of the file</returns>
        public async Task<string?> ReadFile(string filePath)
        {
            if (File.Exists(filePath))
                return null;

            using (StreamReader reader = new StreamReader(filePath))
                return await reader.ReadToEndAsync();
        }

        public async Task<bool> WriteToFile(string filePath, string newText)
        {
            try
            {
                File.Create(filePath);
                using (StreamWriter writer = new StreamWriter(filePath))
                    await writer.WriteLineAsync(newText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Writes over file's content with specified text
        /// </summary>
        /// <param name="filePath">The path of the file to be overwritten</param>
        /// <param name="newText">The text that the file will overwritten with</param>
        /// <returns>True or False depending on the successfulness of the overwrite</returns>
        public async Task<bool> WriteOverFile(string filePath, string newText)
        {
            if (!File.Exists(filePath))
                return false;

            await File.WriteAllTextAsync(filePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(filePath))
                await writer.WriteLineAsync(newText);

            return true;
        }
    }
}
