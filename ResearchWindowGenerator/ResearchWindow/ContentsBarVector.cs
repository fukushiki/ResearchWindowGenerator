using ResearchWindowGenerator.ResearchWindow;
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
    class ContentsBarVector
    {
        private double Width;
        private double Height;
        public Grid contentsBarMainGrid;


        int GridRow = 3;
        int GridColumn = 1;
        double gridHeight;
        double gridWidth;
        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;
        ColumnDefinition[] buttonGrid_colDef;
        RowDefinition[] buttonGrid_rowDef;
        int[] ContentsBarOrder;
        List<Button[]> buttonList;
        List<StackPanel[]> stackPanelList;


        ColumnDefinition ButtonPlace_colDef1;
        ColumnDefinition ButtonPlace_colDef2;
        ColumnDefinition ButtonPlace_colDef3;
        RowDefinition ButtonPlace_rowDef1;
        RowDefinition ButtonPlace_rowDef2;
        RowDefinition ButtonPlace_rowDef3;

        Grid ButtonGrid;

        int[] contentsBarVectorNumArray;

        private string parentClass;
        private Layout1 layout1;
        private Layout1_Grid layout1_Grid;
        private Layout2 layout2;
        private Layout2_Grid layout2_Grid;
        private Layout3 layout3;
        private Layout3_Grid layout3_Grid;

        public ContentsBarVector(int[] numArray)
        {
            contentsBarVectorNumArray = numArray;
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




        internal void SetGridsOrder(int[] contentsBarOrder)
        {
            ContentsBarOrder = contentsBarOrder;
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
            contentsBarMainGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.GreenYellow,
                //ShowGridLines = true
                #if DEBUG
                Background = Brushes.GreenYellow,
                ShowGridLines = true
                # endif
            };

            rowDef = new RowDefinition[GridRow];
            colDef = new ColumnDefinition[GridColumn];


            //ToolBarOrderの順で定義していく
            foreach (int i in ContentsBarOrder)
            {
                Console.WriteLine("debug:ContentsOrder:::::" + i);

            }

            /*
            //Column : 行 Width
            ButtonPlace_colDef1 = new ColumnDefinition { Width = new GridLength(0) };
            ButtonPlace_colDef2 = new ColumnDefinition { Width = new GridLength(this.Width) };
            ButtonPlace_colDef3 = new ColumnDefinition { Width = new GridLength(0) };
            //Row : 列 Height
            ButtonPlace_rowDef1 = new RowDefinition { Height = new GridLength(this.Height * 0.3) };
            ButtonPlace_rowDef2 = new RowDefinition { Height = new GridLength(this.Width) };
            ButtonPlace_rowDef3 = new RowDefinition { Height = new GridLength() };

            contentsBarVectorGrid.ColumnDefinitions.Add(ButtonPlace_colDef1);
            contentsBarVectorGrid.ColumnDefinitions.Add(ButtonPlace_colDef2);
            contentsBarVectorGrid.ColumnDefinitions.Add(ButtonPlace_colDef3);

            contentsBarVectorGrid.RowDefinitions.Add(ButtonPlace_rowDef1);
            contentsBarVectorGrid.RowDefinitions.Add(ButtonPlace_rowDef2);
            contentsBarVectorGrid.RowDefinitions.Add(ButtonPlace_rowDef3);
            */
















            //ボタンを乗せるGridの生成
            ButtonPlaceGrid(5, 1);
            //ボタンを生成
            SetButtonList(5,1);
            //StackPanelを生成
            SetStackPanel(5, 1);
            //ボタンにStackPanelを貼る
            //SetStackPanel2Button




        }
        public void ButtonPlaceGrid(int row_, int column_)
        {
            ButtonGrid = new Grid
            {

                Width = this.Width,
                Height = this.Height,
#if DEBUG
                Background = Brushes.Red,
                ShowGridLines = true
#endif


            };
            gridWidth = this.Width;
            gridHeight = this.Height / row_;


            contentsBarMainGrid.Children.Add(ButtonGrid);
            /*Grid.SetRow(ButtonGrid, 1);
            Grid.SetColumn(ButtonGrid, 1);
            */
            rowDef = new RowDefinition[row_];
            colDef = new ColumnDefinition[column_];

            //行の設定
            for (int gridRow_num = 0; gridRow_num < row_; gridRow_num++)
            {
                rowDef[gridRow_num] = new RowDefinition { Height = new GridLength(gridHeight) };
                ButtonGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < column_; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                ButtonGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }





        }
        private void SetButtonList(int row_,int column_)
        {
            buttonList = new List<Button[]>();
            for (int i = 0; i < row_; i++)
            {
                Button[] button = new Button[GridColumn];
                for (int j = 0; j < column_; j++)
                {
                    button[j] = new Button();
                    //button[j].Click += MyContentsBarButton_Clicked;
                    button[j].Name = "ContentsBarVector_"+"C" + j+1 + "_R" + i+1;
                    button[j].Tag = "Number" + contentsBarVectorNumArray[i * column_ + j];
                    button[j].Click += ContentsBarVectorButton_Clicked;
                    ButtonGrid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);
                    Grid.SetRow(button[j], i);
                }
                buttonList.Add(button);
                
            }


        }

        private void SetStackPanel(int row_, int column_)
        {
            stackPanelList = new List<StackPanel[]>();
            int count = 0;
            for (int i = 0; i < row_; i++)
            {
                StackPanel[] stackPanels = new StackPanel[column_];
                for (int j = 0; j < column_; j++)
                {
                    
                    stackPanels[j] = new StackPanel();
                    //button[j].Click += MyContentsBarButton_Clicked;
                    stackPanels[j].Name = "ContentsBarVector_Number" + "C" + j + 1 + "_R" + i + 1;//TODO変更

                    
                    //stackPanels[j].Background = Brushes.Black;


                    TextBlock textblock = new TextBlock();
                    textblock.Text = ContentsBarOrder[count].ToString();
                    textblock.FontSize = gridHeight * 0.5;
                    textblock.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock.VerticalAlignment = VerticalAlignment.Center;


                    stackPanels[j].Children.Add(textblock);
                    //Grid.SetColumn(textblock, 0);
                    //Grid.SetRowSpan(textblock, 5);

                    

                    count++;
                    buttonList[i][j].Content = stackPanels[j];
                    

                }
                stackPanelList.Add(stackPanels);
                //buttonList.Add();
            }


        }

        private void ContentsBarVectorButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button sender1 = (System.Windows.Controls.Button)sender;
            Console.WriteLine(sender1.Name);
            Console.WriteLine(sender1.Tag);

            string[] sprit = sender1.Name.Split('_');
            string text2 = sender1.Tag.ToString();
            Boolean changeColorFlag = false;

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
                    layout3_Grid.scenario(sprit[0], text2);
                    break;

            }
            if (changeColorFlag)
            {
                sender1.Background = Brushes.Red;
            }
        }





    }
}
