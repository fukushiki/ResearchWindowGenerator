using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CheckBox = System.Windows.Controls.CheckBox;
using ComboBox = System.Windows.Controls.ComboBox;
using GroupBox = System.Windows.Controls.GroupBox;
using MouseEventHandler = System.Windows.Input.MouseEventHandler;
using Panel = System.Windows.Controls.Panel;
using RadioButton = System.Windows.Controls.RadioButton;
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
        string clickfilePath;
        //TODO : できるならLISTのLISTにしたい　https://teratail.com/questions/40608
        static List<double>[] csvContentsList = new List<double>[100000];
        WebBrowser pdfviewer;
        static Uri uri;
        int viewpage = 34;
        //①7 ②34 ③37
        

        LogDrawing_Canvas logdrawing;
        public ResearchWindowPDF(string file_name, string click_file_name, bool log_flag)
        {
            
            LogFlag = log_flag;
            filePath = file_name;
            clickfilePath = click_file_name;
            InitializeComponent();
            Window researchwindowpdf = this.FindName("researchWindowPDF") as Window;
            researchwindowpdf.WindowState = WindowState.Maximized;
            //researchwindowpdf.Width = Screen.PrimaryScreen.WorkingArea.Width;
            //researchwindowpdf.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Console.WriteLine(SystemParameters.WorkArea.Width);
            Console.WriteLine(SystemParameters.WorkArea.Height);
            researchWindowPDF.Width = SystemParameters.WorkArea.Width;
            researchWindowPDF.Height = SystemParameters.WorkArea.Height;



            StackPanel myStackPanel = this.FindName("myStackPanel") as StackPanel;
            myStackPanel.Height = researchwindowpdf.Height;
            myStackPanel.Width = researchwindowpdf.Width/2;
            Grid.SetZIndex(myStackPanel,1);

            //個別の機能

            pdfviewer = new WebBrowser
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
            uri = new Uri(System.IO.Path.GetFullPath("../../../PDFFolder/smartIoT.pdf"), UriKind.RelativeOrAbsolute);
            pdfviewer.Navigate(uri + "#scrollbar=0&toolbar=0&view=Fit&zoom=75&page=" + viewpage);// + "#toolbar=1"
            //==
            myStackPanel.Children.Add(pdfviewer);



            
            StackPanel radiobuttonStackPanel = this.FindName("radiobuttonStackPanel") as StackPanel;
            radiobuttonStackPanel.Height = researchwindowpdf.Height/2 -20;
            radiobuttonStackPanel.Width = researchwindowpdf.Width / 4 - 20;
            radiobuttonStackPanel.Margin = new Thickness(myStackPanel.Width, 0, 10, 10);
            



            TextBlock radiobuttonStackPanelTextBlock = new TextBlock
            {
                Name = "radiobuttonStackPanelTextBlock",
                Width = radiobuttonStackPanel.Width * 0.8,
                Height = radiobuttonStackPanel.Height * 0.05,
                Margin = new Thickness(radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1, radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1),
                Text = "①米国国立標準技術研究所の略称はどれか",
                FontSize = 17,

            };
            radiobuttonStackPanel.Children.Add(radiobuttonStackPanelTextBlock);

            //Grid.SetZIndex(radiobuttonStackPanel, 1);
            //radiobuttonStackPanel.Background = new SolidColorBrush(Colors.Black);
            //radiobuttonStackPanel.BorderBrush = new SolidColorBrush(Colors.Black);
            StackPanel.SetZIndex(radiobuttonStackPanel, 1);

            StackPanel radiobuttonGroupingStackPanel = new StackPanel {
                Name = "radiobuttonGroupingStackPanel",
                Width = radiobuttonStackPanel.Width * 0.8,
                Height = radiobuttonStackPanel.Height * 0.45,
                //Margin = new Thickness(radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1, radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1),

            };



            /*Margin = new Thickness(radiobuttonGroupingStackPanel.Width * 0.2, radiobuttonGroupingStackPanel.Height * 0.1,
                                radiobuttonGroupingStackPanel.Width * 0.1, radiobuttonGroupingStackPanel.Height * 0.1),*/
            RadioButton radiobutton1 = new RadioButton
            {
                Name = "radiobutton1",
                Width = radiobuttonGroupingStackPanel.Width * 0.8,
                Height = radiobuttonGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(radiobuttonGroupingStackPanel.Width * 0.2, 0,
                                radiobuttonGroupingStackPanel.Width * 0.1, 0),
                GroupName = "radiobuttonGroup",
                Content = "NSF",
                FontSize = 17,
            };
            RadioButton radiobutton2 = new RadioButton
            {
                Name = "radiobutton2",
                Width = radiobuttonGroupingStackPanel.Width * 0.8,
                Height = radiobuttonGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(radiobuttonGroupingStackPanel.Width * 0.2, 0,
                                radiobuttonGroupingStackPanel.Width * 0.1, 0),
                GroupName = "radiobuttonGroup",
                Content = "US Ignite",
                FontSize = 17,
            };
            RadioButton radiobutton3 = new RadioButton
            {
                Name = "radiobutton3",
                Width = radiobuttonGroupingStackPanel.Width * 0.8,
                Height = radiobuttonGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(radiobuttonGroupingStackPanel.Width * 0.2, 0,
                                radiobuttonGroupingStackPanel.Width * 0.1, 0),
                GroupName = "radiobuttonGroup",
                Content = "NIST",
                FontSize = 17,
            };

            radiobuttonGroupingStackPanel.Children.Add(radiobutton1);
            radiobuttonGroupingStackPanel.Children.Add(radiobutton2);
            radiobuttonGroupingStackPanel.Children.Add(radiobutton3);
            //radiobuttonGroupBox.AddChild(radiobuttonGroupingStackPanel);


            Button radiobuttonStackPanel_Button = new Button
            {
                Name = "radiobuttonStackPanel_Button",
                Width = radiobuttonStackPanel.Width * 0.8,
                Height = radiobuttonStackPanel.Height * 0.1,
                Content = "Start",
                Margin = new Thickness(radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1, radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1),
            };
            //radiobuttonStackPanel.Children.Add(radiobuttonGroupBox);
            radiobuttonStackPanel.Children.Add(radiobuttonGroupingStackPanel);
            radiobuttonStackPanel.Children.Add(radiobuttonStackPanel_Button);



            StackPanel CheckboxStackPanel = this.FindName("CheckboxStackPanel") as StackPanel;
            CheckboxStackPanel.Height = researchwindowpdf.Height/2 -20;
            CheckboxStackPanel.Width = researchwindowpdf.Width / 4 -20;
            CheckboxStackPanel.Margin = new Thickness(myStackPanel.Width + radiobuttonStackPanel.Width, 0, 10, 0);
            //Grid.SetZIndex(listviewStackPanel, 1);
            //CheckboxStackPanel.Background = new SolidColorBrush(Colors.LemonChiffon);
            StackPanel.SetZIndex(CheckboxStackPanel, 2);

            TextBlock checkboxTextBlock = new TextBlock
            {
                Name = "checkboxTextBlock",
                Width = CheckboxStackPanel.Width * 0.8,
                Height = CheckboxStackPanel.Height * 0.05,
                Margin = new Thickness(CheckboxStackPanel.Width * 0.1, CheckboxStackPanel.Height * 0.1, CheckboxStackPanel.Width * 0.1, CheckboxStackPanel.Height * 0.1),
                Text = "②社会(生命・財産・情報を守る)項目はどれか",
                FontSize = 17,

            };
            CheckboxStackPanel.Children.Add(checkboxTextBlock);

            StackPanel checkboxGroupingStackPanel = new StackPanel
            {
                Name = "checkboxGroupingStackPanel",
                Width = CheckboxStackPanel.Width * 0.8,
                Height = CheckboxStackPanel.Height * 0.3,
                //Margin = new Thickness(radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1, radiobuttonStackPanel.Width * 0.1, radiobuttonStackPanel.Height * 0.1),

            };
            CheckBox checkbox1 = new CheckBox
            {
                Name = "checkbox1",
                Width = checkboxGroupingStackPanel.Width * 0.8,
                Height = checkboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(checkboxGroupingStackPanel.Width * 0.2, 0,
                                checkboxGroupingStackPanel.Width * 0.1, 0),
                Content = "センシング&データ取得基盤分野",
                FontSize = 17,
            };
            CheckBox checkbox2 = new CheckBox
            {
                Name = "checkbox2",
                Width = checkboxGroupingStackPanel.Width * 0.8,
                Height = checkboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(checkboxGroupingStackPanel.Width * 0.2, 0,
                                checkboxGroupingStackPanel.Width * 0.1, 0),
                Content = "統合ICT基盤分野",
                FontSize = 17,
            };
            CheckBox checkbox3 = new CheckBox
            {
                Name = "checkbox3",
                Width = checkboxGroupingStackPanel.Width * 0.8,
                Height = checkboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(checkboxGroupingStackPanel.Width * 0.2, 0,
                                checkboxGroupingStackPanel.Width * 0.1, 0),
                Content = "データ利活用基盤分野",
                FontSize = 17,
            };
            CheckBox checkbox4 = new CheckBox
            {
                Name = "checkbox4",
                Width = checkboxGroupingStackPanel.Width * 0.8,
                Height = checkboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(checkboxGroupingStackPanel.Width * 0.2, 0,
                                checkboxGroupingStackPanel.Width * 0.1, 0),
                Content = "情報セキュリティ分野",
                FontSize = 17,
            };
            CheckBox checkbox5 = new CheckBox
            {
                Name = "checkbox5",
                Width = checkboxGroupingStackPanel.Width * 0.8,
                Height = checkboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(checkboxGroupingStackPanel.Width * 0.2, 0,
                                checkboxGroupingStackPanel.Width * 0.1, 0),
                Content = "耐災害ICT基盤分野",
                FontSize = 17,
            };
            CheckBox checkbox6 = new CheckBox
            {
                Name = "checkbox6",
                Width = checkboxGroupingStackPanel.Width * 0.8,
                Height = checkboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(checkboxGroupingStackPanel.Width * 0.2, 0,
                                checkboxGroupingStackPanel.Width * 0.1, 0),
                Content = "フロンティア研究部門",
                FontSize = 17,
            };


            checkboxGroupingStackPanel.Children.Add(checkbox1);
            checkboxGroupingStackPanel.Children.Add(checkbox2);
            checkboxGroupingStackPanel.Children.Add(checkbox3);
            checkboxGroupingStackPanel.Children.Add(checkbox4);
            checkboxGroupingStackPanel.Children.Add(checkbox5);
            checkboxGroupingStackPanel.Children.Add(checkbox6);

            CheckboxStackPanel.Children.Add(checkboxGroupingStackPanel);


            Button CheckboxStackPanel_Button = new Button
            {
                Name = "CheckboxStackPanel_Button",
                Width = CheckboxStackPanel.Width * 0.8,
                Height = CheckboxStackPanel.Height * 0.1,
                Content = "Start",
                Margin = new Thickness(CheckboxStackPanel.Width * 0.1, CheckboxStackPanel.Height * 0.3, CheckboxStackPanel.Width * 0.1, CheckboxStackPanel.Height * 0.1),
            };
            CheckboxStackPanel.Children.Add(CheckboxStackPanel_Button);



            StackPanel ComboboxStackPanel = this.FindName("ComboboxStackPanel") as StackPanel;
            ComboboxStackPanel.Height = researchwindowpdf.Height/2 -20;
            ComboboxStackPanel.Width = researchwindowpdf.Width / 4 -20;
            //Grid.SetZIndex(te, 1);
            StackPanel.SetZIndex(ComboboxStackPanel, 3);
            ComboboxStackPanel.Margin= new Thickness(myStackPanel.Width, CheckboxStackPanel.Height, 10, 10);
            //ComboboxStackPanel.Background = new SolidColorBrush(Colors.Yellow);

            TextBlock ComboboxStackPanelTextBlock = new TextBlock
            {
                Name = "comboboxStackPanelTextBlock",
                Width = ComboboxStackPanel.Width * 0.8,
                Height = ComboboxStackPanel.Height * 0.05,
                Margin = new Thickness(ComboboxStackPanel.Width * 0.1, ComboboxStackPanel.Height * 0.1, ComboboxStackPanel.Width * 0.1, ComboboxStackPanel.Height * 0.1),
                Text = "③公共/インフラのうち電力業界でのIoT活用例はどれか",
                FontSize = 17,

            };
            ComboboxStackPanel.Children.Add(ComboboxStackPanelTextBlock);


            ComboBox comboboxStackPanelCombobox = new ComboBox
            {
                Name = "comboboxStackPanelCombobox",
                Width = ComboboxStackPanel.Width * 0.8,
                Height = ComboboxStackPanel.Height * 0.2,
                FontSize = 17,


            };
            string[] iotused =
                { "POS端末情報の活用", "渋滞解消", "ウェアラブル端末", "スマートメーター", "リモート監視" };
            foreach (string i in iotused)
            {
                comboboxStackPanelCombobox.Items.Add(i);
            }

            ComboboxStackPanel.Children.Add(comboboxStackPanelCombobox);



            Button ComboboxStackPanel_Button = new Button
            {
                Name = "comboboxStackPanel_Button",
                Width = ComboboxStackPanel.Width * 0.8,
                Height = ComboboxStackPanel.Height * 0.1,
                Content = "Start",
                Margin = new Thickness(ComboboxStackPanel.Width * 0.1, ComboboxStackPanel.Height * 0.4, ComboboxStackPanel.Width * 0.1, ComboboxStackPanel.Height * 0.1),
            };
            ComboboxStackPanel.Children.Add(ComboboxStackPanel_Button);
            

            StackPanel practiceStackPanel = this.FindName("practiceStackPanel") as StackPanel;
            practiceStackPanel.Height = researchwindowpdf.Height/2 -20;
            practiceStackPanel.Width = researchwindowpdf.Width / 4 -20;
            practiceStackPanel.Margin = new Thickness(myStackPanel.Width + radiobuttonStackPanel.Width, CheckboxStackPanel.Height, 0, 0);
            //Grid.SetZIndex(buttonStackPanel, 1);
            StackPanel.SetZIndex(practiceStackPanel, 4);
            //practiceStackPanel.Background = new SolidColorBrush(Colors.Cyan);

            TextBlock practiceTextBlock = new TextBlock
            {
                Name = "practiceTextBlock",
                Width = practiceStackPanel.Width * 0.8,
                Height = practiceStackPanel.Height * 0.05,
                Margin = new Thickness(practiceStackPanel.Width * 0.1, practiceStackPanel.Height * 0.1, practiceStackPanel.Width * 0.1, practiceStackPanel.Height * 0.1),
                Text = "Ex.練習",
                FontSize = 17,

            };
            practiceStackPanel.Children.Add(practiceTextBlock);

            ComboBox practiceCombobox = new ComboBox
            {
                Name = "practiceCombobox",
                Width = practiceStackPanel.Width * 0.8,
                Height = practiceStackPanel.Height * 0.2,
                FontSize = 17,
                //Margin = new Thickness(practiceStackPanel.Width * 0.1, practiceStackPanel.Height * 0.1, practiceStackPanel.Width * 0.1, practiceStackPanel.Height * 0.1),


            };
            string[] practiceused =
                { "選択肢１","選択肢2","選択肢3","選択肢4","選択肢5" };
            foreach (string i in practiceused)
            {
                practiceCombobox.Items.Add(i);
            }

            practiceStackPanel.Children.Add(practiceCombobox);



            StackPanel practiceradiobuttonGroupingStackPanel = new StackPanel
            {
                Name = "practiceradiobuttonGroupingStackPanel",
                Width = practiceStackPanel.Width * 0.8,
                Height = practiceStackPanel.Height * 0.21,
                Margin = new Thickness(radiobuttonStackPanel.Width * 0.1, 0, radiobuttonStackPanel.Width * 0.1, 0),

            };

            /*Margin = new Thickness(practiceradiobuttonGroupingStackPanel.Width * 0.2, practiceradiobuttonGroupingStackPanel.Height * 0.1,
                                practiceradiobuttonGroupingStackPanel.Width * 0.1, practiceradiobuttonGroupingStackPanel.Height * 0.1),*/



            RadioButton practiceradiobutton1 = new RadioButton
            {
                Name = "practiceradiobutton1",
                Width = practiceradiobuttonGroupingStackPanel.Width * 0.8,
                Height = practiceradiobuttonGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(practiceradiobuttonGroupingStackPanel.Width * 0.2, 0,
                                practiceradiobuttonGroupingStackPanel.Width * 0.1, 0),
                GroupName = "practiceradiobuttonGroup",
                Content = "選択肢1",
                FontSize = 17,
            };
            RadioButton practiceradiobutton2 = new RadioButton
            {
                Name = "practiceradiobutton2",
                Width = practiceradiobuttonGroupingStackPanel.Width * 0.8,
                Height = practiceradiobuttonGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(practiceradiobuttonGroupingStackPanel.Width * 0.2, 0,
                                practiceradiobuttonGroupingStackPanel.Width * 0.1, 0),
                GroupName = "practiceradiobuttonGroup",
                Content = "選択肢2",
                FontSize = 17,
            };
            RadioButton practiceradiobutton3 = new RadioButton
            {
                Name = "practiceradiobutton3",
                Width = practiceradiobuttonGroupingStackPanel.Width * 0.8,
                Height = practiceradiobuttonGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(practiceradiobuttonGroupingStackPanel.Width * 0.2, 0,
                                practiceradiobuttonGroupingStackPanel.Width * 0.1, 0),
                GroupName = "practiceradiobuttonGroup",
                Content = "選択肢3",
                FontSize = 17,
            };

            practiceradiobuttonGroupingStackPanel.Children.Add(practiceradiobutton1);
            practiceradiobuttonGroupingStackPanel.Children.Add(practiceradiobutton2);
            practiceradiobuttonGroupingStackPanel.Children.Add(practiceradiobutton3);

            



            StackPanel practicecheckboxGroupingStackPanel = new StackPanel
            {
                Name = "practicecheckboxGroupingStackPanel",
                Width = practiceStackPanel.Width * 0.8,
                Height = practiceStackPanel.Height * 0.21,
                Margin = new Thickness(radiobuttonStackPanel.Width * 0.1, 0, radiobuttonStackPanel.Width * 0.1, 0),

            };

            CheckBox practicecheckbox1 = new CheckBox
            {
                Name = "practicecheckbox1",
                Width = practicecheckboxGroupingStackPanel.Width * 0.8,
                Height = practicecheckboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(practicecheckboxGroupingStackPanel.Width * 0.2, 0,
                                practicecheckboxGroupingStackPanel.Width * 0.1, 0),
                Content = "選択肢1",
                FontSize = 17,
            };
            CheckBox practicecheckbox2 = new CheckBox
            {
                Name = "practicecheckbox2",
                Width = practicecheckboxGroupingStackPanel.Width * 0.8,
                Height = practicecheckboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(practicecheckboxGroupingStackPanel.Width * 0.2, 0,
                                practicecheckboxGroupingStackPanel.Width * 0.1, 0),
                Content = "選択肢2",
                FontSize = 17,
            };
            CheckBox practicecheckbox3 = new CheckBox
            {
                Name = "practicecheckbox3",
                Width = practicecheckboxGroupingStackPanel.Width * 0.8,
                Height = practicecheckboxGroupingStackPanel.Height * 0.2,
                Margin = new Thickness(practicecheckboxGroupingStackPanel.Width * 0.2, 0,
                                practicecheckboxGroupingStackPanel.Width * 0.1, 0),
                Content = "選択肢3",
                FontSize = 17,
            };





            practicecheckboxGroupingStackPanel.Children.Add(practicecheckbox1);
            practicecheckboxGroupingStackPanel.Children.Add(practicecheckbox2);
            practicecheckboxGroupingStackPanel.Children.Add(practicecheckbox3);



            Button loggerButton = new Button {
                Name = "loggerButton",
                Width = practiceStackPanel.Width * 0.8,
                Height = practiceStackPanel.Height * 0.1,
                Content = "Start",
                //Margin = new Thickness(practiceStackPanel.Width*0.1, practiceStackPanel.Height * 0.1, 
                //practiceStackPanel.Width * 0.1, practiceStackPanel.Height * 0.1),
            };

            practiceStackPanel.Children.Add(practiceradiobuttonGroupingStackPanel);
            practiceStackPanel.Children.Add(practicecheckboxGroupingStackPanel);
            practiceStackPanel.Children.Add(loggerButton);

            //buttonStackPanel.Children.Add(loggerButton);
            DoEvents();







            //==================================================================================

            //TODO : マウスカーソルの座標位置のログを取得できるようにする
            if (log_flag == false)
            {
                Logger.LoggerInitialize("ResearchWindowPDF");
                loggerButton.Click += startbutton_Click;
                radiobuttonStackPanel_Button.Click += startbutton_Click;
                ComboboxStackPanel_Button.Click += startbutton_Click;
                CheckboxStackPanel_Button.Click += startbutton_Click;

                //StartTimer();


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
                logdrawing.setFilePath(filePath, clickfilePath);

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
                DoEvents();

            }
        }

        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == "Start")
            {
                StartTimer();
                ((Button)sender).Content = "Finish";
                //System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
                //Logger.SaveMouseClickPosition(TimeCount, point.X, point.Y);

                Button sender1 = (System.Windows.Controls.Button)sender;
                Console.WriteLine("aaaaaaaaaa"+sender1.Name);


            }
            else if (((Button)sender).Content == "Finish")
            {
                StopTimer();
                ((Button)sender).Content = "End";
            }




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
