using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Twilight
{
    class Windows
    {
        delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("user32.dll")]
        static extern int EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        static readonly int WS_CAPTION = 0x00C00000;
        static readonly uint WM_CLOSE = 0x0010;
        static readonly int GWL_STYLE =(-16);

        static List<WindowInfo> windowList;

        static bool EnumWindowsCallback(IntPtr hWnd, int lParam)
        {
            if (hWnd == IntPtr.Zero)
            {
                return true;
            }

            // Can't see it, skip it.
            if (!IsWindowVisible(hWnd))
            {
                return true;
            }

            // No title bar, skip it.
            if ((GetWindowLong(hWnd, GWL_STYLE) & WS_CAPTION) == 0)
            {
                return true;
            }

            int length;

            StringBuilder caption = new StringBuilder(1024);
            length = GetWindowText(hWnd, caption, caption.Capacity);
            caption.Length = length;

            // Empty title, skip it.
            if (caption.ToString().Trim().Length == 0)
            {
                return true;
            }

            StringBuilder className = new StringBuilder(256);
            length = GetClassName(hWnd, className, className.Capacity);
            className.Length = length;

            int processId;
            GetWindowThreadProcessId(hWnd, out processId);
            Process process = Process.GetProcessById(processId);

            WindowInfo info = new WindowInfo();
            info.Handle = hWnd;
            info.Caption = caption.ToString();
            info.ClassName = className.ToString();
            info.ModuleFileName = process.MainModule.FileName;
            info.Description = process.MainModule.FileVersionInfo.FileDescription;
            if (String.IsNullOrEmpty(info.Description))
            {
                info.Description = process.MainModule.FileVersionInfo.ProductName;
            }
            if (String.IsNullOrEmpty(info.Description))
            {
                info.Description = process.MainModule.ModuleName;
            }

            windowList.Add(info);

            return true;
        }

        public static List<WindowInfo> GetWindows()
        {
            windowList = new List<WindowInfo>();
            EnumWindows(EnumWindowsCallback, IntPtr.Zero);
            return windowList;
        }

        public static void CloseWindow(IntPtr hWnd)
        {
            PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        public static bool WindowExists(IntPtr hWnd)
        {
            return IsWindow(hWnd);
        }
    }
}
