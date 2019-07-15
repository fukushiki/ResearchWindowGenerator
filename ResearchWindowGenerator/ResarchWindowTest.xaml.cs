using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;

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
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            this.WindowState = WindowState.Maximized;

            //TODO : マウスカーソルをウィンドウ外に出ないように固定する
            InitializeCursor();

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
            timer.Interval = 250;
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
            int x = System.Windows.Forms.Cursor.Position.X;
            int y = System.Windows.Forms.Cursor.Position.Y;
            //Console.WriteLine(TimeCount + "," + x + "," + y);
            TimeCount += 0.25;
            Logger.SaveMouseCursorPosition(TimeCount, x, y);


        }


        public void InitializeCursor() {
            Console.WriteLine(this.Height +":"+ this.Width);
            System.Windows.Forms.Cursor.Clip = new System.Drawing.Rectangle(0,0,(int)this.Width,(int)this.Height);
        }

    }
}
