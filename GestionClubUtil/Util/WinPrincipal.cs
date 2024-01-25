using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GestionClubUtil.Util
{
    public class WinPrincipal
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern uint ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern uint SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
