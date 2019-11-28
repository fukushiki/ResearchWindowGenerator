using ResearchWindowGenerator.ResearchWindowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ResearchWindowGenerator.ResearchWindow
{
    /// <summary>
    /// Layout1.xaml の相互作用ロジック
    /// </summary>
    public partial class Layout1 : Window
    {
        static double WindowWidth;
        static double WindowHeight;
        private int LayoutNum = 1;



        //ToolBar
        ToolBarTop toolBarTop;
        public List<int[]> toolBarTopNumArray;
        int[] ToolBarTopOrder;
        int[] ToolBarTop1NumArray;
        int[] ToolBarTop2NumArray;
        int[] ToolBarTop3NumArray;
        int[] ToolBarTop4NumArray;
        int[] ToolBarTop5NumArray;

        ToolBarUnder toolBarUnder;
        int[] ToolBarUnderNumArray;

        
        ContentsBarVector contentsBarVector;
        int[] ContentsBarNumArray;

        

        List<MainContents>  maincontents;
        int[] MainContentsNumArray;

        /*Grid*/
        static Grid maingrid;
        ColumnDefinition colDef1;
        ColumnDefinition colDef2;
        ColumnDefinition colDef3;
        RowDefinition rowDef1;
        RowDefinition rowDef2;
        RowDefinition rowDef3;


        String ContentsBarType = "Vector";
        public Layout1()
        {
            InitializeComponent();
            /*Windowのサイズ指定*/
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.WindowState = WindowState.Maximized;

            WindowWidth = this.Width;
            WindowHeight = this.Height;

            GridInit();

            ToolBarTop_Arrangement();
            ToolBarUnder_Arrangement();
            //ToolBarRight_Arrangement();

            ContentsBar_Arrangement();

            Maincontents_Arrangement();

            
            LayoutSetting();

            SaveLayoutSetting();
        }

        
        private void ToolBarTop_Arrangement()
        {
            ToolBarTopOrder = new int[] { 1, 2, 3, 4, 5 };
            toolBarTopNumArray = new List<int[]>();
            ToolBarTop1NumArray = new int[] { 1, 2, 3, 4, 5,
                                              6, 7, 8, 9, 10 };
            toolBarTopNumArray.Add(ToolBarTop1NumArray);
            ToolBarTop2NumArray = new int[] { 1, 2,
                                              3, 4,
                                              5, 6 };
            toolBarTopNumArray.Add(ToolBarTop2NumArray);
            ToolBarTop3NumArray = new int[] { 1, 2, 3,
                                              4, 5,6 };
            toolBarTopNumArray.Add(ToolBarTop3NumArray);
            ToolBarTop4NumArray = new int[] { 1, 2, 3, 4, 5 };
            toolBarTopNumArray.Add(ToolBarTop4NumArray);
            ToolBarTop5NumArray = new int[] { 1, 2, 3, 4, 5 };
            toolBarTopNumArray.Add(ToolBarTop5NumArray);



            toolBarTop = new ToolBarTop(toolBarTopNumArray);
            toolBarTop.SetWidth(WindowWidth);
            toolBarTop.SetHeight(165 - 30);
            toolBarTop.SetGridsOrder(ToolBarTopOrder);

  


        }
        private void ToolBarUnder_Arrangement()
        {
            ToolBarUnderNumArray = new int[] { 1, 2, 3, 4, 5 };
            toolBarUnder = new ToolBarUnder();
            toolBarUnder.SetWidth(WindowWidth);
            toolBarUnder.SetHeight(20);
            toolBarUnder.SetGridsOrder(ToolBarUnderNumArray);
        }

        private void ContentsBar_Arrangement()
        {
            if (ContentsBarType.Equals("Vector"))
            {
                ContentsBarNumArray = new int[] { 1, 2, 3, 4, 5 };
                contentsBarVector = new ContentsBarVector();
            }
            contentsBarVector.SetWidth(310);
            //contentsBarVector.SetHeight(WindowHeight - (toolBarTop.GetHeight()));
            contentsBarVector.SetHeight(WindowHeight - (20 + toolBarTop.GetHeight() + toolBarUnder.GetHeight()));
            contentsBarVector.SetGridsOrder(ContentsBarNumArray);
            
            /*
            else
            {
                ContentsBarNumArray = new int[] { 11, 12, 13, 14, 15,
                                                  21, 22, 23, 24, 25,
                                                  31, 32, 33, 34, 35,
                                                  41, 42, 43, 44, 45,
                                                  51, 52, 53, 54, 55};
                contentsBarVector = new ContentsBarGrid();
                contentsBar.SetWidth(310);
                if (LayoutNum == 1)
                {
                    contentsBar.SetHeight(WindowHeight - (20 + toolBar1.GetHeight() + toolBar2.GetHeight()));
                }
            }*/
        }


        private void Maincontents_Arrangement()
        {
            maincontents = new List<MainContents>();
            MainContentsNumArray = new int[] { 1, 2, 3, 4, 5 };
            for(int i=0; i < 5; i++)
            {
                int x = MainContentsNumArray[i];
                MainContents child_maincontents = new MainContents();
                child_maincontents.SetWidth(WindowWidth - contentsBarVector.GetWidth());
                child_maincontents.SetHeight(contentsBarVector.GetHeight());
                child_maincontents.SetGridsOrder(1);
                maincontents.Add(child_maincontents);
                
            }
            
        }

        private void GridInit()
        {
            maingrid = new Grid
            {
                Width = this.Width,
                Height = this.Height,
                //Background = Brushes.Aquamarine,
#if DEBUG
                ShowGridLines = true
#endif

            };

            this.AddChild(maingrid);
            


        }



        private void LayoutSetting()
        {
            //Column : 行 Width
            colDef1 = new ColumnDefinition { Width = new GridLength(contentsBarVector.GetWidth()) };
            colDef2 = new ColumnDefinition { Width = new GridLength(maincontents[0].GetWidth()) };
            colDef3 = new ColumnDefinition { Width = new GridLength(0) };

            Console.WriteLine(colDef1.Width + "; " + colDef2.Width + "; " + colDef3.Width + "");
            //Row : 列 Height
            rowDef1 = new RowDefinition { Height = new GridLength(toolBarTop.GetHeight()) };
            rowDef2 = new RowDefinition { Height = new GridLength(contentsBarVector.GetHeight()) };
            rowDef3 = new RowDefinition { Height = new GridLength(toolBarUnder.GetHeight()) };
            Console.WriteLine(rowDef1.Height + "; " + rowDef2.Height + "; " + rowDef3.Height + "");

            maingrid.ColumnDefinitions.Add(colDef1);
            maingrid.ColumnDefinitions.Add(colDef2);
            maingrid.ColumnDefinitions.Add(colDef3);

            maingrid.RowDefinitions.Add(rowDef1);
            maingrid.RowDefinitions.Add(rowDef2);
            maingrid.RowDefinitions.Add(rowDef3);



            //maincontents
            Grid.SetColumn(maincontents[0].mainContentsGrid, 1);
            Grid.SetRow(maincontents[0].mainContentsGrid, 1);
            maingrid.Children.Add(maincontents[0].mainContentsGrid);
            //ContentsBarVector
            Grid.SetColumn(contentsBarVector.contentsBarVectorGrid, 0);
            Grid.SetRow(contentsBarVector.contentsBarVectorGrid, 1);
            maingrid.Children.Add(contentsBarVector.contentsBarVectorGrid);
            //toolBarTop
            Grid.SetColumn(toolBarTop.toolBarGrid, 0);
            Grid.SetRow(toolBarTop.toolBarGrid, 0);
            Grid.SetColumnSpan(toolBarTop.toolBarGrid, 2);
            maingrid.Children.Add(toolBarTop.toolBarGrid);
            //toolBarUnder
            Grid.SetColumn(toolBarUnder.toolBarGrid, 0);
            Grid.SetRow(toolBarUnder.toolBarGrid, 2);
            Grid.SetColumnSpan(toolBarUnder.toolBarGrid, 2);
            maingrid.Children.Add(toolBarUnder.toolBarGrid);
        }


        private void SaveLayoutSetting()
        {
            Console.WriteLine("Layout"+LayoutNum);
            Console.WriteLine("ToolBarTop" + "True");
            Console.WriteLine("ToolBarOrder" );
            Console.WriteLine("ToolBarTop1_NumArray");
            foreach(int i in ToolBarTop1NumArray){
                Console.WriteLine(i);
            }
            Console.WriteLine("ToolBarTop2_NumArray");
            foreach (int i in ToolBarTop2NumArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("ToolBarTop3_NumArray");
            foreach (int i in ToolBarTop3NumArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("ToolBarTop4_NumArray");
            foreach (int i in ToolBarTop4NumArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("ToolBarTop5_NumArray");
            foreach (int i in ToolBarTop5NumArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("ContentsBar"+ContentsBarType);
            Console.WriteLine("MainContents");
            foreach (int i in MainContentsNumArray)
            {
                Console.WriteLine(i);
            }
        }
    }
}
