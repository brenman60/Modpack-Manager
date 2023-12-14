namespace brenman60_s_Modpack_Manager.Scripts
{
    public class ModManager
    {
        // Dictionary that contains the currently selected loader, modpack, and mod settings that will be used later
        public static Dictionary<string, string> settings = new Dictionary<string, string>()
        {

        };

        public void ReloadMods()
        {
            ClearMods();
            PlaceModpackMods();
            PlaceSettingMods();
        }

        private void ClearMods()
        {
            // Delete or move all the current mods in the mods folder
        }

        private void PlaceModpackMods()
        {
            // Copy the mods from the currently selected modpack into the mods folder
        }

        private void PlaceSettingMods()
        {
            // Copy the mods enabled in the settings into the mods folder
        }
    }
}

public enum Loader
{
    Forge,
    Fabric,
}