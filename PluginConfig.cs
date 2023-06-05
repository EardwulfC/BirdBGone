using BepInEx.Configuration;


namespace BirdBGone
{
    public class PluginConfig
    {
        public static ConfigEntry<bool> IsModEnabled { get; private set; }
        public static ConfigEntry<bool> SkipValkyrieEnabled { get; private set; }
        public static void BindConfig(ConfigFile config)
        {
            IsModEnabled = config.Bind("Global", "isModEnabled", true, "Globally enable or disable this mod.");
            SkipValkyrieEnabled = config.Bind("Player", "isValkyrieDisabled", true, "Enable or Disable skipping the Intro on first login");
        }
    }
}