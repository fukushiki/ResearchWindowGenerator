using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace ResearchWindowGenerator
{
    /// <summary>
    /// ResarchWindowTest.xaml の相互作用ロジック
    /// </summary>
    public partial class ResarchWindowTest_Log : Window
    {
        //private Timer _timer = null;
        /*
        static double TimeCount = 0.0;
        static int drawCount = 0;
        static int MAXCOLUMN;
        */

        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];

        public ResarchWindowTest_Log()
        {


            InitializeComponent();
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            this.WindowState = WindowState.Maximized;
            /*
            UserControl1.CsvReader(csvPath);
            UserControl1.DrawLogLine();
            */
            
        }

        
    }
}
