using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ResearchWindowGenerator.ResearchWindowFolder
{
    /// <summary>
    /// WindowTemplate.xaml の相互作用ロジック
    /// </summary>
    public partial class ResearchWindowPowerPoint : Window
    {
        string WindowName;
        /*コンポーネントの宣言*/
        /*Grid*/
        Grid maingrid;
        RowDefinition rowDef1;
        RowDefinition rowDef2;
        ColumnDefinition colDef1;
        ColumnDefinition colDef2;




        /*StackPanel*/
        StackPanel no1_stack;
        StackPanel no2_stack;
        StackPanel no3_stack;


        /*Log関係*/
        private Timer _timer = null;
        static double TimeCount = 0.0;
        static bool LogFlag;
        string filePath;
        string clickfilePath;
        LogDrawing_Canvas logdrawing;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowname">このwindowの名前</param>
        /// <param name="file_name">マウスの移動座標を保存する/したファイル名</param>
        /// <param name="click_file_name">クリック位置を保存する/したファイル名</param>
        /// <param name="log_flag">true : ログの線を描きだし
        ///                        false : ログ取得</param>
        public ResearchWindowPowerPoint(string windowname, string file_name, string click_file_name, bool log_flag)
        {
            InitializeComponent();

            /*引数の保存*/
            WindowName = windowname;
            LogFlag = log_flag;
            filePath = file_name;
            clickfilePath = click_file_name;

            /*Windowのサイズ指定*/
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.WindowState = WindowState.Maximized;

            /*初期化メソッドの宣言*/
            this.GridInit();
            this.CompornentInit();
            this.LogSetting();
        }

        /// <summary>
        /// Gridの初期化
        /// </summary>
        /// memo https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.controls.grid?view=netframework-4.8
        private void GridInit()
        {
            maingrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                Background = Brushes.Aquamarine,
                ShowGridLines = true
            };
            this.AddChild(maingrid);

            //Row : 列 Height
            rowDef1 = new RowDefinition();
            rowDef2 = new RowDefinition { };
            maingrid.RowDefinitions.Add(rowDef1);
            maingrid.RowDefinitions.Add(rowDef2);
            
            //Column : 行 Width
            colDef1 = new ColumnDefinition();
            colDef2 = new ColumnDefinition();
            maingrid.ColumnDefinitions.Add(colDef1);
            maingrid.ColumnDefinitions.Add(colDef2);

        }

        /// <summary>
        /// コンポーネントの読み込み
        /// </summary>
        private void CompornentInit()
        {
            //① PowerPoint-ツールバー
            no1_stack = new StackPanel
            {
                //Width = this.Width * 0.3,
                //Height = this.Height * 0.7,
                Background = Brushes.Blue,                
            };
            maingrid.Children.Add(no1_stack);
            //rowDef1.Height = no1_stack.Height;

            //Grid.SetRowSpan(no1_stack,2);
            Grid.SetRow(no1_stack, 0);
            Grid.SetColumn(no1_stack, 0);
            Grid.SetColumnSpan(no1_stack, 2);
            
            

            //② PowerPoint-項目選択
            no2_stack = new StackPanel
            {
                Width = this.Width * 0.7,
                Height = this.Height * 0.7,
                Background = Brushes.Yellow
            };
            maingrid.Children.Add(no2_stack);

            Grid.SetRow(no2_stack, 1);
            Grid.SetColumn(no2_stack, 0);

            //③ PowerPoint-メインコンテンツ
            no3_stack = new StackPanel
            {
                Width = this.Width,
                Height = this.Height * 0.1,
                Background = Brushes.Green,
            };
            maingrid.Children.Add(no3_stack);
            Grid.SetRow(no3_stack, 1);
            Grid.SetColumn(no3_stack, 1);


        }

        private void LogSetting()
        {
            //TODO : マウスカーソルの座標位置のログを取得できるようにする
            if (LogFlag == false)
            {
                Logger.LoggerInitialize(WindowName);
                //ここでログ取得ボタンのクリック定義
                //loggerButton.Click += startbutton_Click;
                //StartTimer();
            }
            if (LogFlag == true)
            {
                //ログ描画機構の
                logdrawing = new LogDrawing_Canvas
                {
                    Height = this.Height,
                    Width = this.Width,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top,
                    Margin = new Thickness(0, 0, 0, 0),
                };
                logdrawing.setFilePath(filePath, clickfilePath);

                //Popup drawlogPopup = this.FindName("drawlogPopup") as Popup;
                Popup drawlogPopup = new Popup
                {
                    IsOpen = true,
                    AllowsTransparency = true,
                    Placement = PlacementMode.Center,
                    PlacementTarget = maingrid,
                    Child = logdrawing
            };
                maingrid.Children.Add(drawlogPopup);
                System.Threading.Thread.Sleep(500);
                DoEvents();
            }
        }

        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == "Start")
            {
                StartTimer();
                ((System.Windows.Controls.Button)sender).Content = "Finish";
                //System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
                //Logger.SaveMouseClickPosition(TimeCount, point.X, point.Y);

                Button sender1 = (System.Windows.Controls.Button)sender;
                Console.WriteLine("aaaaaaaaaa" + sender1.Name);
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
    }
}
