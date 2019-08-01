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
        static int MAXCOLUMN_Click;
        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];
        static List<double>[] csvClickList = new List<double>[100000];
        static string csvPath;
        static string csvClickPath;

        public LogDrawing_Canvas()
        {
            InitializeComponent();


            System.Windows.Controls.UserControl logDraw = this.FindName("logDrawing_Canvas") as System.Windows.Controls.UserControl;
            //researchwindowpdf.WindowState = WindowState.Maximized;
            logDraw.Width = Screen.PrimaryScreen.WorkingArea.Width;
            logDraw.Height = Screen.PrimaryScreen.WorkingArea.Height;

            Canvas myCanvas = this.FindName("mycanvas") as Canvas;
            mycanvas.Height = logDraw.Height;
            mycanvas.Width = logDraw.Width;

            Canvas mycanvasClick = this.FindName("mycanvasClick") as Canvas;
            mycanvasClick.Height = logDraw.Height;
            mycanvasClick.Width = logDraw.Width;

        }

        public void setFilePath(string _file_path, string _csvClickPath)
        {
            csvPath = _file_path;
            csvClickPath = _csvClickPath;
            // Console.WriteLine("LogDrawing_Canvas.xaml" + csvPath);


            CsvReader(csvPath);
           CsvReaderClick(csvClickPath);
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
                //Console.WriteLine(csvContentsList[i].ToArray()[1] + "|" + csvContentsList[i].ToArray()[2]);
                //if (i != 0 && csvContentsList[i].ToArray()[1] != csvContentsList[i - 1].ToArray()[1] && csvContentsList[i].ToArray()[2] != csvContentsList[i - 1].ToArray()[2])){
                polyline.Points.Add(new Point(csvContentsList[i].ToArray()[1], csvContentsList[i].ToArray()[2]));
            }
            polyline.Stroke = Brushes.Blue;
            polyline.Opacity = 100000;
            mycanvas.Children.Add(polyline);
            DoEvents();
        }









        private void CsvReaderClick(string csvpass)
        {
            int count = 0;
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(csvpass))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        var values = line.Split(',');
                        csvClickList[count] = new List<double>();
                        foreach (var value in values)
                        {
                            csvClickList[count].Add(Convert.ToDouble(value));
                        }
                        count++;
                    }
                    MAXCOLUMN_Click = count;
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                System.Console.WriteLine(e.Message);
            }

            Console.WriteLine("ここから中身の確認");
            DrawLogClick();
        }

        private void DrawLogClick()
        {
            //Ellipse ellipse[MAXCOLUMN_Click];
            List<Ellipse> ellipse = new List<Ellipse>();

            for (int i = 0; i < MAXCOLUMN_Click; i++)
            {
                //Point point = new Point(csvClickList[i].ToArray()[1], csvClickList[i].ToArray()[2]);
                ellipse.Add(new Ellipse()
                {
                    Stroke = Brushes.Black,
                    Fill = Brushes.Red,
                    Width = 10,
                    Height = 10,
                    Margin = new Thickness(csvClickList[i].ToArray()[1], csvClickList[i].ToArray()[2], 0, 0)
                });




                //ellipse = new Ellipse { Stroke = Brushes.Black, Fill = Brushes.Red, Width = 30 ,Height = 30 ,};
                //ellipse.Add(new Ellipse);
                //ellipse.Points.Add(new Point(csvClickList[i].ToArray()[1], csvClickList[i].ToArray()[2]));

            }

            foreach (Ellipse a in ellipse)
            {
                mycanvasClick.Children.Add(a);
            }


            /*
            polyline.Stroke = Brushes.Blue;
            polyline.Opacity = 100000;
            */
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
