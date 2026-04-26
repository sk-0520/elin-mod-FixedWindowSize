using System;
using System.Runtime.InteropServices;

namespace Elin.Plugin.Main.Models
{
    partial class SystemCall
    {
        #region define

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Security.SuppressUnmanagedCodeSecurity]
        internal static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Security.SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr GetWindowLong64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Security.SuppressUnmanagedCodeSecurity]
        internal static extern int SetWindowLong32(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Security.SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr SetWindowLong64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        #endregion

        #region function

        /// <summary>
        /// <c>GetWindowLongPtr/GetWindowLong</c>(<see cref="SetWindowLongPtr(nint, int, nint)"/>) のプラットフォーム吸収処理。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public static nint GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (Environment.Is64BitProcess)
            {
                return GetWindowLong64(hWnd, nIndex);
            }

            return GetWindowLong32(hWnd, nIndex);
        }

        /// <summary>
        /// <c>SetWindowLongPtr/SetWindowLong</c>(<see cref="SetWindowLongPtr(nint, int, nint)"/>) のプラットフォーム吸収処理。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        /// <exception cref="System.ComponentModel.Win32Exception"></exception>
        public static nint SetWindowLongPtr(IntPtr hWnd, int nIndex, nint dwNewLong)
        {
            int error = 0;
            var result = IntPtr.Zero;

            if (Environment.Is64BitProcess)
            {
                result = SetWindowLong64(hWnd, nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }
            else
            {
                var tempResult = SetWindowLong32(hWnd, nIndex, (uint)dwNewLong);
                error = Marshal.GetLastWin32Error();
                result = new IntPtr(tempResult);
            }

            if ((result == IntPtr.Zero) && (error != 0))
            {
                throw new System.ComponentModel.Win32Exception(error);
            }

            return result;
        }

        #endregion
    }
}
