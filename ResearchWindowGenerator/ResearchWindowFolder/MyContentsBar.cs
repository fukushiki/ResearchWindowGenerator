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


        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;

        public MyContentsBar(double width, double height)
        {
            this.Width = width;
            this.Height = height;

            SetButton(1);
            SetGrid();
            SetButtonList();
            SetStackPanels();
        }


        public double GetWidth()
        {
            return this.Width;
        }

        public double GetHeight()
        {
            return this.Height;
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
                    GridRow = 5;
                    GridColumn = 1;
                    SetButtonList();
                    break;
                case (2):
                    GridRow = 7;
                    GridColumn = 5;
                    SetButtonList();
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
        private void SetButtonList()
        {
            buttonList = new List<Button[]>();
            for (int i = 0; i < GridRow; i++)
            {
                Button[] button = new Button[GridColumn];
                for (int j = 0; j < GridColumn; j++)
                {
                    button[j] = new Button();
                    button[j].Click += MyContentsBarButton_Clicked;

                }
                buttonList.Add(button);
            }

        }

        private void SetGrid()
        {
            myContentsBarGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.Blue,
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
                myContentsBarGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < GridColumn; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                myContentsBarGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
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

                    TextBlock textBlock_ = new TextBlock();
                    textBlock_.Text = i.ToString();
                    textBlock_.FontSize = 20;
                    textBlock_.FontWeight = FontWeights.Bold;
                    stackPanels[j].Children.Add(textBlock_);

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = "ContentsBar"+"Row:" + i + ", Col:" + j;
                    stackPanels[j].Children.Add(textBlock);

                    buttonList[i][j].Content=stackPanels[j];

                    this.myContentsBarGrid.Children.Add(buttonList[i][j]);
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

        }



    }
}