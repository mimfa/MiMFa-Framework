using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MiMFa_Framework.General
{
    public class MiMFa_Process
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;

        public static void OpenWithPicturePreview(Image image, string tempAddress)
        {
            if (File.Exists(tempAddress)) File.Delete(tempAddress);
            image.Save(tempAddress);
            Process.Start(tempAddress);
        }
        public static void Run(string address)
        {
            try { Process.Start(address); } catch { }
        }
        public static void RunTopMost(string address)
        {
            if (File.Exists(address))
            {
                Process p = new Process();
                p.StartInfo.FileName =address;
                p.Start();
                SetTopMost(p);
            }
        }
        public static void SetTopMost(Process p)
        {
            SetWindowPos(p.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }
    }
}
