using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ResearchWindowGenerator.ResearchWindow;

namespace ResearchWindowGenerator.ResearchWindowFolder
{
    class ToolBarTop
    {
        private double Width;
        private double Height;
        public Grid toolBarGrid;
        int GridRow;
        int GridColumn;
        double gridHeight;
        double gridWidth;
        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;


        List<Button[]> buttonList;
        List<Button[]> buttonList1;
        List<Button[]> buttonList2;
        List<Button[]> buttonList3;
        List<Button[]> buttonList4;
        List<Button[]> buttonList5;
        Grid ButtonList1_Grid;
        Grid ButtonList2_Grid;
        Grid ButtonList3_Grid;
        Grid ButtonList4_Grid;
        Grid ButtonList5_Grid;

        int[] ToolBarOrder;

        List<int[]> toolBarNumArray;

        private string parentClass;
        private Layout1 layout1;
        private Layout1_Grid layout1_Grid;
        private Layout2 layout2;
        private Layout2_Grid layout2_Grid;
        private Layout3 layout3;
        private Layout3_Grid layout3_Grid;


        public ToolBarTop(List<int[]> numArray)
        {
            toolBarNumArray = numArray;
        }

        internal void SetGridsOrder(int[] toolBarTopOrder)
        {
            ToolBarOrder = toolBarTopOrder;
            SetGrid();
        }

        internal void SetWidth(double windowWidth)
        {
            Width = windowWidth;
        }

        internal void SetHeight(int v)
        {
            Height = v;
            //throw new NotImplementedException();
        }

        public double GetWidth()
        {
            return this.Width;
        }

        public double GetHeight()
        {
            return this.Height;
        }

        private void SetGrid()
        {
            toolBarGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.GreenYellow,
                //ShowGridLines = true
#if DEBUG
                Background = Brushes.Yellow,
                ShowGridLines = true
# endif
            };

            rowDef = new RowDefinition[1];
            colDef = new ColumnDefinition[5];


            //ToolBarOrderの順で定義していく
            int eachCount = 1;
            for(int i = 0; i< ToolBarOrder.Length; i++)
            {
                
                Console.WriteLine("debug:ToolBarOrder:::::" + ToolBarOrder[i]);
                Console.WriteLine("before" + eachCount);
                
                switch (ToolBarOrder[i])
                {
                    
                    
                    case 1:
                        
                        SetButtonList1(eachCount);
                        //ここでそれぞれ配置
                        colDef[eachCount-1] = new ColumnDefinition { Width = new GridLength(ButtonList1_Grid.Width) };
                        toolBarGrid.ColumnDefinitions.Add(colDef[eachCount - 1]);
                        toolBarGrid.Children.Add(ButtonList1_Grid);
                        //myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
                        Grid.SetColumn(ButtonList1_Grid, eachCount-1);
                        eachCount++;

                        break;
                    case 2:
                        
                        SetButtonList2(eachCount);
                        //ここでそれぞれ配置
                        colDef[eachCount - 1] = new ColumnDefinition { Width = new GridLength(ButtonList2_Grid.Width) };
                        toolBarGrid.ColumnDefinitions.Add(colDef[eachCount - 1]);
                        toolBarGrid.Children.Add(ButtonList2_Grid);
                        //myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
                        Grid.SetColumn(ButtonList2_Grid, eachCount - 1);
                        eachCount++;
                        break;
                    case 3:
                        
                        SetButtonList3(eachCount);
                        //ここでそれぞれ配置
                        colDef[eachCount - 1] = new ColumnDefinition { Width = new GridLength(ButtonList3_Grid.Width) };
                        toolBarGrid.ColumnDefinitions.Add(colDef[eachCount - 1]);
                        toolBarGrid.Children.Add(ButtonList3_Grid);
                        //myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
                        Grid.SetColumn(ButtonList3_Grid, eachCount - 1);
                        eachCount++;
                        break;
                    case 4:

                        SetButtonList4(eachCount);
                        //ここでそれぞれ配置
                        colDef[eachCount - 1] = new ColumnDefinition { Width = new GridLength(ButtonList4_Grid.Width) };
                        toolBarGrid.ColumnDefinitions.Add(colDef[eachCount - 1]);
                        toolBarGrid.Children.Add(ButtonList4_Grid);
                        //myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
                        Grid.SetColumn(ButtonList4_Grid, eachCount - 1);
                        eachCount++;
                        break;
                    case 5:
                        SetButtonList5(eachCount);
                        //ここでそれぞれ配置
                        colDef[eachCount - 1] = new ColumnDefinition { Width = new GridLength(ButtonList5_Grid.Width) };
                        toolBarGrid.ColumnDefinitions.Add(colDef[eachCount - 1]);
                        toolBarGrid.Children.Add(ButtonList5_Grid);
                        //myToolBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
                        Grid.SetColumn(ButtonList5_Grid, eachCount - 1);
                        eachCount++;
                        break;
                }
                Console.WriteLine("after" + eachCount);

            }
            //番号に応じて順にGridを生成
            //それぞれに必要なボタンを配置






        }

        

        internal void Parent(Layout1 layout1)
        {
            this.layout1 = layout1;
        }

        internal void Parent(Layout1_Grid layout1_Grid)
        {
            this.layout1_Grid = layout1_Grid;
        }

        internal void Parent(Layout2 layout2)
        {
            this.layout2 = layout2;
        }

        internal void Parent(Layout2_Grid layout2_Grid)
        {
            this.layout2_Grid = layout2_Grid;
        }

        internal void Parent(Layout3 layout3)
        {
            this.layout3 = layout3;
        }

        internal void Parent(Layout3_Grid layout3_Grid)
        {
            this.layout3_Grid = layout3_Grid;
        }




        internal void SetParentClass(string v)
        {
            parentClass = v;
        }

        private void SetButtonList1(int count)
        {
            //Console.WriteLine("Setbuttonlist1" + placenum);
            ButtonList1_Grid = new Grid
            {
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
            ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
            ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList1_Grid.Width - 60) });
            //ButtonList1_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });






            buttonList1 = new List<Button[]>();
            int buttonRow = 2;
            int buttonColumn = 5;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
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
                    button[j].Name = "ToolBarTop1" + "_C" + j+1 + "_R" + i+1;
                    button[j].Tag = "Number" + toolBarNumArray[0][i * buttonColumn + j];
                    button[j].Click += ToolBarTopButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);



                    StackPanel stack = new StackPanel();
                    stack.Width = button[j].Width;
                    stack.Height = button[j].Height;
                    button[j].Content = stack;



                    TextBlock textblock_ = new TextBlock();
                    textblock_.Text = toolBarNumArray[0][i * buttonColumn + j].ToString();
                    textblock_.FontSize = stack.Height * 0.5;
                    textblock_.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock_.VerticalAlignment = VerticalAlignment.Center;
                    stack.Children.Add(textblock_);







                }








                buttonList1.Add(button);


            }
            TextBlock textblock = new TextBlock();
            textblock.Text = (count).ToString();
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
        private void SetButtonList2(int count)
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
            ButtonList2_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
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
                    Width = 70 * 5,
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
                    button[j].Name = "ToolBarTop2" + "_C" + j+1 + "_R" + i+1;
                    button[j].Tag = "Number" + toolBarNumArray[1][i * buttonColumn + j];
                    button[j].Click += ToolBarTopButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);


                    StackPanel stack = new StackPanel();
                    stack.Width = button[j].Width;
                    stack.Height = button[j].Height;
                    button[j].Content = stack;



                    Grid g = new Grid
                    {
                        Width = stack.Width,
                        Height = stack.Height
                    };


                    g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(g.Width * 0.2) });
                    g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(g.Width * 0.8) });
                    stack.Children.Add(g);

                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"../../../ImageFolder/" + toolBarNumArray[1][i * buttonColumn + j] + ".png"), UriKind.RelativeOrAbsolute));
                    img.Width = buttonGrid.Width* 0.8;
                    g.Children.Add(img);
                    Grid.SetColumn(img, 1);

                    TextBlock textblock_ = new TextBlock();
                    textblock_.Text = toolBarNumArray[1][i * buttonColumn + j].ToString();
                    textblock_.FontSize = stack.Height * 0.5;
                    textblock_.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock_.VerticalAlignment = VerticalAlignment.Center;
                    g.Children.Add(textblock_);
                    Grid.SetColumn(textblock_, 0);
                }

                buttonList2.Add(button);


            }

            TextBlock textblock = new TextBlock();
            textblock.Text = (count).ToString(); ;
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
        private void SetButtonList3(int count)
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
            ButtonList3_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength((60)) });
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
                    Width = ButtonList3_Grid.Width,
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
                    button[j].Name = "ToolBarTop3" + "_C" + j+1 + "_R" + i+1;
                    button[j].Tag = "Number" + toolBarNumArray[2][i * buttonColumn + j];
                    button[j].Click += ToolBarTopButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                    StackPanel stack = new StackPanel();
                    stack.Width = button[j].Width;
                    stack.Height = button[j].Height;
                    button[j].Content = stack;



                    TextBlock textblock_ = new TextBlock();
                    textblock_.Text = toolBarNumArray[2][i * buttonColumn + j].ToString();
                    textblock_.FontSize = stack.Height * 0.5;
                    textblock_.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock_.VerticalAlignment = VerticalAlignment.Center;
                    stack.Children.Add(textblock_);

                }

                buttonList3.Add(button);


            }






            TextBlock textblock = new TextBlock();
            textblock.Text = (count).ToString(); ;
            textblock.FontSize = ButtonList3_Grid.Height * 0.5;
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
        private void SetButtonList4(int count)
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
                Grid.SetRow(buttonGrid, i + 1);
                Grid.SetColumn(buttonGrid, 1);





                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
                    button[j] = new Button { Width = 50, Height = 60 };
                    button[j].Name = "ToolBarTop4" + "_C" + j+1 + "_R" + i+1;
                    button[j].Tag = "Number" + toolBarNumArray[3][i * buttonColumn + j];
                    button[j].Click += ToolBarTopButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);



                    StackPanel stack = new StackPanel();
                    stack.Width = button[j].Width;
                    stack.Height = button[j].Height;
                    button[j].Content = stack;

                    Grid g = new Grid
                    {
                        Width = stack.Width,
                        Height = stack.Height
                    };


                    g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(g.Height * 0.6) });
                    g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(g.Height * 0.4) });
                    stack.Children.Add(g);

                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"../../../ImageFolder/" + toolBarNumArray[3][i * buttonColumn + j] + ".png"), UriKind.RelativeOrAbsolute));
                    img.Height = buttonGrid.Height * 0.6;
                    g.Children.Add(img);
                    Grid.SetRow(img, 0);


                    TextBlock textblock_ = new TextBlock();
                    textblock_.Text = toolBarNumArray[3][i * buttonColumn + j].ToString();
                    textblock_.FontSize = stack.Height * 0.4;
                    textblock_.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock_.VerticalAlignment = VerticalAlignment.Center;
                    g.Children.Add(textblock_);
                    Grid.SetRow(textblock_,1);                    

                    /*
                    Grid.SetColumn(textblock_, 0);
                    Grid.SetRow(textblock_, 0);
                    Grid.SetRowSpan(textblock_, 3);
                    */





                    

                    

                    












                }

                buttonList4.Add(button);

                TextBlock textblock = new TextBlock();
                textblock.Text = (count).ToString(); ;
                textblock.FontSize = ButtonList4_Grid.Height * 0.5;
                textblock.HorizontalAlignment = HorizontalAlignment.Center;
                textblock.VerticalAlignment = VerticalAlignment.Center;
                ButtonList4_Grid.Children.Add(textblock);
                Grid.SetColumn(textblock, 0);
                Grid.SetRowSpan(textblock, 5);


            }
            










        }



        ComboBox comboBox;
        /// <summary>
        /// PowerPointTypeの一部
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList5(int count)
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

            ButtonList5_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 20) / 2) });
            ButtonList5_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            ButtonList5_Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength((this.Height - 20) / 2) });
            //myContentsBarGrid.RowDefinitions.Add(MainrowDef3);

            ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            //ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
            ButtonList5_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });

            int[] numArray = toolBarNumArray[4];
            //NumArray をシャッフル
            string[] Number = { " ", toolBarNumArray[4][0].ToString(), toolBarNumArray[4][1].ToString(), toolBarNumArray[4][2].ToString(), toolBarNumArray[4][3].ToString(), toolBarNumArray[4][4].ToString() };
            
            comboBox = new ComboBox();
            comboBox.Height = 20;
            comboBox.Width = 200;

            comboBox.SelectedIndex = 0;
            for(int i =0; i < Number.Length; i++)
            {
                comboBox.Items.Add(Number[i]);
            }
            

            ButtonList5_Grid.Children.Add(comboBox);
            Grid.SetColumn(comboBox, 1);
            Grid.SetRow(comboBox, 1);

            buttonList5 = new List<Button[]>();
            int buttonRow = 1;
            int buttonColumn = 2;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    Width = 60,
                    Height = 20,
                    
                    Background = Brushes.Pink,
                    ShowGridLines = true
                };


                ButtonList5_Grid.Children.Add(buttonGrid);
                Grid.SetRow(buttonGrid, 1);
                Grid.SetColumn(buttonGrid, 2);


                

                for (int j = 0; j < buttonColumn; j++)
                {
                    buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                    button[j] = new Button { Width = 30, Height = 20 };
                    button[j].Name = "ToolBarTop5" + "_C" + j+1 + "_R" + i+1;
                    button[j].Tag = "Number" + (j+1); /*+ toolBarNumArray[4][i*buttonColumn + j];*/
                    button[j].Click += ToolBarTopButton_Grid5_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j],j);
                    



                    StackPanel stack = new StackPanel();
                    stack.Width = button[j].Width;
                    stack.Height = button[j].Height;
                    button[j].Content = stack;



                    TextBlock textblock_ = new TextBlock();
                    textblock_.Text = (j+1).ToString();
                    textblock_.FontSize = stack.Height * 0.5;
                    textblock_.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock_.VerticalAlignment = VerticalAlignment.Center;
                    stack.Children.Add(textblock_);

                }

                buttonList5.Add(button);


            }


            TextBlock textblock = new TextBlock();
            textblock.Text = (count).ToString(); ;
            textblock.FontSize = ButtonList5_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList5_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);










        }


        private void ToolBarTopButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button sender1 = (System.Windows.Controls.Button)sender;
            Console.WriteLine(sender1.Name);
            Console.WriteLine(sender1.Tag);

            string[] sprit = sender1.Name.Split('_');
            string text2 = sender1.Tag.ToString();
            Boolean changeColorFlag = false;
            Utility.SaveLogClick(sender1.Name.ToString(), sender1.Tag.ToString());
            switch (parentClass)
            {
                case "Layout1":
                    changeColorFlag = layout1.scenario(sprit[0], text2);
                    break;
                case "Layout1_Grid":
                    changeColorFlag = layout1_Grid.scenario(sprit[0], text2);
                    break;

                case "Layout2":
                    changeColorFlag = layout2.scenario(sprit[0], text2);
                    break;

                case "Layout2_Grid":
                    changeColorFlag = layout2_Grid.scenario(sprit[0], text2);
                    break;
                case "Layout3":
                    changeColorFlag = layout3.scenario(sprit[0], text2);
                    break;
                case "Layout3_Grid":
                    changeColorFlag =  layout3_Grid.scenario(sprit[0], text2);
                    break;

            }
            if (changeColorFlag)
            {
                sender1.Background = Brushes.Red;
            }

        }

        static int ButtonGrid5Click = 1;
        private void ToolBarTopButton_Grid5_Clicked(object sender, RoutedEventArgs e)
        {
            Button sender1 = (System.Windows.Controls.Button)sender;
            Console.WriteLine(sender1.Name);
            Console.WriteLine(sender1.Tag);

            string[] sprit = sender1.Name.Split('_');
            string text2 = sender1.Tag.ToString();
            Boolean changeColorFlag = false;
            Utility.SaveLogClick(sender1.Name.ToString(), sender1.Tag.ToString());


            if(ButtonGrid5Click == 1 && comboBox.Text.Equals("1") || ButtonGrid5Click == 2 && comboBox.Text.Equals("2"))
            {
                Console.WriteLine("aaaaaaaaaaaaaaa");
                switch (parentClass)
                {
                    case "Layout1":
                        changeColorFlag = layout1.scenario(sprit[0], text2);
                        break;
                    case "Layout1_Grid":
                        changeColorFlag = layout1_Grid.scenario(sprit[0], text2);
                        break;

                    case "Layout2":
                        changeColorFlag = layout2.scenario(sprit[0], text2);
                        break;

                    case "Layout2_Grid":
                        changeColorFlag = layout2_Grid.scenario(sprit[0], text2);
                        break;
                    case "Layout3":
                        changeColorFlag = layout3.scenario(sprit[0], text2);
                        break;
                    case "Layout3_Grid":
                        changeColorFlag = layout3_Grid.scenario(sprit[0], text2);
                        break;

                }
                if (changeColorFlag)
                {
                    sender1.Background = Brushes.Red;
                }
                ButtonGrid5Click++;
            }

            

        }



    }
}
