using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ResearchWindowGenerator
{
    /// <summary>
    /// ResearchWindowTest.xaml の相互作用ロジック
    /// </summary>
    public partial class ResearchWindowTest : Window
    {
        private Timer _timer = null;
        static double TimeCount = 0.0;
        static bool LogFlag;

        string filePath;
        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];

        LogDrawing_Canvas logdrawing;

        public ResearchWindowTest(string file_name, bool log_flag)
        {
            LogFlag = log_flag;
            filePath = file_name;
            InitializeComponent();
            
            // タイトルバーとの境界線を表示しない
            //this.WindowStyle = WindowStyle.None;
            //this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            Window researchwindowtest = this.FindName("researchWindowTest") as Window;
            researchwindowtest.WindowState = WindowState.Maximized;
            researchwindowtest.Width  = Screen.PrimaryScreen.WorkingArea.Width;
            researchwindowtest.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Console.WriteLine("//==============================================");
            Console.WriteLine(Width);
            Console.WriteLine(Height);
            DoEvents();

            StackPanel myStackPanel = this.FindName("myStackPanel") as StackPanel;
            myStackPanel.Height = researchwindowtest.Height;
            myStackPanel.Width = researchwindowtest.Width;
            
            

            //TODO : マウスカーソルをウィンドウ外に出ないように固定する
            //InitializeCursor();

            //TODO : マウスカーソルの座標位置のログを取得できるようにする
            if(log_flag == false)
            {
                Logger.LoggerInitialize("ResarchWindowTest");
                /*
                Logger.SaveMouseCursorPosition();
                */
                StartTimer();
            }
            
            



            if (log_flag == true)
            {
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
            }

        }

        //https://moewe-net.com/csharp/forms-timer
        private void StartTimer()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TickHandler);
            timer.Interval = 20;
            timer.Start();
            _timer = timer;
        }

        private void StopTimer()
        {
            if (_timer == null)
            {
                return;
            }
            _timer.Stop();
            _timer = null;
        }

        private void TickHandler(object sender, EventArgs e)
        {

            //Console.WriteLine(DateTime.Now.ToString());
            //マウスカーソルの座標を取得
            System.Drawing.Point p = System.Windows.Forms.Control.MousePosition;
            TimeCount += 0.02;
            Logger.SaveMouseCursorPosition(TimeCount,p.X, p.Y);
        }

        /*
        public void InitializeCursor() {
            Console.WriteLine(this.Height +":"+ this.Width);
            System.Windows.Forms.Cursor.Clip = new System.Drawing.Rectangle(0,0,(int)this.Width,(int)this.Height);
        }*/

        private void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            var callback = new DispatcherOperationCallback(obj =>
            {
                ((DispatcherFrame)obj).Continue = false;
                return null;
            });
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, callback, frame);
            Dispatcher.PushFrame(frame);
        }

        private void Generate_subWindow()
        {
            LogControler logControler = new LogControler();
            logControler.Topmost = true;
            logControler.Show();

        }

    }
}
