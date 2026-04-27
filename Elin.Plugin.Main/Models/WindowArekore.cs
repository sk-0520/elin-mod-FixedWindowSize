using Elin.Plugin.Main.PluginHelpers;
using System.Diagnostics;

namespace Elin.Plugin.Main.Models
{
    public class WindowArekore
    {
        #region function

        private void ChangeWindowStyleWindows(Process process, bool fixedResolution)
        {
            var hWnd = process.MainWindowHandle;
            var currentWindowStyle = ExternalApi.GetWindowLongPtr(hWnd, (int)ExternalApi.GWL.GWL_STYLE);

            ModHelper.LogDev($"{nameof(currentWindowStyle)}: {currentWindowStyle:x}");

            var newWindowStyle = currentWindowStyle;

            // この Mod で付け外しするスタイル
            var modStyle = (int)ExternalApi.WS.WS_MAXIMIZEBOX | (int)ExternalApi.WS.WS_THICKFRAME;
            if (fixedResolution)
            {
                newWindowStyle &= ~modStyle;
            }
            else
            {
                newWindowStyle |= modStyle;
            }
            ModHelper.LogDev($"{nameof(newWindowStyle)}: {newWindowStyle:x}");

            ExternalApi.SetWindowLongPtr(hWnd, (int)ExternalApi.GWL.GWL_STYLE, newWindowStyle);
        }

        public void ChangeWindowStyle(bool fullScreen, bool fixedResolution)
        {
            // フルスクリーンは何もしなくてもいいやと思ったけど、ここで return すると面倒だったので無差別処理
            //if (fullScreen)
            //{
            //    ModHelper.LogDev("フルスクリーン処理");
            //    return;
            //}

            ModHelper.LogDev("固定処理");

            // 多分 Unity で動いてる Elin のプロセスを取得
            var process = Process.GetCurrentProcess();
            if (process is null)
            {
                ModHelper.LogNotExpected("Failed to get the current process.");
                return;
            }

            ChangeWindowStyleWindows(process, fixedResolution);
        }

        #endregion
    }
}
