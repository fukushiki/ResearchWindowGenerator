using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ResearchWindowGenerator
{
    class Utility
    {
        private Timer _timer = null;
        static double TimeCount = 0.0;
        
        static void DoEvents()
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

        //https://moewe-net.com/csharp/forms-timer
        private void StartTimer()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TickHandler);
            //timer.Interval = 20;
            timer.Interval = 50;
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
            //マウスカーソルの座標を取得
            System.Drawing.Point p = System.Windows.Forms.Control.MousePosition;
            TimeCount += 0.05;
            Logger.SaveMouseCursorPosition(TimeCount, p.X, p.Y);
        }

        internal static int[] RamdomArray(int[] ary)
        {
            //return ary.OrderBy(i => Guid.NewGuid()).ToArray();
            System.Random rng = new System.Random();
            int n = ary.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int tmp = ary[k];
                ary[k] = ary[n];
                ary[n] = tmp;
            }

            return ary;
        }
    }
}
