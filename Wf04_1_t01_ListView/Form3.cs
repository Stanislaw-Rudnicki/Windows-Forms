﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Wf04_1_t01
{
    public partial class Form3 : Form
    {
        public enum SHSTOCKICONID : uint
        {
            //...
            SIID_WARNING = 78,
            SIID_INFO = 79,
            SIID_DELETE = 84,
            //...
        }

        [Flags]
        public enum SHGSI : uint
        {
            SHGSI_ICONLOCATION = 0,
            SHGSI_ICON = 0x000000100,
            SHGSI_SYSICONINDEX = 0x000004000,
            SHGSI_LINKOVERLAY = 0x000008000,
            SHGSI_SELECTED = 0x000010000,
            SHGSI_LARGEICON = 0x000000000,
            SHGSI_SMALLICON = 0x000000001,
            SHGSI_SHELLICONSIZE = 0x000000004
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHSTOCKICONINFO
        {
            public UInt32 cbSize;
            public IntPtr hIcon;
            public Int32 iSysIconIndex;
            public Int32 iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260/*MAX_PATH*/)]
            public string szPath;
        }

        [DllImport("Shell32.dll", SetLastError = false)]
        public static extern Int32 SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        public Form3()
        {
            InitializeComponent();

            SHSTOCKICONINFO sii = new SHSTOCKICONINFO();
            sii.cbSize = (UInt32)Marshal.SizeOf(typeof(SHSTOCKICONINFO));

            Marshal.ThrowExceptionForHR(SHGetStockIconInfo(SHSTOCKICONID.SIID_WARNING,
                    SHGSI.SHGSI_ICON | SHGSI.SHGSI_LARGEICON | SHGSI.SHGSI_SHELLICONSIZE,
                    ref sii));

            pictureBox1.Image = Icon.FromHandle(sii.hIcon).ToBitmap();
            buttonNo.Select();
        }
    }
}
