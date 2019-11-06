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
                Background = Brushes.Blue,
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

                    Image img = new Image();
                    Uri uri = new Uri(System.IO.Path.GetFullPath("../../../ImageFolder/food_nabe_mizutaki.png"), UriKind.RelativeOrAbsolute);
                    img.Source = new BitmapImage(uri);
                    stackPanels[j].Children.Add(img);

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = "Row:" + i + ", Col:" + j;
                    stackPanels[j].Children.Add(textBlock);

                    this.myContentsBarGrid.Children.Add(stackPanels[j]);
                    Grid.SetRow(stackPanels[j], i);
                    Grid.SetColumn(stackPanels[j], j);




                }
                stackPanelList.Add(stackPanels);

            }


        }



    }
}