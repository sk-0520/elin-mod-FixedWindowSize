using Elin.Plugin.Main.Models.Impl;
using HarmonyLib;

namespace Elin.Plugin.Main.Patches
{
    [HarmonyPatch(typeof(CoreConfig))]
    public static class CoreConfigPatch
    {
        #region function

        [HarmonyPatch(nameof(CoreConfig.ApplyResolution), new[] { typeof(bool) })]
        [HarmonyPostfix]
        public static void ApplyResolutionPostfix(CoreConfig __instance)
        {
            CoreConfigImpl.ApplyResolutionPostfix(__instance);
        }

        #endregion
    }
}
