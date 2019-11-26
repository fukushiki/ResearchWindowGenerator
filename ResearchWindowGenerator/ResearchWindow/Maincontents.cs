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
    class MainContents
    {
        private double Width;
        private double Height;
        public Grid mainContentsGrid;
        int MainContentsNum;


        int GridRow;
        int GridColumn;
        double gridHeight;
        double gridWidth;
        ColumnDefinition[] colDef;
        RowDefinition[] rowDef;



        static int MainContentsCreateCount = 0;

        /// <summary>
        /// MainContentsの生成番号
        /// </summary>
        private int MainContentsNumber;

        /// <summary>
        /// メインコンテンツの種類 1: 2: 3: 4: 5: 
        /// </summary>
        private int MainContentsGridTypeNum;

        public MainContents()
        {
            MainContentsCreateCount++;
            MainContentsNumber = MainContentsCreateCount;
            
            
        }
        internal void SetGridsOrder(int num)
        {
            MainContentsGridTypeNum = num;
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
            mainContentsGrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.GreenYellow,
                //ShowGridLines = true
#if DEBUG
                Background = Brushes.DarkOrange,
                ShowGridLines = true
# endif
            };

            rowDef = new RowDefinition[GridRow];
            colDef = new ColumnDefinition[GridColumn];


            //ToolBarOrderの順で定義していく
            
                Console.WriteLine("debug:MainContentsGridType:::::" + MainContentsGridTypeNum);
            




        }
    }
}
