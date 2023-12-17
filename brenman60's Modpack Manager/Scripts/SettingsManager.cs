using System.IO;
using Newtonsoft.Json;

namespace brenman60_s_Modpack_Manager.Scripts
{
    public static class SettingsManager
    {
        public static Dictionary<string, string> settings = new Dictionary<string, string>()
        {
            ["modsPath"] = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft"), "mods"),
            ["askBeforeUpdate"] = "true",
        };

        public static void SetSettingsFromText(string text)
        {
            // Convert text into settings dictionary
        }

        public static string GetSettingsText()
        {
            // Turn settings into json
            return null;
        }

        public static void SetModSettingsFromText(string text)
        {
            // Convert text into mod settings dictionary
        }

        public static string GetModSettingsText()
        {
            // Turn mod settings into json
            return null;
        }
    }
}
