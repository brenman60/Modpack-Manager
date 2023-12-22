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
            Dictionary<string, string>? data = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            if (data == null) return;

            settings = data;
        }

        public static string GetSettingsText()
        {
            return JsonConvert.SerializeObject(settings);
        }
    }
}
