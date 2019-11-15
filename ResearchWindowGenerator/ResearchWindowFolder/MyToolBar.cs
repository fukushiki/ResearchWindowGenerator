using System;
using System.Collections.Generic;
using System.Linq;
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

        List<int[]> buttonnumberList ;

        List<Button[]> buttonList;
        List<Button[]> buttonList1;
        List<Button[]> buttonList2;
        List<Button[]> buttonList3;
        List<Button[]> buttonList4;
        List<Button[]> buttonList5;
        List<StackPanel[]> stackPanelList;
        List<int> numberListbuffer = new List<int>();




        public Grid myToolBarGrid;
        int GridRow;
        int GridColumn;


        Grid ButtonList1_Grid;
        Grid ButtonList2_Grid;
        Grid ButtonList3_Grid;
        Grid ButtonList4_Grid;
        Grid ButtonList5_Grid;

        double gridHeight;
        double gridWidth;


        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;
        static int ToolBarTypeNum;

        double otherWidths = 0;


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

            

            GridRow = 1;
            GridColumn = 5;
            List<int> numberList = new List<int>();
            for (int num = 0; num < ((GridRow * GridColumn)); num++)
            {
                numberList.Add(num);
            }

            /*
            buttonnumberList = new List<int[]>();
            for (int i = 0; i < GridRow; i++)
            {
                Button[] button = new Button[GridColumn];
                for (int j = 0; j < GridColumn; j++)
                {
                    button[j] = new Button { };
                    button[j].Click += ToolBarButton_Clicked;

                }

                buttonList.Add(button);


            }*/
            Random r = new Random();
            numberList = numberList.OrderBy(a => r.Next(numberList.Count)).ToList();
            numberListbuffer = numberList;




            Console.WriteLine("//=================");
            Console.WriteLine(numberList.IndexOf(0));
            Console.WriteLine(numberList.IndexOf(1));
            Console.WriteLine(numberList.IndexOf(2));
            Console.WriteLine(numberList.IndexOf(3));
            Console.WriteLine(numberList.IndexOf(4));




            SetButtonList1(numberList.IndexOf(0));
            SetButtonList2(numberList.IndexOf(1));
            SetButtonList3(numberList.IndexOf(2));
            SetButtonList4(numberList.IndexOf(3));
            SetButtonList5(numberList.IndexOf(4));


            
            
            switch (_button_num)
            {
                case (1):
                    otherWidths = (this.Width - (ButtonList1_Grid.Width + ButtonList2_Grid.Width + ButtonList3_Grid.Width + ButtonList4_Grid.Width + ButtonList5_Grid.Width)) / 2;
                    break;
                case (2):
                    //otherWidths = (this.Width - (ButtonList1_Grid.Width + ButtonList2_Grid.Width + ButtonList3_Grid.Width + ButtonList4_Grid.Width + ButtonList5_Grid.Width)) / 2;
                    break;
                case (3):
                    otherWidths = (this.Width - (ButtonList1_Grid.Width + ButtonList2_Grid.Width + ButtonList3_Grid.Width + ButtonList4_Grid.Width + ButtonList5_Grid.Width)) / 2;
                    break;
                default:
                    ;
                    break;
            }


            SetGrid(numberListbuffer);

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
            //Console.WriteLine("Setbuttonlist1" + placenum);
            ButtonList1_Grid = new Grid {
                Width = 160,
                //Width = 60+20*9,
                
                Height = this.Height,
                //ShowGridLines = true,
                //Background = Brushes.Blue
            };

            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 2) });
            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList1_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 40) / 2) });
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);
            ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60))});
            ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList1_Grid.Width - 60) });
            //ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });


            
            


            buttonList1 = new List<Button[]>();
            int buttonRow = 2;
            int buttonColumn = 5;
            for (int i = 0; i < buttonRow ; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid {
                    Width = ButtonList1_Grid.Width,
                    Height = 20,
                    //Background = Brushes.Azure,
                    //ShowGridLines = true
                };

                
                ButtonList1_Grid.Children.Add(buttonGrid);
                Grid.SetRow(buttonGrid, i + 1);
                Grid.SetColumn(buttonGrid, 1);

                    for (int j = 0; j < buttonColumn; j++)
                    {
                        buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                        button[j] = new Button { Width = 20, Height = 20 };
                        button[j].Name = "buttonL1" + "C" + j + "R" + i;
                        button[j].Click += ToolBarButton_Clicked;
                        buttonGrid.Children.Add(button[j]);
                        Grid.SetColumn(button[j], j);

                    }


                
                


                

                buttonList1.Add(button);
                

            }
            TextBlock textblock = new TextBlock();
            textblock.Text = (placenum+1).ToString();
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
                Width = 410,
                //Width = 60 + 70*5,
                Height = this.Height,
                //ShowGridLines = true,
                //Background = Brushes.Gray
            };
            //70*50


            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 50) / 2) });
            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            ButtonList2_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 50) / 2) });
            
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);
            ButtonList2_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60)});
            ButtonList2_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70 * 5) });
            //ButtonList2_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength()});


            




            buttonList2 = new List<Button[]>();
            int buttonRow = 1;
            int buttonColumn = 5;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    Width = 70*5,
                    Height = 50,
                    /*
                    Background = Brushes.Purple,
                    ShowGridLines = true*/
                };

                
                    ButtonList2_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 1);
                    Grid.SetColumn(buttonGrid, 1);



                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70) });
                    button[j] = new Button { Width = 70, Height = buttonGrid.Height };
                    button[j].Name = "buttonL2" + "C" + j + "R" + i;
                    button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList2.Add(button);


            }

            TextBlock textblock = new TextBlock();
            textblock.Text = (placenum+1).ToString(); ;
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
                Width = 380,
                //Width = 60 + 60 * 5,
                Height = this.Height,
                /*
                ShowGridLines = true,
                Background = Brushes.Red*/
            };

            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 60) / 2) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList3_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 60) / 2) });
            ButtonList3_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60) )});
            ButtonList3_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(320) });


            //ButtonList3_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });







            buttonList3 = new List<Button[]>();
            int buttonRow = 3;
            int buttonColumn = 2;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    //Width = 60 * 5,
                    Width =ButtonList2_Grid.Width,
                    Height = 20,
                    /*Background = Brushes.Red,
                    ShowGridLines = true*/
                };


                ButtonList3_Grid.Children.Add(buttonGrid);
                Grid.SetRow(buttonGrid, i + 1);
                Grid.SetColumn(buttonGrid, 1);



                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(160) });
                    button[j] = new Button { Width = 160, Height = buttonGrid.Height };
                    button[j].Name = "buttonL3" + "C" + j + "R" + i;
                    button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList3.Add(button);


            }




                

            TextBlock textblock = new TextBlock();
            textblock.Text = (placenum + 1).ToString(); ;
            textblock.FontSize = ButtonList1_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList3_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);

        }

        /// <summary>
        /// PowerPointTypeの一部
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList4(int placenum)
        {
            ButtonList4_Grid = new Grid
            {
                Width = 310,
                //Width = 60 + 210 * 3,
                Height = this.Height,
                /*
                ShowGridLines = true,
                Background = Brushes.GreenYellow*/
            };

            ButtonList4_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 60) / 2) });
            ButtonList4_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });
            ButtonList4_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 60) / 2) });
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);
            ButtonList4_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            ButtonList4_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50 * 5) });
            //ButtonList4_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });


            




            buttonList4 = new List<Button[]>();
            int buttonRow = 1;
            int buttonColumn = 5;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    Width = ButtonList4_Grid.Width,
                    Height = 60,
                    /*
                    Background = Brushes.Azure,
                    ShowGridLines = true*/
                };

                 ButtonList4_Grid.Children.Add(buttonGrid);
                 Grid.SetRow(buttonGrid, i+1);
                 Grid.SetColumn(buttonGrid, 1);


                


                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
                    button[j] = new Button { Width = 50, Height = 60 };
                    button[j].Name = "buttonL4" + "C" + j + "R" + i;
                    button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList4.Add(button);


            }
            TextBlock textblock = new TextBlock();
            textblock.Text = (placenum + 1).ToString(); ;
            textblock.FontSize = ButtonList4_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList4_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRow(textblock, 0);
            Grid.SetRowSpan(textblock, 3);










        }

        /// <summary>
        /// PowerPointTypeの一部
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList5(int placenum)
        {
            ButtonList5_Grid = new Grid
            {
                Width = 350,
                //Width = 60 + 20 * 9,
                Height = this.Height,
                /*
                ShowGridLines = true,
                Background = Brushes.Red*/
            };

            ButtonList5_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height -20)/2) });
            ButtonList5_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList5_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 20) / 2) });
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);
            ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(290) });
            //ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });


           



            buttonList5 = new List<Button[]>();
            int buttonRow = 1;
            int buttonColumn = 2;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    Width = ButtonList5_Grid.Width,
                    Height = 20,
                    /*
                    Background = Brushes.Pink,
                    ShowGridLines = true*/
                };

                
                    ButtonList5_Grid.Children.Add(buttonGrid);
                    Grid.SetRow(buttonGrid, 1);
                    Grid.SetColumn(buttonGrid, 1);




                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                    button[j] = new Button { Width = 20, Height = 20 };
                    button[j].Name = "buttonL5" + "C" + j + "R" + i;
                    button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList5.Add(button);


            }
            TextBlock textblock = new TextBlock();
            textblock.Text = (placenum + 1).ToString(); ;
            textblock.FontSize = ButtonList1_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList5_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);










        }



        private void SetGrid(List<int> vs)
        {
            myToolBarGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.GreenYellow,
                //ShowGridLines = true
            };

            //otherWidths = (this.Width - (ButtonList1_Grid.Width + ButtonList2_Grid.Width + ButtonList3_Grid.Width + ButtonList4_Grid.Width + ButtonList5_Grid.Width)) / 2;

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



            
            myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(otherWidths)});

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < GridColumn; gridColumn_num++)
            {
                int gridWidth_;
                Console.WriteLine("Console" + vs.IndexOf(gridColumn_num));
                switch (vs.IndexOf(gridColumn_num))
                {
                    
                    case (0):
                        
                        colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(ButtonList1_Grid.Width) };
                        myToolBarGrid.Children.Add(ButtonList1_Grid);
                        //myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
                        Grid.SetColumn(ButtonList1_Grid, gridColumn_num+1);
                        break;
                    case (1):
                        colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(ButtonList2_Grid.Width) };
                        myToolBarGrid.Children.Add(ButtonList2_Grid);
                        Grid.SetColumn(ButtonList2_Grid, gridColumn_num+1);

                        break;
                    case (2):
                        colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(ButtonList3_Grid.Width) };
                        myToolBarGrid.Children.Add(ButtonList3_Grid);
                        Grid.SetColumn(ButtonList3_Grid, gridColumn_num+1);
                        break;
                    case (3):
                        colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(ButtonList4_Grid.Width) };
                        myToolBarGrid.Children.Add(ButtonList4_Grid);
                        Grid.SetColumn(ButtonList4_Grid, gridColumn_num+1);
                        break;
                    case (4):
                        colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(ButtonList5_Grid.Width) };
                        myToolBarGrid.Children.Add(ButtonList5_Grid);
                        Grid.SetColumn(ButtonList5_Grid, gridColumn_num+1);
                        break;
                };
                
                 
                 
                 
                 
                 


                myToolBarGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }
            myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(otherWidths) });
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