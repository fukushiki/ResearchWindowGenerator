using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using WebBrowser = System.Windows.Controls.WebBrowser;

namespace ResearchWindowGenerator.ResearchWindowFolder
{
    /// <summary>
    /// ResearchWindowPDF.xaml の相互作用ロジック
    /// </summary>
    public partial class ResearchWindowPDF : Window
    {
        private Timer _timer = null;
        static double TimeCount = 0.0;
        static bool LogFlag;

        string filePath;
        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];

        LogDrawing_Canvas logdrawing;
        public ResearchWindowPDF(string file_name, bool log_flag)
        {
            
            LogFlag = log_flag;
            filePath = file_name;
            InitializeComponent();
            Window researchwindowpdf = this.FindName("researchWindowPDF") as Window;
            researchwindowpdf.WindowState = WindowState.Maximized;
            researchwindowpdf.Width = Screen.PrimaryScreen.WorkingArea.Width;
            researchwindowpdf.Height = Screen.PrimaryScreen.WorkingArea.Height;
            DoEvents();


            StackPanel myStackPanel = this.FindName("myStackPanel") as StackPanel;
            myStackPanel.Height = researchwindowpdf.Height;
            myStackPanel.Width = researchwindowpdf.Width;

            PDFReader();



            //TODO : マウスカーソルをウィンドウ外に出ないように固定する
            //InitializeCursor();

            //TODO : マウスカーソルの座標位置のログを取得できるようにする
            if (log_flag == false)
            {
                Logger.LoggerInitialize("ResearchWindowPDF");
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
            Logger.SaveMouseCursorPosition(TimeCount, p.X, p.Y);
        }



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


        private void PDFReader()
        {
            String PDFfilePass = @"../../../PDFFolder/smartIoT.pdf";
            Assembly mainAssembly = Assembly.GetExecutingAssembly();

            WebBrowser pdfviewer = this.FindName("PDFViewer") as WebBrowser;
            pdfviewer.Width = Screen.PrimaryScreen.WorkingArea.Width / 3;
            pdfviewer.Height = Screen.PrimaryScreen.WorkingArea.Height;


            // Get URI to navigate to  
            //Uri uri = new Uri("C:/Users/pegaf/source/repos/ResearchWindowGenerator/PDFFolder/smartIoT.pdf", UriKind.RelativeOrAbsolute);
            Uri uri = new Uri(System.IO.Path.GetFullPath("../../../PDFFolder/smartIoT.pdf"), UriKind.RelativeOrAbsolute);
            //C:\Users\pegaf\source\repos\ResearchWindowGenerator\PDFFolder\smartIoT.pdf

            pdfviewer.Navigate(uri + "#page=2");// + "#toolbar=1"
            //pdfviewer.Navigate("http://www.wpf-tutorial.com");
            DoEvents();
        }
    }
}
