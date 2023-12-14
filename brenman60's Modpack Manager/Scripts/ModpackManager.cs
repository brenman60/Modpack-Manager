using System;
using System.Collections.Generic;
using System.Text;

namespace brenman60_s_Modpack_Manager.Scripts
{
    public static class ModpackManager
    {
        public List<Dictionary<string, string>> modpacks = new List<Dictionary<string, string>>()
        {
            // Example modpack formatting
            new Dictionary<string, string>()
            {
                ["name"] = "Example Modpack",
                ["loader"] = "Forge",
                ["version"] = "1.20.1",
                ["mods"] = "{}",
            },
        };
    }
}
