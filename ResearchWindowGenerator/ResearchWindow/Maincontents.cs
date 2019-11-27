using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ResearchWindowGenerator.ResearchWindowFolder
{
    class MainContents
    {
        private double Width;
        private double Height;
        public Grid mainContentsGrid;
        int MainContentsNum;


        int GridRow;
        int GridColumn;
        double gridHeight;
        double gridWidth;
        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;

        public StackPanel stackPanel;

        List<Button[]> buttonList;
        List<StackPanel[]> stackPanelList;


        ColumnDefinition colDef_;
        RowDefinition rowDef_;



        static int MainContentsCreateCount = 0;

        /// <summary>
        /// MainContentsの生成番号
        /// </summary>
        private int MainContentsNumber;

        /// <summary>
        /// メインコンテンツの種類 1: 2: 3: 4: 5: 
        /// </summary>
        private int MainContentsGridTypeNum;

        public MainContents()
        {
            MainContentsCreateCount++;
            MainContentsNumber = MainContentsCreateCount;
            
            
        }
        internal void SetGridsOrder(int num)
        {
            MainContentsGridTypeNum = num;
            SetGrid();
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




        private void SetGrid()
        {
            mainContentsGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.GreenYellow,
                //ShowGridLines = true
#if DEBUG
                Background = Brushes.DarkOrange,
                ShowGridLines = true
# endif
            };

            


            //ToolBarOrderの順で定義していく
            
                Console.WriteLine("debug:MainContentsGridType:::::" + MainContentsGridTypeNum);
            
            
            switch (MainContentsGridTypeNum)
            {


                case 1:
                    //6 15
                    SetButtonList(6,15);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(6, 15);

                    //ここでそれぞれ配置
                    SetStackPanels(6,15);



                    break;
                case 2:

                    SetButtonList(40, 5);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(40, 5);

                    //ここでそれぞれ配置
                    SetStackPanels(40, 5);
                    break;
                case 3:
                    SetButtonList(15, 6);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(15, 6);

                    //ここでそれぞれ配置
                    SetStackPanels(15, 6);

                    break;
                case 4:
                    SetButtonList(17, 1);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(17, 1);

                    //ここでそれぞれ配置
                    SetStackPanels(17, 1);

                    break;
                case 5:
                    
                    break;
            }





        }


        private void SetButtonList(int row_, int column_)
        {
            buttonList = new List<Button[]>();
            for (int i = 0; i < row_; i++)
            {
                Button[] button = new Button[column_];
                for (int j = 0; j < column_; j++)
                {
                    button[j] = new Button();
                    //button[j].Click += MyMainContentsButton_Clicked;
                    button[j].Name = "MainContents"+ MainContentsGridTypeNum +"C" + j + "R" + i;
                }
                buttonList.Add(button);
            }

        }



        private void GridSet(int row_, int column_)
        {
            gridHeight = this.Height / row_;
            gridWidth = this.Width / column_ ;

            rowDef = new RowDefinition[row_];
            colDef = new ColumnDefinition[column_];

            //行の設定
            for (int gridRow_num = 0; gridRow_num < row_; gridRow_num++)
            {
                rowDef[gridRow_num] = new RowDefinition { Height = new GridLength(gridHeight) };
                mainContentsGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < column_; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                mainContentsGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }
        }


        public void SetStackPanels(int row_, int column_)
        {
            stackPanelList = new List<StackPanel[]>();

            /*
            List<int> numberList = new List<int>();
            for (int num = 1; num < ((( - 1) * (column_ - 1))); num++)
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
            */






            int counter = 0;
            for (int i = 0; i < row_; i++)
            {
                StackPanel[] stackPanels = new StackPanel[column_];
                for (int j = 0; j < column_; j++)
                {


                    stackPanels[j] = new StackPanel
                    {
                        //TODO: StackPanelの中身を2~のやつも作る
                        Width = gridWidth,
                        Height = gridHeight,


                    };

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

                    /*
                    System.Random r_ = new System.Random(1000);
                    //シード値を指定しないとシード値として Environment.TickCount が使用される
                    //System.Random r = new System.Random();

                    //0以上10未満の乱数を整数で返す
                    int i1 = r_.Next(i + j);
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

                    
                    //Console.WriteLine("aaaaaaaaaa" + ((i + j).ToString()));
                    //img.Source = new BitmapImage(uriList[GridRow * (i - 1) + j + 2 ]);
                    //Console.WriteLine((i * GridRow).ToString() +"/"+ j.ToString());
                    //Console.WriteLine("眠たい"+counter);
                    //img.Source = new BitmapImage(uriList.ElementAt(counter));
                    img.Source = new BitmapImage(uriList.ElementAt(j + i + i1));
                    //Console.WriteLine("^^");
                    counter++;
                    */


                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"../../../ImageFolder/WebHook.png"), UriKind.RelativeOrAbsolute));

                    TextBlock textBlock = new TextBlock
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    //textBlock.Text = "Row:" + i + ", Col:" + j;
                   // textBlock.Text = (numberList.IndexOf((i * GridRow) + j) + 2).ToString();

                    textBlock.FontWeight = FontWeights.Bold;
                    //stackPanels[j].Children.Add(textBlock);



                    //ここでそれぞれ_maingrid_layoutnumでmaincontentsの中身を変更する

                    ColumnDefinition colDef1;
                    ColumnDefinition colDef2;
                    ColumnDefinition colDef3;
                    RowDefinition rowDef1;
                    RowDefinition rowDef2;
                    RowDefinition rowDef3;




                    switch (MainContentsGridTypeNum)
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
                            textBlock.Text = "Row:" + i + ", Col:" + j + "\n" + "TXTファイル" + "\n" + "0バイト";
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
                    //buttonList[i][j].Background = Brushes.Transparent;
                    this.mainContentsGrid.Children.Add(buttonList[i][j]);
                    Grid.SetRow(buttonList[i][j], i);
                    Grid.SetColumn(buttonList[i][j], j);




                }
                stackPanelList.Add(stackPanels);

            }


        }

    }
}
