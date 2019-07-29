using System;
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
    /// ResarchWindowTest.xaml の相互作用ロジック
    /// </summary>
    public partial class ResarchWindowTest : Window
    {
        private Timer _timer = null;
        static double TimeCount = 0.0;
        public ResarchWindowTest()
        {
            InitializeComponent();
            // タイトルバーとの境界線を表示しない
            //this.WindowStyle = WindowStyle.None;
            //this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            Window researchwindowtest = this.FindName("ResearchWindowTest") as Window;
            researchwindowtest.WindowState = WindowState.Maximized;
            researchwindowtest.Width  = Screen.PrimaryScreen.WorkingArea.Width;
            researchwindowtest.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Console.WriteLine("//==============================================");
            Console.WriteLine(Width);
            Console.WriteLine(Height);
            DoEvents();

            StackPanel myStackPanel = this.FindName("myStackPanel") as StackPanel;
            myStackPanel.Height = researchwindowtest.Height - 30;
            myStackPanel.Width = researchwindowtest.Width;
            
            

            //TODO : マウスカーソルをウィンドウ外に出ないように固定する
            //InitializeCursor();

            //TODO : マウスカーソルの座標位置のログを取得できるようにする
            
            Logger.LoggerInitialize("ResarchWindowText");
            /*
            Logger.SaveMouseCursorPosition();
            */
            StartTimer();

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
    }
}
