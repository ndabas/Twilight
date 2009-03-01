using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        static List<WindowInfo> windowList;

        static bool EnumWindowsCallback(IntPtr hWnd, int lParam)
        {
            if (hWnd == IntPtr.Zero)
            {
                return true;
            }

            if (!IsWindowVisible(hWnd))
            {
                return true;
            }

            int length;

            StringBuilder caption = new StringBuilder(1024);
            length = GetWindowText(hWnd, caption, caption.Capacity);
            caption.Length = length;

            if (caption.ToString().Trim().Length == 0)
            {
                return true;
            }

            StringBuilder className = new StringBuilder(256);
            length = GetClassName(hWnd, className, className.Capacity);
            className.Length = length;

            WindowInfo info = new WindowInfo();
            info.Handle = hWnd;
            info.Caption = caption.ToString();
            info.ClassName = className.ToString();

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
            PostMessage(hWnd, 0x0010 /* WM_CLOSE */, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
