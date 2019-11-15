using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ResearchWindowGenerator.ResearchWindowFolder
{
    public class MyMainContents
    {
        private double Width;
        private double Height;
        public StackPanel stackPanel;

        List<Button[]> buttonList;
        List<StackPanel[]> stackPanelList;

        public Grid mainContentsGrid;
        int GridRow;
        int GridColumn;

        double gridHeight;
        double gridWidth;


        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;

        ColumnDefinition colDef_;
        RowDefinition rowDef_;



        /// <summary>
        /// 値設定のコンストラクタ
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public MyMainContents()
        {
        }

        public double GetWidth()
        {
            return this.Width;
        }


        

        public double GetHeight()
        {
            return this.Height;
        }

        public void SetWidth(double w)
        {
            this.Width = w;
        }

        public void SetHeight(double h)
        {
            this.Height = h;
        }


        /*
        public void SetButton__(int v)
        {
            SetButton(v);
        }*/


        /// <summary>
        /// ボタンのセッティング
        /// </summary>
        /// <param name="_button_num"></param>
        public void SetButton(int _button_num)
        {
            switch (_button_num)
            {
                case (1):
                    GridRow = 6;
                    GridColumn = 15;
                    SetButtonList();
                    SetGrid();
                    SetStackPanels(1);
                    break;
                case (2):
                    GridRow = 40;
                    GridColumn = 5;
                    SetButtonList();
                    SetGrid();
                    SetStackPanels(2);
                    break;
                case (3):
                    GridRow = 15;
                    GridColumn = 6;
                    SetButtonList();
                    SetGrid();
                    SetStackPanels(3);
                    break;
                case (4):
                    GridRow = 17;
                    GridColumn = 1;
                    SetButtonList();
                    SetGrid();
                    SetStackPanels(4);
                    break;
                
                case (5):
                    RandomButtonPlace();
                    break;
                default:
                    ;
                    break;
            }
        }


        private void RandomButtonPlace()
        {
            mainContentsGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.Red,
                ShowGridLines = true
            };

            //GridRow 行
            //GridColumn 列
            gridHeight = this.Height;
            gridWidth = this.Width;

            rowDef_ = new RowDefinition {Height = new GridLength(gridHeight) };
            colDef_ = new ColumnDefinition { Width = new GridLength(gridWidth) };

            //オブジェクトを複数配置
            //オブジェクトの中をタッチしたら外枠を点線へ
            //TOOLBarで色を変えられるようにする





        }


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList()
        {
            buttonList= new List<Button[]>();
            for(int i = 0; i < GridRow; i++)
            {
                Button[] button = new Button[GridColumn];
                for(int j = 0; j < GridColumn; j++)
                {
                    button[j] = new Button();
                    button[j].Click += MyMainContentsButton_Clicked;
                    button[j].Name = "C"+j+"R"+i;
                }
                buttonList.Add(button);
            }
            
        }

        private void SetGrid()
        {
            mainContentsGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.Red,
                ShowGridLines = true
            };

            //GridRow 行
            //GridColumn 列
            gridHeight = this.Height / GridRow;
            gridWidth = this.Width / GridColumn;

            rowDef = new RowDefinition[GridRow];
            colDef = new ColumnDefinition[GridColumn];

            //行の設定
            for (int gridRow_num = 0; gridRow_num < GridRow; gridRow_num++)
            {
                rowDef[gridRow_num] = new RowDefinition {Height = new GridLength(gridHeight) };
                mainContentsGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < GridColumn; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                mainContentsGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }

        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        public void SetStackPanels(int _maingrid_layoutnum)
        {
            stackPanelList = new List<StackPanel[]>();


            List<int> numberList = new List<int>();
            for (int num = 1; num < (((GridRow - 1) * (GridColumn - 1))); num++)
            {
                Console.WriteLine("天空橋" + num);
                numberList.Add(num);
            }

            Random r = new Random();
            numberList = numberList.OrderBy(a => r.Next(numberList.Count)).ToList();
            //numberListbuffer = numberList;



            string[] files = Directory.GetFiles("../../../ImageFolder", "*");
            List<Uri> uriList = new List<Uri>();
            int x = 0;
            foreach (string str in files)
            {
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + x);
                uriList.Add(new Uri(System.IO.Path.GetFullPath(str), UriKind.RelativeOrAbsolute));
                x++;
            }

            uriList = uriList.OrderBy(a => r.Next(uriList.Count)).ToList();
            //numberListbuffer = numberList;







            int counter = 0;
            for (int i = 0; i < GridRow; i++)
            {
                StackPanel[] stackPanels = new StackPanel[GridColumn];
                for (int j = 0; j < GridColumn; j++)
                {

                    
                    stackPanels[j] = new StackPanel { 
                        //TODO: StackPanelの中身を2~のやつも作る
                        Width = gridWidth,
                        Height = gridHeight,
                        
                        
                    };

                    System.Random r_ = new System.Random(1000);
                    //シード値を指定しないとシード値として Environment.TickCount が使用される
                    //System.Random r = new System.Random();

                    //0以上10未満の乱数を整数で返す
                    int i1 = r_.Next(i+j);
                    Grid contentsGrid = new Grid
                    {
                        Width = stackPanels[j].Width,
                        Height = stackPanels[j].Height,
                        #if DEBUG
                        ShowGridLines = true,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
#endif
                    };
                    stackPanels[j].Children.Add(contentsGrid);

                    Image img = new Image();
                    //Console.WriteLine("aaaaaaaaaa" + ((i + j).ToString()));
                    //img.Source = new BitmapImage(uriList[GridRow * (i - 1) + j + 2 ]);
                    //Console.WriteLine((i * GridRow).ToString() +"/"+ j.ToString());
                    //Console.WriteLine("眠たい"+counter);
                    //img.Source = new BitmapImage(uriList.ElementAt(counter));
                    img.Source = new BitmapImage(uriList.ElementAt(j+i+i1));
                    //Console.WriteLine("^^");
                    counter++;







                    TextBlock textBlock = new TextBlock {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    //textBlock.Text = "Row:" + i + ", Col:" + j;
                    textBlock.Text = (numberList.IndexOf((i * GridRow) + j)+2).ToString();
                    
                    textBlock.FontWeight = FontWeights.Bold;
                    //stackPanels[j].Children.Add(textBlock);

                    

                    //ここでそれぞれ_maingrid_layoutnumでmaincontentsの中身を変更する

                    ColumnDefinition colDef1;
                    ColumnDefinition colDef2;
                    ColumnDefinition colDef3;
                    RowDefinition rowDef1;
                    RowDefinition rowDef2;
                    RowDefinition rowDef3;

                    


                    switch (_maingrid_layoutnum)
                    {
                        case (1)://特大アイコン
                            //Row : 列 Height
                            rowDef1 = new RowDefinition { Height = new GridLength() };
                            rowDef2 = new RowDefinition { Height = new GridLength() };
                            contentsGrid.RowDefinitions.Add(rowDef1);
                            contentsGrid.RowDefinitions.Add(rowDef2);
                            contentsGrid.Children.Add(img);
                            contentsGrid.Children.Add(textBlock);
                            textBlock.FontSize = 30;
                            Grid.SetRow(img, 0);
                            Grid.SetRow(textBlock, 1);
                            break;
                        case (2)://一覧
                            //Column : 行 Width
                            colDef1 = new ColumnDefinition { Width = new GridLength() };
                            colDef2 = new ColumnDefinition { Width = new GridLength() };
                            contentsGrid.ColumnDefinitions.Add(colDef1);
                            contentsGrid.ColumnDefinitions.Add(colDef2);
                            contentsGrid.Children.Add(img);
                            contentsGrid.Children.Add(textBlock);
                            textBlock.FontSize = 20;
                            Grid.SetColumn(img, 0);
                            Grid.SetColumn(textBlock, 1);
                            break;
                        case (3)://並べて表示
                            //Column : 行 Width
                            colDef1 = new ColumnDefinition { Width = new GridLength() };
                            colDef2 = new ColumnDefinition { Width = new GridLength() };
                            contentsGrid.ColumnDefinitions.Add(colDef1);
                            contentsGrid.ColumnDefinitions.Add(colDef2);
                            contentsGrid.Children.Add(img);
                            textBlock.Text = "Row:" + i + ", Col:" + j+"\n"+"TXTファイル"+"\n"+"0バイト";
                            contentsGrid.Children.Add(textBlock);
                            textBlock.FontSize = 20;
                            Grid.SetColumn(img, 0);
                            Grid.SetColumn(textBlock, 1);
                            break;
                        case (4)://コンテンツ
                            //Column : 行 Width
                            colDef1 = new ColumnDefinition { Width = new GridLength() };
                            colDef2 = new ColumnDefinition { Width = new GridLength() };
                            colDef3 = new ColumnDefinition { Width = new GridLength() };
                            contentsGrid.ColumnDefinitions.Add(colDef1);
                            contentsGrid.ColumnDefinitions.Add(colDef2);
                            contentsGrid.ColumnDefinitions.Add(colDef3);
                            contentsGrid.Children.Add(img);
                            textBlock.FontSize = 30;
                            contentsGrid.Children.Add(textBlock);
                            TextBlock textBlock2 = new TextBlock
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                            };
                            textBlock2.Text = "更新日時: 2019/11/09 20:00" + "\n" + "サイズ: 0バイト";
                            //contentsGrid.Children.Add(textBlock2);

                            Grid.SetColumn(img, 0);
                            Grid.SetColumn(textBlock, 1);
                            Grid.SetColumn(textBlock2, 2);
                            break;
                        case (5)://ランダム表示
                            break;
                        default:
                            break;
                    };

                    buttonList[i][j].Content = stackPanels[j];
                    buttonList[i][j].Background = Brushes.Transparent;
                    this.mainContentsGrid.Children.Add(buttonList[i][j]);
                    Grid.SetRow(buttonList[i][j], i);
                    Grid.SetColumn(buttonList[i][j], j);




                }
                stackPanelList.Add(stackPanels);

            }
            

        }

        

        private void MyMainContentsButton_Clicked(object sender, RoutedEventArgs e)
        {
            /*
            if (((Button)sender).Content == "Start")
            {
                StartTimer();
                ((Button)sender).Content = "Finish";
                //System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
                //Logger.SaveMouseClickPosition(TimeCount, point.X, point.Y);

                Button sender1 = (System.Windows.Controls.Button)sender;
                Console.WriteLine("aaaaaaaaaa" + sender1.Name);


            }
            else if (((Button)sender).Content == "Finish")
            {
                StopTimer();
                ((Button)sender).Content = "End";
            }*/


            Button sender1 = (System.Windows.Controls.Button)sender;
            Console.WriteLine("aaaaaaaaaa" + sender1.Name);

        }

    }
}