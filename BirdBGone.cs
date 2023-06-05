using BepInEx;

using HarmonyLib;

using System.Reflection;

using static BirdBGone.PluginConfig;

namespace BirdBGone
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class BirdBGone : BaseUnityPlugin
    {
        public const string PluginGuid = "EardwulfC.BirdBGone";
        public const string PluginName = "BirdBGone";
        public const string PluginVersion = "1.2.0";

        Harmony _harmony;

        public void Awake()
        {
            _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), harmonyInstanceId: PluginGuid);
            BindConfig(Config);
        }

        [HarmonyPatch(typeof(Player))]
        static class ValkyrieBGone {
            [HarmonyPrefix]
            [HarmonyPatch(nameof(Player.OnSpawned))]
            static void OnSpawnedPrefix(ref Player __instance)
            {
                if (IsModEnabled.Value && SkipValkyrieEnabled.Value)
                {
                    __instance.m_firstSpawn = false;
                }
            }
        }

        public void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }
    }
}