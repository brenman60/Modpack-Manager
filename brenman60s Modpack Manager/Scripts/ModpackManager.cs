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
                ["version"] = "1.19.2",
                ["modpackName"] = "None",
                ["description"] = "No modpack.",
                ["mods"] = new List<string>(),
            },
            new Dictionary<string, object>()
            {
                ["id"] = "modpack1_1",
                ["loader"] = "Forge",
                ["version"] = "1.20.1",
                ["modpackName"] = "None",
                ["description"] = "No modpack.",
                ["mods"] = new List<string>(),
            },
            new Dictionary<string, object>()
            {
                ["id"] = "modpack1_2",
                ["loader"] = "Fabric",
                ["version"] = "1.19.2",
                ["modpackName"] = "None",
                ["description"] = "No modpack.",
                ["mods"] = new List<string>(),
            },
            new Dictionary<string, object>()
            {
                ["id"] = "modpack1_3",
                ["loader"] = "Fabric",
                ["version"] = "1.20.1",
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
            new Dictionary<string, object>()
            {
                ["id"] = "modpack3",
                ["loader"] = "Forge",
                ["version"] = "1.20.1",
                ["modpackName"] = "brenman60's Create Modpack 2",
                ["description"] = "A modpack containing the create mod, create mod addons, dimension mods, and additional content mods for 1.20.1",
                ["mods"] = new List<string>()
                {
                    "1.20.1-create_oppenheimered-1.0.0",
                    "alexscaves-1.0.9",
                    "architectury-9.1.12-forge",
                    "BetterAdvancements-1.20.1-0.3.2.161",
                    "cccbridge-mc1.20.1-forge-1.6.3",
                    "cc-tweaked-1.20.1-forge-1.108.4",
                    "citadel-2.4.9-1.20.1",
                    "collective-1.20.1-7.15",
                    "coroutil-1.20.1-1.3.3",
                    "Create Sweets And Treats 1.1",
                    "create_enchantment_industry-1.20.1-for-create-0.5.1.f-1.2.7.g",
                    "create_mechanical_spawner-1.20.1-0.0.14.e-22",
                    "create_misc_and_things_+1.20.1_4.0A",
                    "create_power_loader-1.2.2-mc1.20.1",
                    "create-1.20.1-0.5.1.f",
                    "createaddition-1.20.1-1.2.1",
                    "createbb-1.20.1-3.1.2",
                    "createbigcannons-forge-1.20.1-0.5.3",
                    "CreateCasing-1.20.1-1.5.0-ht3",
                    "create-chromaticreturn1.20.1_v1.4.2",
                    "createchunkloading-1.6.0-forge",
                    "create-confectionery1.20.1_v1.1.0",
                    "creategoggles-1.20.1-0.5.5.e_hf-[FORGE]",
                    "Create-Guardian-Beam-Defense-1.2.9.1b-1.20.1",
                    "create-stuff-additions1.20.1_v2.0.4a",
                    "cristellib-1.1.5-forge",
                    "cupboard-1.20.1-2.1",
                    "curios-forge-5.4.5+1.20.1",
                    "deeperdarker-forge-1.20.1-1.2.1",
                    "design_decor-0.2a-1.20.1",
                    "FarmersDelight-1.20.1-1.2.3",
                    "immersive_paintings-0.6.7+1.20.1-forge",
                    "interiors-0.5.2+mc1.20.1-FORGE",
                    "kotlinforforge-4.8.0-all",
                    "NaturesCompass-1.20.1-1.11.2-forge",
                    "nethersdelight-1.20.1-4.0",
                    "nocube's_create_compact_exp_1.0.3_forge_1.20.1",
                    "PoweredLightningRod1.1.0",
                    "sliceanddice-forge-3.2.0",
                    "snowundertrees-1.20.1-1.4.2",
                    "sophisticatedbackpacks-1.20.1-3.18.68.952",
                    "sophisticatedcore-1.20.1-0.5.107.496",
                    "Steam_Rails-1.5.3+forge-mc1.20.1",
                    "twilightforest-1.20.1-4.3.1893-universal",
                    "YungsApi-1.20-Forge-4.0.2",
                    "YungsBetterDesertTemples-1.20-Forge-3.0.3",
                    "YungsBetterDungeons-1.20-Forge-4.0.3",
                    "YungsBetterEndIsland-1.20-Forge-2.0.4",
                    "YungsBetterJungleTemples-1.20-Forge-2.0.4",
                    "YungsBetterMineshafts-1.20-Forge-4.0.4",
                    "YungsBetterNetherFortresses-1.20-Forge-2.0.5",
                    "YungsBetterOceanMonuments-1.20-Forge-3.0.3",
                    "YungsBetterStrongholds-1.20-Forge-4.0.3",
                    "YungsBetterWitchHuts-1.20-Forge-3.0.3",
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
