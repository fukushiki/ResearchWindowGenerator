using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ResearchWindowGenerator
{
    
    internal class Initialize
    {
        static int screenWidth;
        static int screenHeight;
        internal static void InitializeDesktopInfo()
        {
            Rectangle workingRectangle =
                Screen.PrimaryScreen.WorkingArea;
            //Screen.PrimaryScreen Property
            screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //TODO : SettingFileを生成できるようにして一度きりの保存にする

        }
    }
}