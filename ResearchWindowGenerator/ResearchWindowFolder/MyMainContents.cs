using System;
using System.Collections.Generic;
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


                    Image img = new Image();
                    Uri uri = new Uri(System.IO.Path.GetFullPath("../../../ImageFolder/PowerPoint.png"), UriKind.RelativeOrAbsolute);
                    img.Source = new BitmapImage(uri);
                    //stackPanels[j].Children.Add(img);

                    TextBlock textBlock = new TextBlock {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    textBlock.Text = "Row:" + i + ", Col:" + j;
                    //stackPanels[j].Children.Add(textBlock);

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
                            contentsGrid.Children.Add(textBlock);
                            TextBlock textBlock2 = new TextBlock
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                            };
                            textBlock2.Text = "更新日時: 2019/11/09 20:00" + "\n" + "サイズ: 0バイト";
                            contentsGrid.Children.Add(textBlock2);

                            Grid.SetColumn(img, 0);
                            Grid.SetColumn(textBlock, 1);
                            Grid.SetColumn(textBlock2, 2);
                            break;
                        case (5)://ランダム表示

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