using System.IO;

namespace brenman60_s_Modpack_Manager.scripts
{
    public static class ErrorManager
    {
        public static void LogError(string errorMessage)
        {
            // Get next free error log file
            int index = 1;
            while (true)
            {
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "errorLog" + index + ".txt")))
                    index++;
                else
                    break;
            }

            Console.WriteLine("ErrorManager still needs to show error message visually");
            using (StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "errorLog" + index + ".txt")))
            {
                writer.WriteLine(errorMessage);
            }
        }
    }
}
