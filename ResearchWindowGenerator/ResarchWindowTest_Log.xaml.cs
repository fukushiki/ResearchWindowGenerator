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
        static double TimeCount = 0.0;
        static List<string[]> lists = new List<string[]>();
        static string csvPath = @"../../../LogFolder/_ResarchWindowText_2019.7.15.14.57.3.csv";
        static int drawCount = 0;
        //static int fileLength = 0;
        static int MAXCOLUMN;
        //static int MAXLINE;
        static double[][] csvContents = new double[1000][];
        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];

        public ResarchWindowTest_Log()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            this.WindowState = WindowState.Maximized;
            CsvReader();
            //ログを再生するようにする
            //StartTimer();
            DrawLogLine();
        }

        public void CsvReader()
        {
            int count = 0;
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(csvPath))
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
 
                        csvContentsList[count] = new List<double>();
                        foreach (var value in values)
                        {
                            Console.WriteLine(value.Length);
                            Console.WriteLine(Convert.ToDouble(value));
                            Console.WriteLine("count =" + count + ", counts = " + count + ", value = " + value);
                            Console.WriteLine("ここからcsv_arrayの中身");
                            csvContentsList[count].Add(Convert.ToDouble(value));

                        
                        }

                        Console.WriteLine("確認！！！！");
                        foreach (double r in csvContentsList[count])
                        {
                            // elementに上から順にresultの要素が入る
                            
                            Console.WriteLine(r);
                        }
                        count++;
                    }
                    MAXCOLUMN = count;
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                System.Console.WriteLine(e.Message);
            }

            Console.WriteLine("ここから中身の確認");
        }

        /*
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
        */
        private void TickHandler(object sender, EventArgs e)
        {
            // コンソールに出力する
            TimeCount += 0.25;
            drawCount += 1;
        }

        public void DrawLogLine()
        {
            Polyline polyline = new Polyline();
            polyline.Stroke = Brushes.Black;

            for (int i = 0; i < MAXCOLUMN; i++)
            {
                Console.WriteLine("csvContentsList[" + i + "]");

                Console.WriteLine("時間 : " + csvContentsList[i].ToArray()[0] + "秒 //" + "x座標" + csvContentsList[i].ToArray()[1] + " //" + "y座標" + csvContentsList[i].ToArray()[2]);
                polyline.Points.Add(new Point(csvContentsList[i].ToArray()[1], csvContentsList[i].ToArray()[2]));
            }
            
            mycanvas.Children.Add(polyline);

        }
    }
}
