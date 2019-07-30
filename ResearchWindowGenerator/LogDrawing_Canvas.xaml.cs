using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ResearchWindowGenerator
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class LogDrawing_Canvas : System.Windows.Controls.UserControl
    {
        static int MAXCOLUMN;
        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];
        static string csvPath;

        public LogDrawing_Canvas()
        {
            InitializeComponent();
            //csvPath = @"../../../LogFolder/_ResarchWindowTest_2019.7.15.14.57.3.csv";
            /*
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.Margin = new Thickness(0, 0, 0, 0);
            */

            System.Windows.Controls.UserControl logDraw = this.FindName("logDrawing_Canvas") as System.Windows.Controls.UserControl;
            //researchwindowpdf.WindowState = WindowState.Maximized;
            logDraw.Width = Screen.PrimaryScreen.WorkingArea.Width;
            logDraw.Height = Screen.PrimaryScreen.WorkingArea.Height;

            Canvas myCanvas = this.FindName("mycanvas") as Canvas;
            mycanvas.Height = logDraw.Height;
            mycanvas.Width = logDraw.Width;

        }

        public void setFilePath(string _file_path)
        {
            csvPath = _file_path;
            Console.WriteLine("LogDrawing_Canvas.xaml" + csvPath);
            CsvReader(csvPath);
        }

        private void CsvReader(string _csvpass)
        {
            int count = 0;
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(_csvpass))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        var values = line.Split(',');
                        csvContentsList[count] = new List<double>();
                        foreach (var value in values)
                        {
                            /*
                            #if DEBUG
                            Console.WriteLine(value.Length);
                            Console.WriteLine(Convert.ToDouble(value));
                            Console.WriteLine("count =" + count + ", counts = " + count + ", value = " + value);
                            Console.WriteLine("ここからcsv_arrayの中身");
                            #endif*/
                            csvContentsList[count].Add(Convert.ToDouble(value));
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
            DrawLogLine();
        }

        private void DrawLogLine()
        {
            Polyline polyline = new Polyline();
            polyline.Stroke = Brushes.Black;

            for (int i = 0; i < MAXCOLUMN; i++)
            {
                /*
                #if DEBUG
                Console.WriteLine("csvContentsList[" + i + "]");
                Console.WriteLine("時間 : " + csvContentsList[i].ToArray()[0] + "秒 //" + "x座標" + csvContentsList[i].ToArray()[1] + " //" + "y座標" + csvContentsList[i].ToArray()[2]);
                # endif */
                polyline.Points.Add(new Point(csvContentsList[i].ToArray()[1], csvContentsList[i].ToArray()[2]));
                
            }
            polyline.Stroke = Brushes.Blue;
            polyline.Opacity = 100000;
            mycanvas.Children.Add(polyline);
            DoEvents();
        }

        /// <summary>
        /// 現在メッセージ待ち行列の中にある全てのUIメッセージを処理します。
        /// </summary>
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
