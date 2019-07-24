using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ResearchWindowGenerator
{
    /// <summary>
    /// ResarchWindowTest.xaml の相互作用ロジック
    /// </summary>
    public partial class ResarchWindowTest_Log : Window
    {
        private Timer _timer = null;
        static double TimeCount = 0.0;
        static List<string[]> lists = new List<string[]>();
        static int drawCount = 0;
        static int fileLength = 0;
        //private static ArrayList csvContents = new ArrayList();

        public ResarchWindowTest_Log()
        {
            InitializeComponent();
            // タイトルバーとの境界線を表示しない
            //this.WindowStyle = WindowStyle.None;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            this.WindowState = WindowState.Maximized;

            

            ReadCsv();

            //Console.WriteLine(lists.Count());
            //csvContents.

            //ログを再生するようにする
            StartTimer();

        }



        
        static void ReadCsv()
        {
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(@"../../../LogFolder/_ResarchWindowText_2019.7.15.14.57.3.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        var values = line.Split(',');
                        // 出力する
                        foreach (var value in values)
                        {
                            System.Console.Write("{0} ", value);
                        }
                        System.Console.WriteLine();
                        Console.WriteLine(values[0]);
                        Console.WriteLine(values[1]);
                        Console.WriteLine(values[2]);
                        //lists.AddRange(values);
                        //Console.WriteLine(lists);
                        //TODO : CSVファイルの読み込みはできているのに中身の処理がうまくいっていないので考える
                        //lists.AddRange(values.ToList);
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                System.Console.WriteLine(e.Message);
            }
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

            //@"../../../LogFolder/_ResarchWindowText_2019.7.15.14.57.3.csv"

            //Console.WriteLine(DateTime.Now.ToString());
            //マウスカーソルの座標を取得
            //int x = System.Windows.Forms.Cursor.Position.X;
            //int y = System.Windows.Forms.Cursor.Position.Y;
            //Console.WriteLine(TimeCount + "," + x + "," + y);
            /*
            StreamReader sr = new StreamReader(@"../../../LogFolder/_ResarchWindowText_2019.7.15.14.57.3.csv");

            TimeCount += 0.25;
            Logger.SaveMouseCursorPosition(TimeCount, x, y);
            */

            // コンソールに出力する
            TimeCount += 0.25;
            drawCount += 1;
            //Console.WriteLine(lists[drawCount]);
            //Console.WriteLine(lists.IndexOf(TimeCount.ToString()));

        }

        
    }
}
