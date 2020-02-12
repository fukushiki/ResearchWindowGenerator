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
    class ToolBarRight
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
        private int[] toolBarRightNumArray;

        

        public ToolBarRight(int[] toolBarRightNumArray)
        {
            this.toolBarRightNumArray = toolBarRightNumArray;
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
                ShowGridLines = true,
                //Background = Brushes.AliceBlue
            };
            /*
            toolBarGrid.Children.Add(toolBarGridGrid);
            Grid.SetRow(ButtonList1_Grid, 1);
            */


            
            buttonList1 = new List<Button[]>();
            int buttonRow = 9;
            int buttonColumn = 1;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                Grid buttonGrid = new Grid
                {
                    Width = toolBarGrid.Width,
                    Height = 40,
                    Background = Brushes.Black,
                    ShowGridLines = true
                };

                toolBarGrid.Children.Add(buttonGrid);

                Grid.SetRow(buttonGrid, i);
                toolBarGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });





                for (int j = 0; j < buttonColumn; j++)
                {

                    button[j] = new Button { Width = toolBarGrid.Width, Height = 40 };
                    button[j].Name = "ToolBarRight_" + "C" + j + "_R" + i;
                    button[j].Tag = "Number" + toolBarRightNumArray[i * buttonColumn + j];
                    button[j].Click += ToolBarRightButton_Clicked;
                    buttonGrid.Children.Add(button[j]);
                    Grid.SetRow(button[j], j);


                    StackPanel sp = new StackPanel
                    {
                        Width = button[j].Width,
                        Height = button[j].Height
                    };
                    Grid g = new Grid
                    {
                        Width = sp.Width,
                        Height = sp.Height
                    };

                    button[j].Content = sp;
                    sp.Children.Add(g);

                    g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(g.Width * 0.2) });
                    g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(g.Width * 0.8) });

                    


                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"../../../ImageFolder/" + ToolBarOrder[i * buttonColumn + j] + ".png"), UriKind.RelativeOrAbsolute));
                    img.Height = sp.Height * 0.8;
                    //g.Children.Add(img);



                    TextBlock textblock1 = new TextBlock();
                    textblock1.Text = ToolBarOrder[i * buttonColumn + j].ToString(); ;
                    textblock1.FontSize = button[j].Height * 0.8;
                    textblock1.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock1.VerticalAlignment = VerticalAlignment.Center;
                   // g.Children.Add(textblock1);


                    Grid.SetColumn(img, 0);
                    Grid.SetColumn(textblock1, 1);


                }

                buttonList1.Add(button);
                

            }




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

        


        private void ToolBarRightButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button sender1 = (System.Windows.Controls.Button)sender;
            Console.WriteLine(sender1.Name);
            Console.WriteLine(sender1.Tag);

            string[] sprit = sender1.Name.Split('_');
            string text2 = sender1.Tag.ToString();
            Boolean changeColorFlag = false;
            Utility.SaveLogClick(sender1.Name.ToString(), sender1.Tag.ToString(), System.Windows.Forms.Control.MousePosition);
            switch (parentClass)
            {
                case "Layout1":
                    changeColorFlag = layout1.scenario(sprit[0], text2);
                    break;
                case "Layout1_Grid":
                    changeColorFlag = layout1_Grid.scenario(sprit[0], text2);
                    break;

                case "Layout2":
                    layout2.scenario(sprit[0], text2);
                    break;

                case "Layout2_Grid":
                    layout2_Grid.scenario(sprit[0], text2);
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


        }



    }
}
