using Elin.Plugin.Main.PluginHelpers;
using System.Reflection;

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

            var assembly = Assembly.GetExecutingAssembly();
            ModHelper.LogDev($"assembly = {assembly}");

        }

        #endregion
    }
}
