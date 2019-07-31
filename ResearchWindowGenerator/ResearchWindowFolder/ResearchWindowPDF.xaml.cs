using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Button = System.Windows.Controls.Button;
using MouseEventHandler = System.Windows.Input.MouseEventHandler;
using Panel = System.Windows.Controls.Panel;
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
            


            StackPanel myStackPanel = this.FindName("myStackPanel") as StackPanel;
            myStackPanel.Height = researchwindowpdf.Height;
            myStackPanel.Width = researchwindowpdf.Width/2;
            Grid.SetZIndex(myStackPanel,1);

            //個別の機能

            WebBrowser pdfviewer = new WebBrowser
            {
                Width = myStackPanel.Width,
                //Height = researchwindowpdf.Height,
                //Height = this.Height,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Margin = new Thickness(0, 0, 0, 0),
            };
            //<WebBrowser x:Name="PDFViewer" HorizontalAlignment="Left" VerticalAlignment="Top"/>
            //PDFReader(pdfviewer);
            //==
            Assembly mainAssembly = Assembly.GetExecutingAssembly();
            // Get URI to navigate to  
            Uri uri = new Uri(System.IO.Path.GetFullPath("../../../PDFFolder/smartIoT.pdf"), UriKind.RelativeOrAbsolute);
            pdfviewer.Navigate(uri + "#page=7&scrollbar=0&toolbar=0&view=Fit&zoom=75");// + "#toolbar=1"
            //==
            myStackPanel.Children.Add(pdfviewer);




            StackPanel radiobuttonStackPanel = this.FindName("radiobuttonStackPanel") as StackPanel;
            radiobuttonStackPanel.Height = researchwindowpdf.Height/2 -20;
            radiobuttonStackPanel.Width = researchwindowpdf.Width / 4 - 20;
            radiobuttonStackPanel.Margin = new Thickness(myStackPanel.Width, 0, 10, 10);
            //Grid.SetZIndex(radiobuttonStackPanel, 1);
            radiobuttonStackPanel.Background = new SolidColorBrush(Colors.Black);
            StackPanel.SetZIndex(radiobuttonStackPanel, 1);

            StackPanel listviewStackPanel = this.FindName("listviewStackPanel") as StackPanel;
            listviewStackPanel.Height = researchwindowpdf.Height/2 -20;
            listviewStackPanel.Width = researchwindowpdf.Width / 4 -20;
            listviewStackPanel.Margin = new Thickness(myStackPanel.Width + radiobuttonStackPanel.Width, 0, 10, 0);
            //Grid.SetZIndex(listviewStackPanel, 1);
            listviewStackPanel.Background = new SolidColorBrush(Colors.Red);
            StackPanel.SetZIndex(listviewStackPanel, 2);


            StackPanel te = this.FindName("temp1StackPanel") as StackPanel;
            te.Height = researchwindowpdf.Height/2 -20;
            te.Width = researchwindowpdf.Width / 4 -20;
            //Grid.SetZIndex(te, 1);
            StackPanel.SetZIndex(te, 3);
            te.Margin= new Thickness(myStackPanel.Width, listviewStackPanel.Height, 10, 10);
            te.Background = new SolidColorBrush(Colors.Yellow);

            StackPanel buttonStackPanel = this.FindName("buttonStackPanel") as StackPanel;
            buttonStackPanel.Height = researchwindowpdf.Height/2 -20;
            buttonStackPanel.Width = researchwindowpdf.Width / 4 -20;
            buttonStackPanel.Margin = new Thickness(myStackPanel.Width + radiobuttonStackPanel.Width, listviewStackPanel.Height, 0, 0);
            //Grid.SetZIndex(buttonStackPanel, 1);
            StackPanel.SetZIndex(buttonStackPanel, 4);
            buttonStackPanel.Background = new SolidColorBrush(Colors.Green);
            Button loggerButton = new Button {
                Width = buttonStackPanel.Width * 0.9,
                Height = buttonStackPanel.Height * 0.9,
                Content = "Start",
                Margin = new Thickness(buttonStackPanel.Width*0.1, buttonStackPanel.Height * 0.1, buttonStackPanel.Width * 0.1, buttonStackPanel.Height * 0.1),
            };
            buttonStackPanel.Children.Add(loggerButton);
            

            



            //==================================================================================

            //TODO : マウスカーソルの座標位置のログを取得できるようにする
            if (log_flag == false)
            {
                Logger.LoggerInitialize("ResearchWindowPDF");
                /*
                Logger.SaveMouseCursorPosition();
                */
                /*
                maingrid.MouseLeftButtonDown += MouseLeftButtonDown;
                researchwindowpdf.MouseLeftButtonDown += MouseLeftButtonDown;
                myStackPanel.MouseLeftButtonDown += MouseLeftButtonDown;

                radiobuttonStackPanel.MouseLeftButtonDown += MouseLeftButtonDown;
                listviewStackPanel.MouseLeftButtonDown += MouseLeftButtonDown;
                buttonStackPanel.MouseLeftButtonDown += MouseLeftButtonDown;
                te.MouseLeftButtonDown += MouseLeftButtonDown;

                pdfviewer.MouseLeftButtonDown += MouseLeftButtonDown;
                loggerButton.MouseLeftButtonDown += MouseLeftButtonDown;
                */


                //pdfviewer.PreviewMouseDown += pdfPreviewMouseDown;
                
                /*
                Popup drawlogPopup = this.FindName("drawlogPopup") as Popup;
                System.Threading.Thread.Sleep(500);
                drawlogPopup.IsOpen = true;
                drawlogPopup.AllowsTransparency = true;
                //drawlogPopup.Width = 1000;
                //drawlogPopup.Height = 1000;
                drawlogPopup.Placement = PlacementMode.Center;
                drawlogPopup.PlacementTarget = maingrid;
                //drawlogPopup.MouseLeftButtonDown += MouseLeftButtonDown;
                drawlogPopup.PreviewMouseDown += pdfPreviewMouseDown;
                */

                StartTimer();
                

            }
            if(log_flag == true){

                

                logdrawing = new LogDrawing_Canvas
                {
                    Height = this.Height,
                    Width = this.Width,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top,
                    Margin = new Thickness(0, 0, 0, 0),
                };
                logdrawing.setFilePath(filePath);

                Popup drawlogPopup = this.FindName("drawlogPopup") as Popup;
                System.Threading.Thread.Sleep(500);
                drawlogPopup.IsOpen = true;
                drawlogPopup.AllowsTransparency = true;
                //drawlogPopup.Width = 1000;
                //drawlogPopup.Height = 1000;
                drawlogPopup.Placement = PlacementMode.Center;
                drawlogPopup.PlacementTarget = maingrid;
                drawlogPopup.Child = logdrawing;


                //Generate_subWindow();

            }
        }

        private void pdfPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(researchWindowPDF);
            Console.WriteLine(p.X + "|" + p.Y);
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(maingrid);
            Console.WriteLine(p.X +"|"+ p.Y);
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


        private void PDFReader(WebBrowser pdfviewer)
        {
            //String PDFfilePass = @"../../../PDFFolder/smartIoT.pdf";
            Assembly mainAssembly = Assembly.GetExecutingAssembly();

            
            
            
            
            //pdfviewer.Height = Screen.PrimaryScreen.WorkingArea.Height;


            // Get URI to navigate to  
            Uri uri = new Uri(System.IO.Path.GetFullPath("../../../PDFFolder/smartIoT.pdf"), UriKind.RelativeOrAbsolute);

            pdfviewer.Navigate(uri + "#page=7&scrollbar=0&toolbar=0&view=Fit&zoom=75");// + "#toolbar=1"
            //pdfviewer.Navigate("http://www.wpf-tutorial.com");
            
            //DoEvents();
        }
    }
}
