using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace brenman60_s_Modpack_Manager.Scripts
{
    public static class SettingsManager
    {
        public static Dictionary<string, string> settings = new Dictionary<string, string>()
        {
            ["modsPath"] = "",
            ["askBeforeUpdate"] = "true",
        };

        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> modSettings = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>()
        {
            ["Forge"] = new Dictionary<string, Dictionary<string, string>>()
            {
                ["1.20.1"] = new Dictionary<string, string>()
                {

                },
            },
            ["Fabric"] = new Dictionary<string, Dictionary<string, string>>()
            {

            },
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
