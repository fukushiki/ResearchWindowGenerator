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
        static double WindowWidth;
        static double WindowHeight;
        /*コンポーネントの宣言*/
        /*Grid*/
        static Grid maingrid;

        /*機能*/
        static MyMainContents maincontents;
        static MyContentsBar contentsBar;
        static MyToolBar toolBar1;
        static MyToolBar2 toolBar2;
        static MyToolBar3 toolBar3;

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


        /*レイアウト*/
        static int LayoutNum;
        static int ContentsBarNum;
        static int ToolBarNum;
        static int MainContentsNum;

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

            WindowWidth = this.Width;
            WindowHeight = this.Height;

            LoadSetting();


            InitToolBar(ToolBarNum);
            InitContentsBar(ContentsBarNum);
            InitmainContents(1);

            this.Title = "Layout"+LayoutNum+", ToolBar" + ToolBarNum + ", ContentsBar" + ContentsBarNum;
            
            


            

            /*初期化メソッドの宣言*/
            //T
            this.GridInit();

            this.LogSetting();
        }

        public static void LoadSetting()
        {
            /**
             * Layoutの種類
             * 1 : PowerPoint
             * 2 : カレンダー
            **/

            LayoutNum = 2;
            

            /**
             * ToolBar
             **/

            ToolBarNum = LayoutNum;


            /**
             * ContentsBarの種類
             * 1 : 縦一列
             * 2 : Grid
             **/

            ContentsBarNum = 2;

            

            /**
             * MainContentsの初期配置
            */

            MainContentsNum = 3;

            
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
            this.CompornentInit(LayoutNum);
            

        }

       


        /// <summary>
        /// コンポーネントの読み込み
        /// </summary>
        private void CompornentInit(int v)
        {
            //TODO : レイアウトのセッティングファイルを読み取る→ ここに値を入れる

            //String layoutName = "PowerPoint";
            //Console.WriteLine("aaaaaok");
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


            switch (v)
            {
                case (1):
                    //Column : 行 Width
                    colDef1 = new ColumnDefinition { Width = new GridLength(contentsBar.GetWidth()) };
                    colDef2 = new ColumnDefinition { Width = new GridLength(maincontents.GetWidth()) };
                    colDef3 = new ColumnDefinition { Width = new GridLength(0) };

                    Console.WriteLine(colDef1.Width + "; " + colDef2.Width + "; " + colDef3.Width + "");
                    //Row : 列 Height
                    rowDef1 = new RowDefinition { Height = new GridLength(toolBar1.GetHeight()) };
                    rowDef2 = new RowDefinition { Height = new GridLength(contentsBar.GetHeight())};
                    rowDef3 = new RowDefinition { Height = new GridLength(toolBar2.GetHeight()) };
                    Console.WriteLine(rowDef1.Height + "; " + rowDef2.Height + "; " + rowDef3.Height + "");

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
                    break;
                case (2):
                    //Column : 行 Width
                    colDef1 = new ColumnDefinition { Width = new GridLength(contentsBar.GetWidth()) };
                    colDef2 = new ColumnDefinition { Width = new GridLength(maincontents.GetWidth()) };
                  
                    //Row : 列 Height
                    rowDef1 = new RowDefinition { Height = new GridLength(toolBar1.GetHeight()) };
                    rowDef2 = new RowDefinition { Height = new GridLength(contentsBar.GetHeight()) };
                    
                    maingrid.ColumnDefinitions.Add(colDef1);
                    maingrid.ColumnDefinitions.Add(colDef2);
                    
                    maingrid.RowDefinitions.Add(rowDef1);
                    maingrid.RowDefinitions.Add(rowDef2);
                    


                    //maincontents
                    Grid.SetColumn(maincontents.mainContentsGrid, 1);
                    Grid.SetRow(maincontents.mainContentsGrid, 1);
                    maingrid.Children.Add(maincontents.mainContentsGrid);
                    //contentsBar
                    /*
                    Grid.SetColumn(contentsBar.myContentsBarGrid, 0);
                    Grid.SetRow(contentsBar.myContentsBarGrid, 0);
                    Grid.SetRowSpan(contentsBar.myContentsBarGrid, 2);
                    maingrid.Children.Add(contentsBar.myContentsBarGrid);
                    */
                    //contentsBar
                    Grid.SetColumn(contentsBar.myContentsBarGrid, 0);
                    Grid.SetRow(contentsBar.myContentsBarGrid, 0);
                    Grid.SetRowSpan(contentsBar.myContentsBarGrid, 2);
                    maingrid.Children.Add(contentsBar.myContentsBarGrid);


                    //toolBar1
                    Grid.SetColumn(toolBar1.myToolBarGrid, 1);
                    Grid.SetRow(toolBar1.myToolBarGrid, 0);
                    maingrid.Children.Add(toolBar1.myToolBarGrid);
                    
                    
                    break;
                case (3)://PDFType
                    //Column : 行 Width
                    colDef1 = new ColumnDefinition { Width = new GridLength(contentsBar.GetWidth()) };
                    colDef2 = new ColumnDefinition { Width = new GridLength(maincontents.GetWidth()) };
                    colDef3 = new ColumnDefinition { Width = new GridLength(toolBar3.GetWidth()) };

                    Console.WriteLine(colDef1.Width + "; " + colDef2.Width + "; " + colDef3.Width + "");
                    //Row : 列 Height
                    rowDef1 = new RowDefinition { Height = new GridLength(toolBar1.GetHeight()) };
                    rowDef2 = new RowDefinition { Height = new GridLength(contentsBar.GetHeight()) };
                    rowDef3 = new RowDefinition { Height = new GridLength(0) };
                    Console.WriteLine(rowDef1.Height + "; " + rowDef2.Height + "; " + rowDef3.Height + "");

                    maingrid.ColumnDefinitions.Add(colDef1);
                    maingrid.ColumnDefinitions.Add(colDef2);
                    maingrid.ColumnDefinitions.Add(colDef3);

                    maingrid.RowDefinitions.Add(rowDef1);
                    maingrid.RowDefinitions.Add(rowDef2);
                    //maingrid.RowDefinitions.Add(rowDef3);



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
                    Grid.SetColumnSpan(toolBar1.myToolBarGrid, 3);
                    maingrid.Children.Add(toolBar1.myToolBarGrid);
                    //toolBar3
                    Grid.SetColumn(toolBar3.myToolBarGrid, 2);
                    Grid.SetRow(toolBar3.myToolBarGrid, 1);
                    //Grid.SetColumnSpan(toolBar3.myToolBarGrid, 2);
                    maingrid.Children.Add(toolBar3.myToolBarGrid);
                    break;
            }



            

        }

        internal static void InitToolBar(int v)
        {


            switch (v)
            {
                case (1):
                    toolBar1 = new MyToolBar(1);
                    toolBar1.SetWidth(WindowWidth);
                    toolBar1.SetHeight(165 - 30);
                    toolBar1.SetButton(1);


                    toolBar2 = new MyToolBar2(2);
                    toolBar2.SetWidth(WindowWidth);
                    toolBar2.SetHeight(20);
                    toolBar2.SetButton(1);
                    break;
                case (2):
                    toolBar1 = new MyToolBar(1);
                    toolBar1.SetWidth(1755);
                    //toolBar1.SetHeight(75 - 30);
                    toolBar1.SetHeight(60);
                    toolBar1.SetButton(2);
                    ;
                    break;
                case (3):
                    toolBar1 = new MyToolBar(1);
                    toolBar1.SetWidth(WindowWidth);
                    toolBar1.SetHeight(130 - 30);
                    toolBar1.SetButton(3);


                    toolBar3 = new MyToolBar3(3);
                    toolBar3.SetWidth(310);
                    toolBar3.SetHeight(910);
                    toolBar3.SetButton(1);
                    break;
            }





        }


        internal static void InitContentsBar(int v)
        {
            contentsBar = new MyContentsBar();
            if (LayoutNum == 3)
            {
                switch (v)
                {
                    case (1):
                        contentsBar.SetWidth(310);
                        contentsBar.SetHeight(WindowHeight - (20 + toolBar1.GetHeight()));
                        contentsBar.SetButton(1);
                        ;
                        break;
                    case (2):
                        //TODO : ここあとで変える
                        contentsBar.SetWidth(310);
                        contentsBar.SetHeight(WindowHeight - (toolBar1.GetHeight()));
                        contentsBar.SetButton(2);
                        ;
                        break;
                    case (3):
                        //TODO : ここあとで変える
                        contentsBar.SetWidth(310);
                        contentsBar.SetHeight(WindowHeight - (toolBar1.GetHeight()));
                        contentsBar.SetButton(1);
                        ;
                        break;

                }
            }
            else
            {
                switch (v)
                {
                    case (1):
                        contentsBar.SetWidth(310);
                        if(LayoutNum == 1)
                        {
                            contentsBar.SetHeight(WindowHeight - (20 + toolBar1.GetHeight() + toolBar2.GetHeight()));
                        }
                        else
                        {
                            contentsBar.SetHeight(WindowHeight - (toolBar1.GetHeight() ));
                        }
                        
                        
                        contentsBar.SetButton(1);
                        ;
                        break;
                    case (2):
                        //TODO : ここあとで変える
                        contentsBar.SetWidth(310);
                        contentsBar.SetHeight(WindowHeight - (toolBar1.GetHeight()));
                        contentsBar.SetButton(2);
                        ;
                        break;
                    case (3):
                        //TODO : ここあとで変える
                        contentsBar.SetWidth(265);
                        contentsBar.SetHeight(WindowHeight - (toolBar1.GetHeight()));
                        contentsBar.SetButton(1);
                        ;
                        break;

                }
            }
            
            
        }


        internal static void InitmainContents(int v)
        {
            //maincontents = maincontents_;
            //TODO: ここで設定を変えるようにしないといけない
            maincontents = new MyMainContents();
            /*
            maincontents.SetWidth(1610);
            maincontents.SetHeight(855);
            maincontents.SetButton(v);
            */
            if(LayoutNum == 3)
            {
                maincontents.SetWidth(WindowWidth - contentsBar.GetWidth() - toolBar3.GetWidth()) ;
                maincontents.SetHeight(contentsBar.GetHeight());
                maincontents.SetButton(v);
            }
            else
            {
                maincontents.SetWidth(WindowWidth - contentsBar.GetWidth());
                maincontents.SetHeight(contentsBar.GetHeight());
                maincontents.SetButton(v);
            }

            


            //maincontents

        }

        public static void ChangeMaincontents(int v)
        {
            Console.WriteLine(v);
            maingrid.Children.Remove(maincontents.mainContentsGrid);

            maincontents = new MyMainContents();

            if (LayoutNum == 3)
            {
                maincontents.SetWidth(WindowWidth - contentsBar.GetWidth() - toolBar3.GetWidth());
                maincontents.SetHeight(contentsBar.GetHeight());
                maincontents.SetButton(v);
                //maincontents
                Grid.SetColumn(maincontents.mainContentsGrid, 1);
                Grid.SetRow(maincontents.mainContentsGrid, 1);
            }
            else
            {
                maincontents.SetWidth(WindowWidth - contentsBar.GetWidth());
                maincontents.SetHeight(contentsBar.GetHeight());
                maincontents.SetButton(v);
                //maincontents
                Grid.SetColumn(maincontents.mainContentsGrid, 1);
                Grid.SetRow(maincontents.mainContentsGrid, 1);
            }
            
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
