namespace brenman60_s_Modpack_Manager.Scripts
{
    public static class Mods
    {
        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> directDownloads = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>()
        {
            ["Forge"] = new Dictionary<string, Dictionary<string, string>>()
            {
                ["1.19.2"] = new Dictionary<string, string>()
                {
                    ["create-1.19.2-0.5.1.c"] = "https://www.curseforge.com/api/v1/mods/328085/files/4625534/download",
                    ["createaddition-1.19.2-1.0.0"] = "https://www.curseforge.com/api/v1/mods/439890/files/4683731/download",
                    ["createbigcannons-forge-1.19.2-0.5.2"] = "https://www.curseforge.com/api/v1/mods/646668/files/4712327/download",
                    ["create-chromaticreturn1.19.2_v1.4.2"] = "https://www.curseforge.com/api/v1/mods/503784/files/4559497/download",
                    ["create-stuff-additions1.19.2_v2.0.4a"] = "https://www.curseforge.com/api/v1/mods/466792/files/4703283/download",
                    ["createbb-1.19.2-2.3.2"] = "https://www.curseforge.com/api/v1/mods/635620/files/4733930/download",
                    ["createchunkloading-1.5.0-forge"] = "https://www.curseforge.com/api/v1/mods/494206/files/4606118/download",
                    ["alloyed-1.19.2-v1.5a"] = "https://www.curseforge.com/api/v1/mods/564792/files/4591571/download",
                    ["alloyedguns-1.1.0-1.19.2"] = "https://www.curseforge.com/api/v1/mods/757052/files/4722487/download",
                    ["cc-tweaked-1.19.2-1.101.3"] = "https://www.curseforge.com/api/v1/mods/282001/files/4630524/download",
                    ["cccbridge-mc1.19.2-forge-v1.5.1"] = "https://www.curseforge.com/api/v1/mods/656214/files/4632363/download",
                    ["Steam_Rails-1.5.1+forge-mc1.19.2"] = "https://www.curseforge.com/api/v1/mods/688231/files/4746992/download",
                    ["cgm-forge-1.19.2-1.3.7"] = "https://www.curseforge.com/api/v1/mods/289479/files/4718583/download",
                    ["FarmersDelight-1.19.2-1.2.3"] = "https://www.curseforge.com/api/v1/mods/398521/files/4679318/download",
                    ["catalogue-1.7.0-1.19.2"] = "https://www.curseforge.com/api/v1/mods/459701/files/4171024/download",
                    ["architectury-6.5.85-forge"] = "https://www.curseforge.com/api/v1/mods/419699/files/4555749/download",
                    ["cloth-config-8.3.103-forge"] = "https://www.curseforge.com/api/v1/mods/348521/files/4633416/download",
                    ["collective-1.19.2-6.65"] = "https://www.curseforge.com/api/v1/mods/342584/files/4639340/download",
                    ["curios-forge-1.19.2-5.1.4.1"] = "https://www.curseforge.com/api/v1/mods/309927/files/4523009/download",
                    ["framework-forge-1.19.2-0.6.16"] = "https://www.curseforge.com/api/v1/mods/549225/files/4718247/download",

                    // Preference mods
                    ["entityculling-forge-1.6.1-mc1.19.2"] = "https://www.curseforge.com/api/v1/mods/448233/files/4404949/download",
                    ["fullbrightnesstoggle-1.19.2-3.0"] = "https://www.curseforge.com/api/v1/mods/391656/files/4327370/download",
                    ["jei-1.19.2-forge-11.6.0.1018"] = "https://www.curseforge.com/api/v1/mods/238222/files/4712866/download",
                    ["oculus-flywheel-compat-1.19.2-0.2.1"] = "https://www.curseforge.com/api/v1/mods/659897/files/4631185/download",
                    ["oculus-mc1.19.2-1.6.4"] = "https://www.curseforge.com/api/v1/mods/581495/files/4578731/download",
                    ["rubidium-0.6.2b"] = "https://www.curseforge.com/api/v1/mods/574856/files/4568727/download",
                    ["starlight-1.1.1+forge.cf5b10b"] = "https://www.curseforge.com/api/v1/mods/526854/files/3836016/download",
                },
                ["1.20.1"] = new Dictionary<string, string>()
                {

                },
            },
            ["Fabric"] = new Dictionary<string, Dictionary<string, string>>()
            {

            }
        };

        public static Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> modSettingsInfo = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>()
        {
            ["Forge"] = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>()
            {
                ["1.19.2"] = new Dictionary<string, Dictionary<string, string>>()
                {
                    ["entityculling-forge-1.6.1-mc1.19.2"] = new Dictionary<string, string>()
                    {
                        ["modName"] = "Entity Culling",
                    },
                    ["fullbrightnesstoggle-1.19.2-3.0"] = new Dictionary<string, string>()
                    {
                        ["modName"] = "Full Brightness Toggle",
                    },
                    ["jei-1.19.2-forge-11.6.0.1018"] = new Dictionary<string, string>()
                    {
                        ["modName"] = "Just Enough Items",
                    },
                    ["oculus-flywheel-compat-1.19.2-0.2.1"] = new Dictionary<string, string>()
                    {
                        ["modName"] = "Oculus Flywheel Compat",
                    },
                    ["oculus-mc1.19.2-1.6.4"] = new Dictionary<string, string>()
                    {
                        ["modName"] = "Oculus",
                    },
                    ["rubidium-0.6.2b"] = new Dictionary<string, string>()
                    {
                        ["modName"] = "Rubidium",
                    },
                    ["starlight-1.1.1+forge.cf5b10b"] = new Dictionary<string, string>()
                    {
                        ["modName"] = "Starlight",
                    },
                },
                ["1.20.1"] = new Dictionary<string, Dictionary<string, string>>()
                {

                },
            },
            ["Fabric"] = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>()
            {
                ["1.19.2"] = new Dictionary<string, Dictionary<string, string>>()
                {

                },
                ["1.20.1"] = new Dictionary<string, Dictionary<string, string>>()
                {

                },
            },
        };
    }
}
