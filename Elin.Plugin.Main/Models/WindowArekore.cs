using Elin.Plugin.Main.PluginHelpers;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Elin.Plugin.Main.Models
{
    /// <summary>
    /// あれこれ！
    /// </summary>
    /// <remarks>名前が思いつかなかった。</remarks>
    public class WindowArekore
    {
        #region function

        private void ChangeWindowStyleInWindows(Process process, bool fixedResolution)
        {
            var hWnd = process.MainWindowHandle;
            var currentWindowStyle = ExternalApi.GetWindowLongPtr(hWnd, (int)ExternalApi.Windows.GWL.GWL_STYLE);

            ModHelper.LogDev($"{nameof(currentWindowStyle)}: {currentWindowStyle:x}");

            var newWindowStyle = currentWindowStyle;

            // この Mod で付け外しするスタイル
            var modStyle = (int)ExternalApi.Windows.WS.WS_MAXIMIZEBOX | (int)ExternalApi.Windows.WS.WS_THICKFRAME;
            if (fixedResolution)
            {
                newWindowStyle &= ~modStyle;
            }
            else
            {
                newWindowStyle |= modStyle;
            }
            ModHelper.LogDev($"{nameof(newWindowStyle)}: {newWindowStyle:x}");

            ExternalApi.SetWindowLongPtr(hWnd, (int)ExternalApi.Windows.GWL.GWL_STYLE, newWindowStyle);
        }

        public void ChangeWindowStyle(bool fullScreen, bool fixedResolution)
        {
            //TODO: フルスクリーン処理の Screen に対するあれやこれやが甘い。実運用上まぁ問題ないかなって気持ちもある

            ModHelper.LogDev("固定処理");

            // 多分 Unity で動いてる Elin のプロセスを取得
            var process = Process.GetCurrentProcess();
            if (process is null)
            {
                ModHelper.LogNotExpected("Failed to get the current process.");
                return;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ChangeWindowStyleInWindows(process, fixedResolution);
            }
            else
            {
                ModHelper.LogNotExpected($"windows only: {RuntimeInformation.OSDescription}");
            }
        }

        #endregion
    }
}
