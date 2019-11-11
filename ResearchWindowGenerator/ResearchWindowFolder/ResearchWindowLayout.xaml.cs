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
    //TODO : アプリケーションのレイアウト とりあえずアプリの数値と一緒にしていくつか作ってみる
    //TODO : MainContents
    //TODO : ContentsBar
    //TODO : ToolBar　一つのものと2つのものをそれぞれ作ってみる　位置のやつも考える

    /// <summary>
    /// WindowTemplate.xaml の相互作用ロジック
    /// </summary>
    public partial class ResearchWindowLayout : Window
    {
        string WindowName;
        /*コンポーネントの宣言*/
        /*Grid*/
        static Grid maingrid;

        /*機能*/
        static MyMainContents maincontents;
        MyContentsBar contentsBar;
        MyToolBar toolBar1;
        MyToolBar toolBar2;

        ColumnDefinition colDef1;
        ColumnDefinition colDef2;
        ColumnDefinition colDef3;
        RowDefinition rowDef1;
        RowDefinition rowDef2;
        RowDefinition rowDef3;

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

            //this.WindowStyle = WindowStyle.None;
            //this.AllowsTransparency = true;


            /*Windowのサイズ指定*/
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.WindowState = WindowState.Maximized;



            //TODO: ここで設定を変えるようにしないといけない
            maincontents = new MyMainContents();
            maincontents.SetWidth(1610);
            maincontents.SetHeight(855);
            maincontents.SetButton(4);


            contentsBar = new MyContentsBar();
            contentsBar.SetWidth(310);
            contentsBar.SetHeight(855);
            contentsBar.SetButton(1);


            toolBar1 = new MyToolBar();
            toolBar1.SetWidth(this.Width);
            toolBar1.SetHeight(165 - 30);
            toolBar1.SetButton(1);


            toolBar2 = new MyToolBar();
            toolBar2.SetWidth(this.Width);
            toolBar2.SetHeight(20);
            toolBar2.SetButton(1);

            /*初期化メソッドの宣言*/
            //T
            this.GridInit();
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
                //Background = Brushes.Aquamarine,
                #if DEBUG
                ShowGridLines = true
                #endif

            };

            this.AddChild(maingrid);
            this.CompornentInit();
            String layoutNum = "1";

        }

       


        /// <summary>
        /// コンポーネントの読み込み
        /// </summary>
        private void CompornentInit()
        {
            //TODO : レイアウトのセッティングファイルを読み取る→ ここに値を入れる

            //String layoutName = "PowerPoint";
            Console.WriteLine("aaaaaok");
            //とりあえずここではサイズを
            //PowerPointの場合
            //TODO : レイアウトを読み込み反映する
            /*
            maincontents = new MyMainContents(this.Width * (1610 / 1920), this.Height * (855 / 1040));
            contentsBar = new MyContentsBar(this.Width * (310 / 1920), this.Height * (855 / 1040));
            toolBar1 = new MyToolBar(this.Width, this.Height * (165 / 1920));
            toolBar2 = new MyToolBar(this.Width, this.Height * (20 / 1920));
            */
            //35


            //Column : 行 Width
            colDef1 = new ColumnDefinition { Width = new GridLength(contentsBar.GetWidth()) };
            colDef2 = new ColumnDefinition { Width = new GridLength(maincontents.GetWidth()) };
            colDef3 = new ColumnDefinition { Width = new GridLength(0) };
            //Row : 列 Height
            rowDef1 = new RowDefinition { Height = new GridLength(toolBar1.GetHeight()) };
            rowDef2 = new RowDefinition { Height = new GridLength(contentsBar.GetHeight()) };
            rowDef3 = new RowDefinition { Height = new GridLength(toolBar2.GetHeight()) };

            maingrid.ColumnDefinitions.Add(colDef1);
            maingrid.ColumnDefinitions.Add(colDef2);
            maingrid.ColumnDefinitions.Add(colDef3);

            maingrid.RowDefinitions.Add(rowDef1);
            maingrid.RowDefinitions.Add(rowDef2);
            maingrid.RowDefinitions.Add(rowDef3);



            //maincontents
            Grid.SetColumn(maincontents.mainContentsGrid, 1);
            Grid.SetRow(maincontents.mainContentsGrid, 1);
            maingrid.Children.Add(maincontents.mainContentsGrid);
            //contentsBar
            Grid.SetColumn(contentsBar.myContentsBarGrid, 0);
            Grid.SetRow(contentsBar.myContentsBarGrid, 1);
            maingrid.Children.Add(contentsBar.myContentsBarGrid);
            //toolBar1
            Grid.SetColumn(toolBar1.myToolBarGrid, 0);
            Grid.SetRow(toolBar1.myToolBarGrid, 0);
            Grid.SetColumnSpan(toolBar1.myToolBarGrid, 2);
            maingrid.Children.Add(toolBar1.myToolBarGrid);
            //toolBar2
            Grid.SetColumn(toolBar2.myToolBarGrid, 0);
            Grid.SetRow(toolBar2.myToolBarGrid, 2);
            Grid.SetColumnSpan(toolBar2.myToolBarGrid, 2);
            maingrid.Children.Add(toolBar2.myToolBarGrid);

        }

        internal static void SendButtonClickDate(int v)
        {
            maingrid.Children.Remove(maincontents.mainContentsGrid);
            
            
            
            //maincontents = maincontents_;
            //TODO: ここで設定を変えるようにしないといけない
            maincontents = new MyMainContents();
            maincontents.SetWidth(1610);
            maincontents.SetHeight(855);
            maincontents.SetButton(v);

            //maincontents
            Grid.SetColumn(maincontents.mainContentsGrid, 1);
            Grid.SetRow(maincontents.mainContentsGrid, 1);
            maingrid.Children.Add(maincontents.mainContentsGrid);
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
