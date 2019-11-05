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
    public partial class ResearchWindowLayout : Window
    {
        string WindowName;
        /*コンポーネントの宣言*/
        /*Grid*/
        Grid maingrid;

        ColumnDefinition colDef1;
        ColumnDefinition colDef2;
        RowDefinition rowDef1;
        RowDefinition rowDef2;

        Double columnWidth1;
        Double columnWidth2;
        Double rowHeight1;
        Double rowHeight2;

        
        /*機能のサイズ*/
        /*MainContents*/
        Double mainContents_Height;
        Double mainContents_Width;
        /*ContentsBar*/
        Double contentsBar_Height;
        Double contentsBar_Width;
        /*ToolBar*/
        Double toolBar_Height;
        Double toolBar_Width;


        

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
        /// <param name="patternnum">表示するWindowの種類</param>
        /// <param name="file_name">マウスの移動座標を保存する/したファイル名</param>
        /// <param name="click_file_name">クリック位置を保存する/したファイル名</param>
        /// <param name="log_flag">true : ログの線を描きだし
        ///                        false : ログ取得</param>
        ///                        
        public ResearchWindowLayout(string windowname, int patternnum, string file_name, string click_file_name, bool log_flag)
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


            //LoadSettingPattern();

            MyMainContents maincontents = new MyMainContents();
            MyContentsBar contentsBar = new MyContentsBar();
            MyToolBar toolBar = new MyToolBar();
            //3つの機能
            /*StackPanel
            StackPanel toolbarStack;
            StackPanel contentbarStack;
            StackPanel mainContentStack;
            */
            /**/
            //Vector toolbar = new Vector{1,1};

            //Patternによってスタックパネルを切り替えるようにできないかな？
            //あらかじめStackPanelをそれぞれに当てはまるようなものを用意して
            /**
             * 各レイアウトについて
             * MainContents
             * Width =  Height= 
             * ToolBar =
             * SelectBar = 
             */


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

            // Layout1 
            /**/


            // Layout2
            /**/

            // Layout3
            /**/

            // Layout4
            /**/


            //Column : 行 Width
            columnWidth1 = this.Width * 1 / 5;
            columnWidth2 = this.Width * 4 / 5;
            colDef1 = new ColumnDefinition { Width = new GridLength(columnWidth1) };
            colDef2 = new ColumnDefinition { Width = new GridLength(columnWidth2) };
            maingrid.ColumnDefinitions.Add(colDef1);
            maingrid.ColumnDefinitions.Add(colDef2);

            //Row : 列 Height
            rowHeight1 = this.Height * 0.13;
            rowHeight2 = this.Height * 0.87;
            rowDef1 = new RowDefinition { Height = new GridLength(rowHeight1) };
            rowDef2 = new RowDefinition { Height = new GridLength(rowHeight2) };
            maingrid.RowDefinitions.Add(rowDef1);
            maingrid.RowDefinitions.Add(rowDef2);

        }

        /// <summary>
        /// コンポーネントの読み込み
        /// </summary>
        private void CompornentInit()
        {
            
            // MainContents


            // ToolBar
            // SelectBar


            /*
            //① PowerPoint-ツールバー
            toolbarStack = new StackPanel
            {
                //Width = this.Width * 0.3,
                //Height = this.Height * 0.7,
                Width = this.Width,
                Height = rowHeight2,
                Background = Brushes.Blue,
            };
            maingrid.Children.Add(toolbarStack);
            //rowDef1.Height = toolbarStack.Height;

            //Grid.SetRowSpan(toolbarStack,2);
            Grid.SetRow(toolbarStack, 0);
            Grid.SetColumn(toolbarStack, 0);
            Grid.SetColumnSpan(toolbarStack, 2);

            //Button追加


            //② PowerPoint-項目選択
            contentbarStack = new StackPanel
            {
                Width = columnWidth1,
                Height = rowHeight2,
                Background = Brushes.Yellow
            };
            maingrid.Children.Add(contentbarStack);

            //Button追加
            double contentbarButtonWidth = columnWidth1;
            double contentbarButtonHeight = rowHeight2 * 1 / 5;

            Button[] contentbarButton = new Button[5];
            for (int i = 0; i < 5; i++)
            {
                contentbarButton[i] = new Button();
                contentbarButton[i].Width = contentbarButtonWidth;
                contentbarButton[i].Height = contentbarButtonHeight;
                contentbarButton[i].Content = "Content" + i;
                contentbarStack.Children.Add(contentbarButton[i]);
            }

            Grid.SetRow(contentbarStack, 1);
            Grid.SetColumn(contentbarStack, 0);

            //③ PowerPoint-メインコンテンツ
            mainContentStack = new StackPanel
            {
                Width = this.Width * 4 / 5,
                Height = this.Height * 4 / 5,
                Background = Brushes.Green,
            };
            maingrid.Children.Add(mainContentStack);
            Rectangle mainContent = new Rectangle
            {
                Width = mainContentStack.Width * 2 / 3,
                Height = mainContentStack.Height * 2 / 3,
                Fill = Brushes.IndianRed,
                VerticalAlignment = VerticalAlignment.Center
            };
            mainContentStack.Children.Add(mainContent);

            Grid.SetRow(mainContentStack, 1);
            Grid.SetColumn(mainContentStack, 1);
            */





        }

        /// <summary>
        /// 
        /// </summary>
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
                //ログ描画機構のやつ
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

        /// <summary>
        /// ボタンを押したとき
        /// ログの押下とそのテキストでその後の動作がどうなるか
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.Equals("Start"))
            {
                StartTimer();
                ((System.Windows.Controls.Button)sender).Content = "Finish";
                //System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
                //Logger.SaveMouseClickPosition(TimeCount, point.X, point.Y);

                Button sender1 = (System.Windows.Controls.Button)sender;
                Console.WriteLine("aaaaaaaaaa" + sender1.Name);
            }
            else if (((Button)sender).Content.Equals("Finish"))
            {
                StopTimer();
                ((Button)sender).Content = "End";
            }
        }


        /// <summary>
        /// 
        /// https://moewe-net.com/csharp/forms-timer
        /// </summary>

        private void StartTimer()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TickHandler);
            //timer.Interval = 20;
            timer.Interval = 50;
            timer.Start();
            _timer = timer;
        }


        /// <summary>
        /// 
        /// </summary>
        private void StopTimer()
        {
            if (_timer == null)
            {
                return;
            }
            _timer.Stop();
            _timer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TickHandler(object sender, EventArgs e)
        {
            //マウスカーソルの座標を取得
            System.Drawing.Point p = System.Windows.Forms.Control.MousePosition;
            TimeCount += 0.05;
            Logger.SaveMouseCursorPosition(TimeCount, p.X, p.Y);
        }

        /// <summary>
        /// 
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
