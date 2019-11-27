using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            foreach(int i in ToolBarOrder)
            {
                
                Console.WriteLine("debug:ToolBarOrder:::::" + i);
                Console.WriteLine("before" + eachCount);
                switch (i)
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
                        break;
                }
                Console.WriteLine("after" + eachCount);

            }
            //番号に応じて順にGridを生成
            //それぞれに必要なボタンを配置






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
                    button[j].Name = "ToolBarTop1" + "_C" + j + "_R" + i;
                    //button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

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
                    button[j].Name = "ToolBarTop2" + "_C" + j + "_R" + i;
                    //button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

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
                    Width = ButtonList2_Grid.Width,
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
                    button[j].Name = "ToolBarTop3" + "_C" + j + "_R" + i;
                    //button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList3.Add(button);


            }






            TextBlock textblock = new TextBlock();
            textblock.Text = (count).ToString(); ;
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
                    button[j].Name = "ToolBarTop4" + "_C" + j + "_R" + i;
                    //button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList4.Add(button);


            }
            TextBlock textblock = new TextBlock();
            textblock.Text = (count).ToString(); ;
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
                    button[j].Name = "ToolBarTop5" + "_C" + j + "_R" + i;
                    //button[j].Click += ToolBarButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);

                }

                buttonList5.Add(button);


            }
            TextBlock textblock = new TextBlock();
            textblock.Text = (count).ToString(); ;
            textblock.FontSize = ButtonList1_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList5_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);










        }



    }
}
