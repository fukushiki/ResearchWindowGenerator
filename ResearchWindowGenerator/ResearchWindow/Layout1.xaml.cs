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

        //MainContents[] maincontents;



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

            LayoutSetting();

            ToolBarTop_Arrangement();
            ToolBarUnder_Arrangement();
            //ToolBarRight_Arrangement();

            ContentsBar_Arrangement();


            
            SaveLayoutSetting();
        }

        

        private void ToolBarTop_Arrangement()
        {
            ToolBarTopOrder = new int[] { 1, 2, 3, 4, 5 };
            ToolBarTop1NumArray = new int[] { 11, 12, 13, 14, 15,
                                              21, 22, 23, 24, 25 };
            ToolBarTop2NumArray = new int[] { 11, 12,
                                              21, 22,
                                              31, 32 };
            ToolBarTop3NumArray = new int[] { 1, 2, 3, 4, 5 };
            ToolBarTop4NumArray = new int[] { 1, 2, 3, 4, 5 };
            ToolBarTop5NumArray = new int[] { 1, 2, 3, 4, 5 };

            toolBarTop = new ToolBarTop();
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
        }

        private void ContentsBar_Arrangement()
        {
            if (ContentsBarType.Equals("Vector"))
            {
                ContentsBarNumArray = new int[] { 1, 2, 3, 4, 5 };
                contentsBarVector = new ContentsBarVector();
            }/*
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

        private void LayoutSetting()
        {

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
        }
    }
}
