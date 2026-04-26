using Elin.Plugin.Main.PluginHelpers;

namespace Elin.Plugin.Main.Models.Impl
{
    public static class CoreConfigImpl
    {
        #region function

        public static void ApplyResolutionPostfix(CoreConfig instance)
        {
            if (Screen.fullScreen)
            {
                return;
            }

            if (!instance.graphic.fixedResolution)
            {
                return;
            }

            ModHelper.LogDev("固定処理");

        }

        #endregion
    }
}
