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
                //ShowGridLines = true
#if DEBUG
                Background = Brushes.LightGoldenrodYellow,
                ShowGridLines = true
# endif
            };

            rowDef = new RowDefinition[GridRow];
            colDef = new ColumnDefinition[GridColumn];


            //ToolBarOrderの順で定義していく
            foreach (int i in ToolBarOrder)
            {
                Console.WriteLine("debug:ToolBarUnderOrder:::::" + i);
            }




        }



        private void ToolBarUnderButton_Clicked(object sender, RoutedEventArgs e)
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
