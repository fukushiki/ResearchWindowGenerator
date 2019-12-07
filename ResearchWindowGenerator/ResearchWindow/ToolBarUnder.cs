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
    class ToolBarUnder
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

        int[] ToolBarOrder;

        List<Button[]> buttonList;
        Grid ButtonList_Grid;
        private string parentClass;
        private Layout1 layout1;
        private Layout1_Grid layout1_Grid;
        private Layout2 layout2;
        private Layout2_Grid layout2_Grid;
        private Layout3 layout3;
        private Layout3_Grid layout3_Grid;

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


        internal void SetGridsOrder(int[] toolBarUnderOrder)
        {
            ToolBarOrder = toolBarUnderOrder;
            SetGrid();
        }


        internal void SetWidth(double windowWidth)
        {
            Width = windowWidth;
        }

        internal void SetHeight(int v)
        {
            Height = v;
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
                
#if DEBUG
                Background = Brushes.LightGoldenrodYellow,
                ShowGridLines = true
# endif
            };

            rowDef = new RowDefinition[1];
            colDef = new ColumnDefinition[3];

            colDef[0] = new ColumnDefinition { Width = new GridLength (this.Width * 1/3)};
            colDef[1] = new ColumnDefinition { Width = new GridLength(this.Width * 1 / 3) };
            colDef[2] = new ColumnDefinition { Width = new GridLength(this.Width * 1 / 3) };

            toolBarGrid.ColumnDefinitions.Add(colDef[0]);
            toolBarGrid.ColumnDefinitions.Add(colDef[1]);
            toolBarGrid.ColumnDefinitions.Add(colDef[2]);

            SetButtonList();

            //Grid.SetColumn(ButtonList_Grid, 2);

            //ToolBarOrderの順で定義していく
            foreach (int i in ToolBarOrder)
            {
                Console.WriteLine("debug:ToolBarUnderOrder:::::" + i);
            }




        }


        /// <summary>
        /// Calenderタイプの一部
        /// </summary>
        /// <param name="_r">Row 行</param>
        /// <param name="_c">Column 列</param>
        private void SetButtonList()
        {
            ButtonList_Grid = new Grid
            {
                Width = this.Width/3,
                //Width = 60 + 70*5,
                Height = this.Height,
                ShowGridLines = true,
                //Background = Brushes.Gray
            };
            //70*50


            
            /*
            ButtonList_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList_Grid.Width / 5) });
            ButtonList_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList_Grid.Width / 5) });
            */


            toolBarGrid.Children.Add(ButtonList_Grid);
            Grid.SetColumn(ButtonList_Grid, 2);




            buttonList = new List<Button[]>();
            int buttonRow = 1;
            int buttonColumn = 5;
            for (int i = 0; i < buttonRow; i++)
            {
                Button[] button = new Button[buttonColumn];
                
                



                for (int j = 0; j < buttonColumn; j++)
                {
                    ButtonList_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ButtonList_Grid.Width / 5) });
                    button[j] = new Button { Width = ButtonList_Grid.Width / 5, Height = ButtonList_Grid.Height };
                    button[j].Name = "ToolBarUnder" + "_C" + j + 1 + "_R" + i + 1;
                    button[j].Tag = "Number" + ToolBarOrder[i * buttonColumn + j];
                    button[j].Click += ToolBarUnderButton_Clicked;
                    ButtonList_Grid.Children.Add(button[j]);
                    Grid.SetColumn(button[j], j);


                    StackPanel stack = new StackPanel();
                    stack.Width = button[j].Width;
                    stack.Height = button[j].Height;
                    button[j].Content = stack;



                    TextBlock textblock_ = new TextBlock();
                    textblock_.Text = ToolBarOrder[i * buttonColumn + j].ToString();
                    textblock_.FontSize = stack.Height * 0.5;
                    textblock_.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock_.VerticalAlignment = VerticalAlignment.Center;
                    stack.Children.Add(textblock_);

                }

                buttonList.Add(button);


            }
            /*
            TextBlock textblock = new TextBlock();
            //textblock.Text = (count).ToString(); ;
            textblock.FontSize = ButtonList_Grid.Height * 0.5;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.VerticalAlignment = VerticalAlignment.Center;
            ButtonList_Grid.Children.Add(textblock);
            Grid.SetColumn(textblock, 0);
            Grid.SetRowSpan(textblock, 5);
            */
        }


        private void ToolBarUnderButton_Clicked(object sender, RoutedEventArgs e)
        {
            
            Button sender1 = (System.Windows.Controls.Button)sender;
            Console.WriteLine(sender1.Name);
            Console.WriteLine(sender1.Tag);

            string[] sprit = sender1.Name.Split('_');
            string text2 = sender1.Tag.ToString();



            switch (parentClass)
            {
                case "Layout1":
                    layout1.scenario(sprit[0], text2);
                    
                    break;
                case "Layout1_Grid":
                    layout1_Grid.scenario(sprit[0], text2);
                    break;

                case "Layout2":
                    layout2.scenario(sprit[0], text2);
                    break;
                case "Layout2_Grid":
                    layout2_Grid.scenario(sprit[0], text2);
                    break;
                case "Layout3":
                    layout3.scenario(sprit[0], text2);
                    break;
                case "Layout3_Grid":
                    layout3_Grid.scenario(sprit[0], text2);
                    break;

            }


        }
    }
}
