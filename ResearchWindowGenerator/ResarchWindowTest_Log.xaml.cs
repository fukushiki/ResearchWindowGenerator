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
        string filePath;
        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];

        LogDrawing_Canvas logdrawing;

        public ResarchWindowTest_Log(string _filePath)
        {
            filePath = _filePath;
            InitializeComponent();
            Window researchwindowtestlog = this.FindName("ResearchWindowTestLog") as Window;
            //researchwindowtestlog.WindowState = WindowState.Maximized;
            researchwindowtestlog.Width = Screen.PrimaryScreen.WorkingArea.Width;
            researchwindowtestlog.Height = Screen.PrimaryScreen.WorkingArea.Height;
            researchwindowtestlog.WindowStyle = WindowStyle.SingleBorderWindow;
            //researchwindowtestlog.WindowState = WindowState.Maximized;
            /*
            // タイトルバーとの境界線を表示しない
            this.WindowStyle = WindowStyle.None;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            this.WindowState = WindowState.Maximized;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            */
            StackPanel myStackPanel = this.FindName("myStackPanel") as StackPanel;
            myStackPanel.Height = researchwindowtestlog.Height - 30;
            myStackPanel.Width = researchwindowtestlog.Width;

            Console.WriteLine("WindowHeight:" + researchwindowtestlog.Height + " StackPanelHeight:" + myStackPanel.Height);



            //FilePass

            //logdrawing.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //logdrawing.Width = Screen.PrimaryScreen.WorkingArea.Width;
            //logdrawing.Height = this.Height;
            //logdrawing.Width = this.Width;

            logdrawing = new LogDrawing_Canvas
            {
                Height = myStackPanel.Height,
                Width = myStackPanel.Width,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Margin = new Thickness(0, 0, 0, 0),
            };
            //logdrawing.logDrawing_Canvas.Background = Brushes.Aquamarine;
            //logdrawing.logDrawing_Canvas.Background = Brushes.Gray;
            //logdrawing.logDrawing_Canvas.Opacity = 0.1;
            //Console.WriteLine("logdrawing : Height=" + logdrawing.Height);
            //Console.WriteLine("logdrawing : Width=" + logdrawing.Width);

            myStackPanel.Children.Add(logdrawing);


            logdrawing.setFilePath(filePath);


            Generate_subWindow();
            //サブウィンドウの生成
            
        }

        private void Generate_subWindow()
        {
            LogControler logControler = new LogControler();
            logControler.Topmost = true;
            logControler.Show();

        }
    }
}
