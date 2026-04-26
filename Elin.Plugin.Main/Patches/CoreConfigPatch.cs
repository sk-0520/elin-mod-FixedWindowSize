using Elin.Plugin.Main.Models.Impl;
using HarmonyLib;

namespace Elin.Plugin.Main.Patches
{
    [HarmonyPatch(typeof(CoreConfig))]
    public class CoreConfigPatch
    {
        #region function

        [HarmonyPatch(nameof(CoreConfig.ApplyResolution))]
        public static void ApplyResolutionPostfix(CoreConfig __instance)
        {
            CoreConfigImpl.ApplyResolutionPostfix(__instance);
        }


        #endregion
    }
}
