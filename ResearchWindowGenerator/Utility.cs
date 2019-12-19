using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ResearchWindowGenerator
{
    class Utility
    {
        private Timer _timer = null;
        static double TimeCount = 0.0;
        private static string LayoutfilePass;
        private static string ClickfilePass;

        public static string fileName { get; private set; }

        internal static void DoEvents()
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
            /*
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

            return ary;*/

            int[] ary2 = ary.OrderBy(i => Guid.NewGuid()).ToArray();
            return ary2;
        }


        public static string LoggerInitialize(string _layoutName)
        {
            DateTime date = DateTime.Now;
            //File名生成
            String start_time = date.Year + "." + date.Month + "." + date.Day + "." + date.Hour + "." + date.Minute + "." + date.Second;
            String subjectname = "";



            if (MainWindow.subjectName.Equals(""))
            {
                subjectname = "YURIKONANAO";
            }
            else
            {
                subjectname = MainWindow.subjectName;
            }
            fileName = subjectname + "_" + _layoutName + "_" + start_time;

            string filePass = @"../../../LogFolder/";
            if (!Directory.Exists(filePass))
            {
                Directory.CreateDirectory(filePass);
                Console.WriteLine("生成しました");
            }
            LayoutfilePass = filePass + fileName + ".csv";
            System.IO.File.Create(LayoutfilePass).Close();
            Console.WriteLine("LogFile: " + LayoutfilePass + " 生成");
            return LayoutfilePass;



        }



        public static string LoggerInitializeClick(string _layoutName)
        {
            DateTime date = DateTime.Now;
            //File名生成
            String start_time = date.Year + "." + date.Month + "." + date.Day + "." + date.Hour + "." + date.Minute + "." + date.Second;
            String subjectname = "";



            if (MainWindow.subjectName.Equals(""))
            {
                subjectname = "YURIKONANAO";
            }
            else
            {
                subjectname = MainWindow.subjectName;
            }
            fileName = subjectname + "_" + "Click_" + _layoutName + "_" + start_time;

            string filePass = @"../../../LogFolder/";
            if (!Directory.Exists(filePass))
            {
                Directory.CreateDirectory(filePass);
                Console.WriteLine("生成しました");
            }
            ClickfilePass = filePass + fileName + ".csv";
            System.IO.File.Create(ClickfilePass).Close();
            Console.WriteLine("LogFile: " + ClickfilePass + " 生成");


            // throw new NotImplementedException();
            StreamWriter w = new StreamWriter(ClickfilePass, true, Encoding.UTF8);

            //時間 ボタンの名前 ボタンのタグ
            w.Write("sec." + ",");
            w.Write("Name" + ",");
            w.Write("tag" + ",");
            w.Write("mousePosition.X" + ",");
            w.Write("mousePosition.Y" + ",");


            w.Write("\n");
            w.Close();






            return ClickfilePass;



        }

        internal static void SaveLog(string layoutFilePass, string v)
        {
            StreamWriter w = new StreamWriter(layoutFilePass, true, Encoding.UTF8);
            w.Write(v + "\n");
            w.Close();
        }

        internal static void SaveLog(string layoutFilePass, int[] ary)
        {
            StreamWriter w = new StreamWriter(layoutFilePass, true, Encoding.UTF8);

            foreach (int i in ary)
            {
                w.Write(i + ",");

            }
            w.Write("\n");
            w.Close();
        }

        public static void SaveLogClick(string name, string tag, System.Drawing.Point mousePosition)
        {
            // throw new NotImplementedException();
            StreamWriter w = new StreamWriter(ClickfilePass, true, Encoding.UTF8);

            //時間 ボタンの名前 ボタンのタグ
            w.Write(counter() + ",");
            w.Write(name + ",");
            w.Write(tag + ",");
            w.Write(mousePosition.X + ",");
            w.Write(mousePosition.Y + ",");


            w.Write("\n");
            w.Close();









        }


        public static int counter()
        {
            Console.WriteLine(sw.ElapsedMilliseconds);
            return (int)sw.ElapsedMilliseconds;
        }

        static Stopwatch sw = new Stopwatch();
        internal static void StopWatch(string v)
        {
            if (v.Equals("Start"))
            {
                sw.Start();
            }
            else if (v.Equals("Stop"))
            {
                int a = counter();
                sw.Stop();
            }
        }


    }
}
