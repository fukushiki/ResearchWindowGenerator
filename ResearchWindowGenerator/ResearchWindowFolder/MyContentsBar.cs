using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ResearchWindowGenerator.ResearchWindowFolder
{
    public class MyContentsBar
    {
        private double Width;
        private double Height;

        public StackPanel stackPanel;

        List<Button[]> buttonList;
        List<StackPanel[]> stackPanelList;

        public Grid myContentsBarGrid;
        int GridRow;
        int GridColumn;

        double gridHeight;
        double gridWidth;

        private Grid BigGrid;

        ColumnDefinition bigcolDef1;
        ColumnDefinition bigcolDef2;
        ColumnDefinition bigcolDef3;
        RowDefinition bigrowDef1;
        RowDefinition bigrowDef2;
        RowDefinition bigrowDef3;

        ColumnDefinition MaincolDef1;
        ColumnDefinition MaincolDef2;
        ColumnDefinition MaincolDef3;
        RowDefinition MainrowDef1;
        RowDefinition MainrowDef2;
        RowDefinition MainrowDef3;




        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;

        int ButtonNum;

        public MyContentsBar()
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


        /// <summary>
        /// ボタンのセッティング
        /// </summary>
        /// <param name="_button_num"></param>
        public void SetButton(int _button_num)
        {
            ButtonNum = _button_num;
            switch (_button_num)
            {
                case (1):
                    GridRow = 5;
                    GridColumn = 1;
                    SetGrid(0);
                    SetBigGrid(_button_num);
                    SetButtonList(0);
                    SetStackPanels(0);
                    break;
                case (2):
                    GridRow = 7;
                    GridColumn = 7;
                    SetGrid(1);
                    SetBigGrid(_button_num);
                    SetButtonList(1);
                    SetStackPanels(1);
                    break;
                default:
                    ;
                    break;
            }
            
            
            
        }

        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList(int plus)
        {
            buttonList = new List<Button[]>();
            for (int i = 0; i < GridRow + plus; i++)
            {
                Button[] button = new Button[GridColumn];
                for (int j = 0; j < GridColumn; j++)
                {
                    button[j] = new Button();
                    button[j].Click += MyContentsBarButton_Clicked;
                    button[j].Name = "C"+j+"R"+(i);
                }
                buttonList.Add(button);
            }
             

        }



        private void SetGrid(int plus)
        {
            myContentsBarGrid = new Grid
            {
                
                    Width = this.Width,
                    Height = this.Height,
                    //Background = Brushes.Blue,
                    ShowGridLines = true


            };

            switch (ButtonNum)
            {
                case (1):
                    break;
                case (2):
                    //Column : 行 Width
                    MaincolDef1 = new ColumnDefinition { Width = new GridLength((this.Width - 230) / 2) };
                    MaincolDef2 = new ColumnDefinition { Width = new GridLength(230) };
                    MaincolDef3 = new ColumnDefinition { Width = new GridLength((this.Width - 230) / 2) };
                    //Row : 列 Height
                    MainrowDef1 = new RowDefinition { Height = new GridLength(this.Height * 0.3) };
                    MainrowDef2 = new RowDefinition { Height = new GridLength(230) };
                    MainrowDef3 = new RowDefinition { Height = new GridLength(1040 - (this.Height * 0.3) - 230) };

                    myContentsBarGrid.ColumnDefinitions.Add(MaincolDef1);
                    myContentsBarGrid.ColumnDefinitions.Add(MaincolDef2);
                    myContentsBarGrid.ColumnDefinitions.Add(MaincolDef3);

                    myContentsBarGrid.RowDefinitions.Add(MainrowDef1);
                    myContentsBarGrid.RowDefinitions.Add(MainrowDef2);
                    myContentsBarGrid.RowDefinitions.Add(MainrowDef3);

                    break;
            }

        }

        public void SetBigGrid(int num)
        {
            BigGrid = new Grid
            {

                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.Blue,
                ShowGridLines = true


            };
            myContentsBarGrid.Children.Add(BigGrid);

            switch (ButtonNum)
            {
                case (1):
                    /*ここにGridの中に入れる*/
                    gridHeight = this.Height / GridRow;
                    gridWidth = this.Width / GridColumn;
                    break;
                case (2):
                    Grid.SetRow(BigGrid, 1);
                    Grid.SetColumn(BigGrid, 1);
                    /*ここにGridの中に入れる*/
                    gridHeight = 230 / GridRow;
                    gridWidth = 230 / GridColumn;
                    break;
            }



            

            rowDef = new RowDefinition[GridRow];
            colDef = new ColumnDefinition[GridColumn];

            //行の設定
            for (int gridRow_num = 0; gridRow_num < GridRow; gridRow_num++)
            {
                rowDef[gridRow_num] = new RowDefinition { Height = new GridLength(gridHeight) };
                BigGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < GridColumn; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                BigGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }





        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetStackPanels(int plus)
        {
            stackPanelList = new List<StackPanel[]>();

            if(plus == 1)
            {
                StackPanel[] stackPanels = new StackPanel[GridColumn];
                for(int x = 0; x < GridColumn; x++)
                {
                    stackPanels[x] = new StackPanel
                    {
                        //TODO: StackPanelの中身を2~のやつも作る
                        Width = gridWidth,
                        Height = gridHeight,


                    };

                    TextBlock textBlock_ = new TextBlock();
                    textBlock_.Text = x.ToString();
                    textBlock_.FontSize = 20;
                    textBlock_.FontWeight = FontWeights.Bold;
                    stackPanels[x].Children.Add(textBlock_);
                }
                stackPanelList.Add(stackPanels);
            }



            for (int i = 0 + plus; i < GridRow-plus ; i++)
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

                    TextBlock textBlock_ = new TextBlock();
                    textBlock_.Text = i.ToString()+j.ToString();
                    textBlock_.FontSize = 20;
                    textBlock_.FontWeight = FontWeights.Bold;
                    stackPanels[j].Children.Add(textBlock_);
                    /*
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = "ContentsBar"+"Row:" + i + ", Col:" + j;
                    stackPanels[j].Children.Add(textBlock);
                    */
                    buttonList[i][j].Content=stackPanels[j];

                    this.BigGrid.Children.Add(buttonList[i][j]);
                    Grid.SetRow(buttonList[i][j], i);
                    Grid.SetColumn(buttonList[i][j], j);







                }
                stackPanelList.Add(stackPanels);

            }


            


        }

        private void MyContentsBarButton_Clicked(object sender, RoutedEventArgs e)
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




            if(ButtonNum == 1)
            {
                switch (sender1.Name)
                {
                    case ("C0R0"):

                        ResearchWindowLayout.ChangeMaincontents(1);
                        ;
                        break;
                    case ("C0R1"):
                        ResearchWindowLayout.ChangeMaincontents(2);
                        ;
                        break;
                    case ("C0R2"):
                        ResearchWindowLayout.ChangeMaincontents(3);
                        ;
                        break;
                    case ("C0R3"):
                        ResearchWindowLayout.ChangeMaincontents(4);
                        ;
                        break;
                    case ("C0R4"):
                        ResearchWindowLayout.ChangeMaincontents(5);
                        ;
                        break;
                }
            }else if(ButtonNum == 2)
            {
                switch (sender1.Name)
                {
                    case ("C0R1"):

                        ResearchWindowLayout.ChangeMaincontents(1);
                        ;
                        break;
                    case ("C0R2"):
                        ResearchWindowLayout.ChangeMaincontents(2);
                        ;
                        break;
                    case ("C0R3"):
                        ResearchWindowLayout.ChangeMaincontents(3);
                        ;
                        break;
                    case ("C0R4"):
                        ResearchWindowLayout.ChangeMaincontents(4);
                        ;
                        break;
                    case ("C0R5"):
                        ResearchWindowLayout.ChangeMaincontents(5);
                        ;
                        break;
                }
            }
            
            
        }



    }
}