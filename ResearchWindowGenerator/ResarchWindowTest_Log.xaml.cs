using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
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
        static string csvPath = @"../../../LogFolder/_ResarchWindowText_2019.7.15.14.57.3.csv";
        static int drawCount = 0;
        static int fileLength = 0;
        static int MAXCOLUMN;
        static int MAXLINE;
        static double[][] csvContents = new double[1000][];

        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];

        /*
         List<Data>[] sample = new List<Data>[3];
sample[0] = new List<Data>();
sample[1] = new List<Data>();
             */

        //private static ArrayList csvContents = new ArrayList();

        public ResarchWindowTest_Log()
        {
            InitializeComponent();
            // タイトルバーとの境界線を表示しない
            //this.WindowStyle = WindowStyle.None;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            this.WindowState = WindowState.Maximized;



            //ReadCsv();
            //MAXCOLUMN = Lookup_MAXCOLUMN();
            //MAXLINE = Lookup_MAXLINE();
            //csvContentsList = new List<double>[MAXCOLUMN];
            CsvReader();
            //Console.WriteLine(lists.Count());
            //csvContents.

            //ログを再生するようにする
            //StartTimer();


            DrawLogLine();



        }

        public int Lookup_MAXCOLUMN()
        {
            int column = 0;

            // csvファイルを開く
            using (var sr = new System.IO.StreamReader(csvPath))
            {
                // ストリームの末尾まで繰り返す

                while (!sr.EndOfStream)
                {
                    column++;
                }
            }


            return column;
        }



        public int Lookup_MAXLINE()
        {
            int line = 0;

            return line;
        }



        

        public void CsvReader()
        {
            //int[][] csv_array = new int[MAXCOLUMN][];
            //double[][] csv_array = new double[1000][];
            
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
                        //Console.WriteLine(values[0].GetType());
                        Console.WriteLine(values[1]);
                        //Console.WriteLine(values[1].GetType());
                        Console.WriteLine(values[2]);
                        //Console.WriteLine(values[2].GetType());
                        //lists.AddRange(values);
                        //Console.WriteLine(lists);
                        //TODO : CSVファイルの読み込みはできているのに中身の処理がうまくいっていないので考える
                        //lists.AddRange(values.ToList);
                        //int counts = 0;

                        csvContentsList[count] = new List<double>();
                        foreach (var value in values)
                        {
                            Console.WriteLine(value.Length);
                            Console.WriteLine(Convert.ToDouble(value));
                            //csv_array[count][counts] = Convert.ToDouble(value);
                            Console.WriteLine("count =" + count + ", counts = " + count + ", value = " + value);
                            Console.WriteLine("ここからcsv_arrayの中身");
                            //Console.WriteLine("csv_array" + csv_array);
                            //csv_array[count][counts] = 0.1111111111111/*Convert.ToDouble(value)*/;
                            //Console.WriteLine(csv_array[count][counts]);
                            csvContentsList[count].Add(Convert.ToDouble(value));

                            //Console.WriteLine(csvContentsList.);
                        }

                        Console.WriteLine("確認！！！！");
                        foreach (double r in csvContentsList[count])
                        {
                            // elementに上から順にresultの要素が入る
                            
                            Console.WriteLine(r);
                        }

                        /*
                         * foreach (Dictionary<string, string>element in result) {
   // elementに上から順にresultの要素が入る
}
                         * 
                         * 
                         * 
                         static List<double>[] csvContentsList = new List<double>[1000];
                         
                         */


                        /*
                        csv_array[count][0] = double.Parse(values[0]);
                        Console.WriteLine(csv_array[count][0]);
                        csv_array[count][1] = double.Parse(values[1]);
                        Console.WriteLine(csv_array[count][1]);
                        csv_array[count][2] = double.Parse(values[2]);
                        Console.WriteLine(csv_array[count][2]);*/
                        count++;
                        //counts++;
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
            /*
            foreach (double[] a in list)
            {
                Console.WriteLine(a);

            }*/
            




            //return csv_array;
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



        public void DrawLogLine()
        {
            //static List<double>[] csvContentsList = new List<double>[100000];
            /*
            for(int i = 0; i< MAXCOLUMN; i++)
            {
                Console.WriteLine("csvContentsList[" + i + "]");
                
                Console.WriteLine("時間 : " + csvContentsList[i].ToArray()[0] +"秒 //" + "x座標" + csvContentsList[i].ToArray()[1] + " //" + "y座標" + csvContentsList[i].ToArray()[2]);
            }*/
            /*
            PaintEventArgs e;
            Pen blackPen = new Pen(Color.Black, 3);
            e.Graphics.DrawLine(blackPen, (float)100, (float)100, (float)800, (float)800);
            */


        }


    }
}
