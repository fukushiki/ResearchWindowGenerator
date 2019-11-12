using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ResearchWindowGenerator.ResearchWindowFolder
{
    public class MyToolBar
    {
        private double Width;
        private double Height;

        public StackPanel stackPanel;

        List<Button[]> buttonList;
        List<Button[]> buttonList1;
        List<Button[]> buttonList2;
        List<Button[]> buttonList3;
        List<StackPanel[]> stackPanelList;

        public Grid myToolBarGrid;
        int GridRow;
        int GridColumn;


        Grid ButtonList1_Grid;
        Grid ButtonList2_Grid;
        Grid ButtonList3_Grid;

        double gridHeight;
        double gridWidth;


        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;
        int ToolBarTypeNum;


        public MyToolBar(int n)
        {
            ToolBarTypeNum = n;



            
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

        /// <summary>
        /// ボタンのセッティング
        /// </summary>
        /// <param name="_button_num"></param>
        public void SetButton(int _button_num)
        {

            
            switch (_button_num)
            {
                case (1):
                    GridRow = 1;
                    GridColumn = 3;
                    
                    SetGrid();
                    SetButtonList1(0);
                    SetButtonList2(1);
                    SetButtonList3(2);
                    
                    break;
                
                    
                default:
                    ;
                    break;
            }

            
            
            //SetButtonList();
            //SetStackPanels();
            //ButtonPlace();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList()
        {
            buttonList = new List<Button[]>();
            for (int i = 0; i < GridRow; i++)
            {
                Button[] button = new Button[GridColumn];
                for (int j = 0; j < GridColumn; j++)
                {
                    button[j] = new Button { };
                    button[j].Click += ToolBarButton_Clicked;

                }
                
                buttonList.Add(button);


            }

        }

        /// <summary>
        /// PowerPointTypeの一部
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList1(int placenum)
        {
            ButtonList1_Grid = new Grid {
                Width = this.Width/3,
                Height = this.Height,
                ShowGridLines = true,
                Background = Brushes.AliceBlue
            };

            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40)/3) });
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);
            ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList1_Grid.Width/3) });
            ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20 * 9) });
            ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList1_Grid.Width/3) });


            myToolBarGrid.Children.Add(ButtonList1_Grid);
            Grid.SetColumn(ButtonList1_Grid, placenum);

            


            buttonList1 = new List<Button[]>();
            int buttonRow = 2;
            int buttonColumn = 9;
            for (int i = 0; i < buttonRow ; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid {
                    Width = ButtonList1_Grid.Width,
                    Height = 20,
                    Background = Brushes.Azure,
                    ShowGridLines = true
                };

                if(i == 0)
                {
                    ButtonList1_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 1);
                    Grid.SetColumn(buttonGrid, 1);


                }
                else
                {
                    ButtonList1_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 3);
                    Grid.SetColumn(buttonGrid, 1);
                }


                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                    button[j] = new Button { Width = 20, Height = 20};
                    button[j].Name = "buttonL1" + "C" + j + "R" + i;
                    button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList1.Add(button);
                

            }
            TextBlock textblock = new TextBlock();
            textblock.Text = "1";
            textblock.FontSize = ButtonList1_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList1_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);
            









        }

        /// <summary>
        /// Calenderタイプの一部
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList2(int placenum)
        {
            ButtonList2_Grid = new Grid
            {
                Width = this.Width / 3,
                Height = this.Height,
                ShowGridLines = true,
                Background = Brushes.AliceBlue
            };

            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);
            ButtonList2_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList2_Grid.Width / 3) });
            ButtonList2_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20 * 9) });
            ButtonList2_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList2_Grid.Width / 3) });


            myToolBarGrid.Children.Add(ButtonList2_Grid);
            Grid.SetColumn(ButtonList2_Grid, placenum);




            buttonList2 = new List<Button[]>();
            int buttonRow = 2;
            int buttonColumn = 9;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    Width = ButtonList2_Grid.Width,
                    Height = 20,
                    Background = Brushes.Azure,
                    ShowGridLines = true
                };

                if (i == 0)
                {
                    ButtonList2_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 1);
                    Grid.SetColumn(buttonGrid, 1);


                }
                else
                {
                    ButtonList2_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 3);
                    Grid.SetColumn(buttonGrid, 1);
                }


                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                    button[j] = new Button { Width = 20, Height = 20 };
                    button[j].Name = "buttonL1" + "C" + j + "R" + i;
                    button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList2.Add(button);


            }

            TextBlock textblock = new TextBlock();
            textblock.Text = "2";
            textblock.FontSize = ButtonList2_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList2_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);

        }

        /// <summary>
        /// PDFタイプ
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList3(int placenum)
        {
            ButtonList3_Grid = new Grid
            {
                Width = this.Width / 3,
                Height = this.Height,
                ShowGridLines = true,
                Background = Brushes.AliceBlue
            };

            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 3) });
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);
            ButtonList3_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList3_Grid.Width / 3) });
            ButtonList3_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20 * 9) });
            ButtonList3_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList3_Grid.Width / 3) });


            myToolBarGrid.Children.Add(ButtonList3_Grid);
            Grid.SetColumn(ButtonList3_Grid, placenum);




            buttonList3 = new List<Button[]>();
            int buttonRow = 2;
            int buttonColumn = 9;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    Width = ButtonList3_Grid.Width,
                    Height = 20,
                    Background = Brushes.Azure,
                    ShowGridLines = true
                };

                if (i == 0)
                {
                    ButtonList3_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 1);
                    Grid.SetColumn(buttonGrid, 1);


                }
                else
                {
                    ButtonList3_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 3);
                    Grid.SetColumn(buttonGrid, 1);
                }


                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                    button[j] = new Button { Width = 20, Height = 20 };
                    button[j].Name = "buttonL1" + "C" + j + "R" + i;
                    button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList3.Add(button);


            }
            TextBlock textblock = new TextBlock();
            textblock.Text = "3";
            textblock.FontSize = ButtonList1_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList3_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);

        }

        private void SetGrid()
        {
            myToolBarGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.GreenYellow,
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
                rowDef[gridRow_num] = new RowDefinition { Height = new GridLength(gridHeight) };
                myToolBarGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < GridColumn; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                myToolBarGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetStackPanels()
        {
            stackPanelList = new List<StackPanel[]>();
            for (int i = 0; i < GridRow; i++)
            {
                StackPanel[] stackPanels = new StackPanel[GridColumn];
                for (int j = 0; j < GridColumn; j++)
                {


                    stackPanels[j] = new StackPanel
                    {
                        //TODO: StackPanelの中身を2~のやつも作る
                        Width = gridWidth,
                        Height = gridHeight,


                    };

                    

                    //一覧
                    //並べて表示
                    //コンテンツ
                }
                stackPanelList.Add(stackPanels);

            }


        }

        private void ButtonPlace()
        {
            for (int i = 0; i < GridRow; i++)
            {
                
                for (int j = 0; j < GridColumn; j++)
                {

                    //一覧
                    //並べて表示
                    //コンテンツ
                    buttonList[i][j].Width = this.myToolBarGrid.Width * 0.9;
                    buttonList[i][j].Height = this.myToolBarGrid.Height * 0.9;

                    //stackPanelList[i][j].Children.Add(buttonList[i][j]);



                    //BigIcon

                    //https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.controls.contentcontrol.content?view=netframework-4.8#System_Windows_Controls_ContentControl_Content
                    //https://www.it-swarm.net/ja/c%23/wpfボタンに画像を追加する/1041237631/
                    /*
                    Image img = new Image();
                    Uri uri = new Uri(System.IO.Path.GetFullPath("../../../ImageFolder/food_nabe_mizutaki.png"), UriKind.RelativeOrAbsolute);
                    img.Source = new BitmapImage(uri);
                    */
                    //stackPanelList[i][j].Children.Add(img);

                    /*画像部*/
                    //BitmapImage img = new BitmapImage();
                    //Uri uri = new Uri(System.IO.Path.GetFullPath("../../../ImageFolder/food_nabe_mizutaki.png"), UriKind.RelativeOrAbsolute);

                    //Image img = new Image();
                    //img.Source = new BitmapImage(uri);
                    //buttonList[i][j].Content = img;
                    //img.Source = new BitmapImage(uri);
                    /*
                    img.BeginInit();
                    img.UriSource = uri;
                    img.EndInit();
                    */
                    Ellipse ellipse1 = new Ellipse();

                    ellipse1.Width = 40;
                    ellipse1.Height =500;
                    ellipse1.Fill = Brushes.Yellow;

                    




                    /*
                    stackPanelList[i][j].Orientation = Orientation.Horizontal;
                    stackPanelList[i][j].Margin = new Thickness(10);*/
                    //stackPanelList[i][j].Children.Add(img);

                    //buttonList[i][j].Content = new ImageBrush(img);  

                    //buttonList[i][j].Content = stackPanelList[i][j];
                    //buttonList[i][j].Background = Brushes.Pink;
                    //https://garafu.blogspot.com/2015/12/wpf-image-button.html

                    Label label = new Label
                    {
                        Content = "Row:" + i + ", Col:" + j,
                    };
                    
                    stackPanelList[i][j].Children.Add(ellipse1);
                    stackPanelList[i][j].Children.Add(label);
                    //buttonList[i][j].Content = "aaaaaaaaaaa";

                    //this.myToolBarGrid.Children.Add(buttonList[i][j]);
                    //Grid.SetRow(buttonList[i][j], i);
                    //Grid.SetColumn(buttonList[i][j], j);
                    

                    /*
                    this.myToolBarGrid.Children.Add(stackPanelList[i][j]);
                    Grid.SetRow(stackPanelList[i][j], i);
                    Grid.SetColumn(stackPanelList[i][j], j);
                    */
                }
                
            }
            DoEvents();
            this.myToolBarGrid.Children.Add(ButtonList1_Grid);
            Grid.SetRow(ButtonList1_Grid, 0);
            Grid.SetColumn(ButtonList1_Grid, 0);


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

        private void LoadBigIconButton()
        {
            
        }



        private void ToolBarButton_Clicked(object sender, RoutedEventArgs e)
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