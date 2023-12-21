namespace brenman60_s_Modpack_Manager.Scripts
{
    public static class ModpackManager
    {
        public static List<Dictionary<string, object>> modpacks = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>()
            {
                ["id"] = "modpack1",
                ["loader"] = "Forge",
                ["version"] = "",
                ["modpackName"] = "None",
                ["description"] = "No modpack.",
                ["mods"] = new List<string>(),
            },
            new Dictionary<string, object>()
            {
                ["id"] = "modpack2",
                ["loader"] = "Forge",
                ["version"] = "1.19.2",
                ["modpackName"] = "brenman60's Create Modpack 1",
                ["description"] = "A Modpack containing the Create mod, as well as many other Create mod addons for 1.19.2.",
                ["mods"] = new List<string>()
                {
                    "alloyed-1.19.2-v1.5a",
                    "alloyedguns-1.1.0-1.19.2",
                    "architectury-6.5.85-forge",
                    "catalogue-1.7.0-1.19.2",
                    "cccbridge-mc1.19.2-forge-v1.5.1",
                    "cc-tweaked-1.19.2-1.101.3",
                    "cgm-forge-1.19.2-1.3.7",
                    "cloth-config-8.3.103-forge",
                    "collective-1.19.2-6.65",
                    "create-1.19.2-0.5.1.c",
                    "createaddition-1.19.2-1.0.0",
                    "createbb-1.19.2-2.3.2",
                    "createbigcannons-forge-1.19.2-0.5.2",
                    "create-chromaticreturn1.19.2_v1.4.2",
                    "createchunkloading-1.5.0-forge",
                    "create-stuff-additions1.19.2_v2.0.4a",
                    "curios-forge-1.19.2-5.1.4.1",
                    "FarmersDelight-1.19.2-1.2.3",
                    "framework-forge-1.19.2-0.6.16",
                    "Steam_Rails-1.5.1+forge-mc1.19.2"
                },
            },
        };

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
                    },
                    ["Performance Mods"] = new List<string>()
                    {
                        "rubidium-0.6.2b",
                        "entityculling-forge-1.6.1-mc1.19.2",
                        "starlight-1.1.1+forge.cf5b10b",
                        "oculus-mc1.19.2-1.6.4",
                        "oculus-flywheel-compat-1.19.2-0.2.1"
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
