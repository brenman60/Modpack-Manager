using System;
using System.Collections.Generic;
using System.Text;

namespace brenman60_s_Modpack_Manager.Scripts
{
    public static class ModpackManager
    {
        public static List<Dictionary<string, object>> modpacks = new List<Dictionary<string, object>>()
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
    }
}
