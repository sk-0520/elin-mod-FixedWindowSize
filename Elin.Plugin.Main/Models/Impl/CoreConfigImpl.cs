using Elin.Plugin.Main.PluginHelpers;
using static Elin.Plugin.Main.Models.ExternalApi;

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

            // 多分 Unity で動いてる Elin のプロセスを取得
            var process = System.Diagnostics.Process.GetCurrentProcess();
            if (process is null)
            {
                ModHelper.LogNotExpected("Failed to get the current process.");
                return;
            }

            var hWnd = process.MainWindowHandle;
            var currentWindowStyle = ExternalApi.GetWindowLongPtr(hWnd, (int)GWL.GWL_STYLE);
        }

        #endregion
    }
}
