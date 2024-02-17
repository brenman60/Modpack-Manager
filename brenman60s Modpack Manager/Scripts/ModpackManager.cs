namespace brenman60_s_Modpack_Manager.Scripts
{
    public static class ModpackManager
    {
        public static string currentModpacksJSON = string.Empty;

        public static List<Dictionary<string, object>> userModpacks = new List<Dictionary<string, object>>()
        {
            // Example modpack formatting
            new Dictionary<string, object>()
            {
                ["name"] = "Example Modpack",
                ["loader"] = "Forge",
                ["version"] = "1.20.1",
                ["mods"] = new List<string>()
                {
                    "ExampleMod_FORGE.json",
                },
            },
        };

        public static Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> modSettings = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>()
        {
            ["Forge"] = new Dictionary<string, Dictionary<string, List<string>>>()
            {
                ["1.19.2"] = new Dictionary<string, List<string>>()
                {
                    ["Preference Mods"] = new List<string>()
                    {
                        "jei-1.19.2-forge-11.6.0.1018",
                        "fullbrightnesstoggle-1.19.2-3.0",
                        "oculus-mc1.19.2-1.6.4",
                        "oculus-flywheel-compat-1.19.2-0.2.1",
                    },
                    ["Performance Mods"] = new List<string>()
                    {
                        "rubidium-0.6.2b",
                        "entityculling-forge-1.6.1-mc1.19.2",
                        "starlight-1.1.1+forge.cf5b10b",
                    },
                },
                ["1.20.1"] = new Dictionary<string, List<string>>()
                {
                    ["Preference Mods"] = new List<string>()
                    {
                        "jei-1.20.1-forge-15.2.0.27",
                        "Xaeros_Minimap_23.9.3_Forge_1.20",
                        "XaerosWorldMap_1.37.2_Forge_1.20",
                        "fullbrightnesstoggle-1.20.1-3.1",
                        "soundphysics-forge-1.20.1-1.3.0",
                        "TravelersTitles-1.20-Forge-4.0.1",
                        "watut-1.20.1-1.0.11",
                        "oculus-mc1.20.1-1.6.9",
                        "oculus-flywheel-compat-1.20.1-0.2.0",
                        "YungsExtras-1.20-Forge-4.0.3",
                        "YungsMenuTweaks-1.20.1-Forge-1.0.1",
                        "fast-ip-ping-mc1.20.4-forge-v1.0.1",
                    },
                    ["Performance Mods"] = new List<string>()
                    {
                        "embeddium-0.2.13+mc1.20.1",
                        "entityculling-forge-1.6.2-mc1.20.1",
                        "ImmediatelyFast-Forge-1.2.8+1.20.4",
                        "modernfix-forge-5.10.1+mc1.20.1",
                        "ferritecore-6.0.1-forge",
                        "Chunky-1.3.92",
                        "starlight-1.1.2+forge.1cda73c",
                        "saturn-mc1.20.1-0.0.10",
                        "radium-mc1.20.1-0.12.2+git.5f80f74",
                        "memoryleakfix-forge-1.17+-1.1.2",
                        "KryptonReforged-0.2.3",
                        "Fastload-Reforged-mc1.20.1-3.4.0",
                        "betterfpsdist-1.20.1-4.1",
                        "alternate_current-mc1.20-1.7.0",
                    },
                },
            },
            ["Fabric"] = new Dictionary<string, Dictionary<string, List<string>>>()
            {
                ["1.19.2"] = new Dictionary<string, List<string>>()
                {
                    ["Preference Mods"] = new List<string>()
                    {

                    },
                    ["Performance Mods"] = new List<string>()
                    {

                    },
                },
                ["1.20.1"] = new Dictionary<string, List<string>>()
                {
                    ["Preference Mods"] = new List<string>()
                    {

                    },
                    ["Performance Mods"] = new List<string>()
                    {

                    },
                },
            },
        };
    }
}
