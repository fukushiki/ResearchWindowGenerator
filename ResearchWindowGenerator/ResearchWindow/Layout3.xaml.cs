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
    public partial class Layout3 : Window
    {
        static double WindowWidth;
        static double WindowHeight;
        private int LayoutNum = 1;
        public static int MainContentsStatus = 0;
        public static int ScenarioNum = 1;
        //public static int MainContentsStatus = 0;
        //public static int MainContentsStatus = 0;


        //ToolBar
        ToolBarTop toolBarTop;
        public List<int[]> toolBarTopNumArray;
        static int[] ToolBarTopOrder;
        int[] ToolBarTop1NumArray;
        int[] ToolBarTop2NumArray;
        int[] ToolBarTop3NumArray;
        int[] ToolBarTop4NumArray;
        int[] ToolBarTop5NumArray;

        ToolBarUnder toolBarUnder;
        int[] ToolBarUnderNumArray;

        ToolBarRight toolBarRight;
        int[] ToolBarRightNumArray;

        ContentsBarVector contentsBarVector;
        int[] ContentsBarNumArray;



        static List<MainContents> maincontents;
        int[] MainContentsNumArray;

        List<int[]> maincontentsNumArrayList;
        int[] MainContents1NumArray;
        int[] MainContents2NumArray;
        int[] MainContents3NumArray;
        int[] MainContents4NumArray;
        int[] MainContents5NumArray;
        /*Grid*/
        static Grid maingrid;
        ColumnDefinition colDef1;
        ColumnDefinition colDef2;
        ColumnDefinition colDef3;
        RowDefinition rowDef1;
        RowDefinition rowDef2;
        RowDefinition rowDef3;

        string ParentClass = "Layout3";


        String ContentsBarType = "Vector";

        //public static  Layout1 layout1 { get; private set; }
        public static string LayoutFilePass;
        public static string ClickLogFilePass;

        public Layout3()
        {
            InitializeComponent();
            // ParentClass = "Layout1";
            /*Windowのサイズ指定*/
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.WindowState = WindowState.Maximized;
            this.Title = ParentClass + ": " + "ScenarioNum" + "1" + "Next : ContentsBarの1をクリック";
            WindowWidth = this.Width;
            WindowHeight = this.Height;
            LayoutFilePass = Utility.LoggerInitialize(ParentClass);
            ClickLogFilePass = Utility.LoggerInitializeClick(ParentClass);


            GridInit();

            ToolBarTop_Arrangement();
            //ToolBarUnder_Arrangement();
            ToolBarRight_Arrangement();

            ContentsBar_Arrangement();

            Maincontents_Arrangement();

            
            LayoutSetting();

            SaveLayoutSetting();
        }


        private void ToolBarTop_Arrangement()
        {
            ToolBarTopOrder = new int[] { 1, 2, 3, 4, 5 };
            ToolBarTopOrder = Utility.RamdomArray(ToolBarTopOrder);
            toolBarTopNumArray = new List<int[]>();

            ToolBarTop1NumArray = new int[] { 1, 2, 3, 4, 5,
                                              6, 7, 8, 9, 10 };
            ToolBarTop1NumArray = Utility.RamdomArray(ToolBarTop1NumArray);
            toolBarTopNumArray.Add(ToolBarTop1NumArray);

            ToolBarTop2NumArray = new int[] { 1, 2,
                                              3, 4,
                                              5 };
            ToolBarTop2NumArray = Utility.RamdomArray(ToolBarTop2NumArray);
            toolBarTopNumArray.Add(ToolBarTop2NumArray);

            ToolBarTop3NumArray = new int[] { 1, 2, 3,
                                              4, 5,6 };
            ToolBarTop3NumArray = Utility.RamdomArray(ToolBarTop3NumArray);
            toolBarTopNumArray.Add(ToolBarTop3NumArray);


            ToolBarTop4NumArray = new int[] { 1, 2, 3, 4, 5 };
            ToolBarTop4NumArray = Utility.RamdomArray(ToolBarTop4NumArray);
            toolBarTopNumArray.Add(ToolBarTop4NumArray);

            ToolBarTop5NumArray = new int[] { 1, 2, 3, 4, 5 };
            ToolBarTop5NumArray = Utility.RamdomArray(ToolBarTop5NumArray);
            toolBarTopNumArray.Add(ToolBarTop5NumArray);



            toolBarTop = new ToolBarTop(toolBarTopNumArray);
            toolBarTop.SetParentClass(ParentClass);
            toolBarTop.Parent(this);
            toolBarTop.SetWidth(this.Width);
            toolBarTop.SetHeight(130-30);
            toolBarTop.SetGridsOrder(ToolBarTopOrder);

            /*
             toolBar1 = new MyToolBar(1);
                    toolBar1.SetWidth(1755);
                    //toolBar1.SetHeight(75 - 30);
                    toolBar1.SetHeight(60);
                    toolBar1.SetButton(2);
             */





        }
        private void ToolBarUnder_Arrangement()
        {
            ToolBarUnderNumArray = new int[] { 1, 2, 3, 4, 5 };
            toolBarUnder = new ToolBarUnder();
            toolBarUnder.SetWidth(WindowWidth);
            toolBarUnder.SetHeight(20);
            toolBarUnder.SetGridsOrder(ToolBarUnderNumArray);
        }

        private void ToolBarRight_Arrangement()
        {
            ToolBarRightNumArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ToolBarRightNumArray = Utility.RamdomArray(ToolBarRightNumArray);
            toolBarRight = new ToolBarRight(ToolBarRightNumArray);

            toolBarRight.SetParentClass(ParentClass);
            toolBarRight.Parent(this);
            toolBarRight.SetWidth(310);
            toolBarRight.SetHeight(910);
            toolBarRight.SetGridsOrder(ToolBarRightNumArray);
        }


        private void ContentsBar_Arrangement()
        {
            if (ContentsBarType.Equals("Vector"))
            {
                ContentsBarNumArray = new int[] { 1, 2, 3, 4, 5 };
                ContentsBarNumArray = Utility.RamdomArray(ContentsBarNumArray);
                contentsBarVector = new ContentsBarVector(ContentsBarNumArray);

                contentsBarVector.SetParentClass(ParentClass);
                contentsBarVector.Parent(this);
                contentsBarVector.SetWidth(265);
                //contentsBarVector.SetHeight(WindowHeight - (toolBarTop.GetHeight()));
                contentsBarVector.SetHeight(WindowHeight - (toolBarTop.GetHeight()));
                contentsBarVector.SetGridsOrder(ContentsBarNumArray);
            }
            /*
            else
            {
                ContentsBarNumArray = new int[] { 11, 12, 13, 14, 15,
                                                  21, 22, 23, 24, 25,
                                                  31, 32, 33, 34, 35,
                                                  41, 42, 43, 44, 45,
                                                  51, 52, 53, 54, 55};
                contentsBarGrid = new ContentsBarGrid(ContentsBarNumArray);
                contentsBarGrid.SetParentClass(ParentClass);
                contentsBarGrid.Parent1(this);
                contentsBarGrid.SetWidth(310);
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
            MainContentsNumArray = Utility.RamdomArray(MainContentsNumArray);
            maincontentsNumArrayList = new List<int[]>();

            MainContents1NumArray = new int[90];
            for (int i = 0; i < MainContents1NumArray.Length; i++)
            {
                MainContents1NumArray[i] = i + 1;
                //Console.WriteLine(MainContents1NumArray[i] + "うおおおお");
            }
            MainContents1NumArray = Utility.RamdomArray(MainContents1NumArray);
            maincontentsNumArrayList.Add(MainContents1NumArray);

            MainContents2NumArray = new int[200];
            for (int i = 0; i < MainContents2NumArray.Length; i++)
            {
                MainContents2NumArray[i] = i + 1;
                //Console.WriteLine(MainContents2NumArray[i] + "うおおおお");
            }
            MainContents2NumArray = Utility.RamdomArray(MainContents2NumArray);
            maincontentsNumArrayList.Add(MainContents2NumArray);

            MainContents3NumArray = new int[90];
            for (int i = 0; i < MainContents3NumArray.Length; i++)
            {
                MainContents3NumArray[i] = i + 1;
                //Console.WriteLine(MainContents3NumArray[i] + "うおおおお");
            }
            MainContents3NumArray = Utility.RamdomArray(MainContents3NumArray);
            maincontentsNumArrayList.Add(MainContents3NumArray);

            MainContents4NumArray = new int[17];
            for (int i = 0; i < MainContents4NumArray.Length; i++)
            {
                MainContents4NumArray[i] = i + 1;
                //Console.WriteLine(MainContents4NumArray[i] + "うおおおお");
            }
            MainContents4NumArray = Utility.RamdomArray(MainContents4NumArray);
            maincontentsNumArrayList.Add(MainContents4NumArray);

            MainContents5NumArray = new int[5];
            for (int i = 0; i < MainContents5NumArray.Length; i++)
            {
                MainContents5NumArray[i] = i + 1;
                //Console.WriteLine(MainContents5NumArray[i] + "うおおおお");
            }
            MainContents5NumArray = Utility.RamdomArray(MainContents5NumArray);
            maincontentsNumArrayList.Add(MainContents5NumArray);

        }

        private void MaincontentsSet(int i_)
        {
            if (i_ > 0)
            {
                maincontents[i_ - 1].ChangeVisible();
                maincontents[i_ - 1] = null;

            }
            //int x = MainContentsNumArray[i_];
            MainContents child_maincontents = new MainContents(maincontentsNumArrayList[MainContentsNumArray[i_] - 1]);
            child_maincontents.SetParentClass(ParentClass);
            child_maincontents.Parent(this);
            child_maincontents.SetWidth(WindowWidth - contentsBarVector.GetWidth() - toolBarRight.GetWidth());
            child_maincontents.SetHeight(contentsBarVector.GetHeight());
            child_maincontents.SetGridsOrder(MainContentsNumArray[i_]);
            maincontents.Add(child_maincontents);

            //maincontents
            Grid.SetColumn(maincontents[i_].mainContentsGrid, 1);
            Grid.SetRow(maincontents[i_].mainContentsGrid, 1);
            maingrid.Children.Add(maincontents[i_].mainContentsGrid);
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
            colDef2 = new ColumnDefinition { Width = new GridLength(this.Width - contentsBarVector.GetWidth() - toolBarRight.GetWidth()) };
            colDef3 = new ColumnDefinition { Width = new GridLength(toolBarRight.GetWidth()) };

            Console.WriteLine(colDef1.Width + "; " + colDef2.Width + "; " + colDef3.Width + "");
            //Row : 列 Height
            rowDef1 = new RowDefinition { Height = new GridLength(toolBarTop.GetHeight()) };
            rowDef2 = new RowDefinition { Height = new GridLength(contentsBarVector.GetHeight()) };
            rowDef3 = new RowDefinition { Height = new GridLength(0) };
            Console.WriteLine(rowDef1.Height + "; " + rowDef2.Height + "; " + rowDef3.Height + "");

            maingrid.ColumnDefinitions.Add(colDef1);
            maingrid.ColumnDefinitions.Add(colDef2);
            maingrid.ColumnDefinitions.Add(colDef3);

            maingrid.RowDefinitions.Add(rowDef1);
            maingrid.RowDefinitions.Add(rowDef2);
            //maingrid.RowDefinitions.Add(rowDef3);



            //maincontents
            /*
            Grid.SetColumn(maincontents.mainContentsGrid, 1);
            Grid.SetRow(maincontents.mainContentsGrid, 1);
            maingrid.Children.Add(maincontents.mainContentsGrid);*/
            //contentsBar
            Grid.SetColumn(contentsBarVector.contentsBarMainGrid, 0);
            Grid.SetRow(contentsBarVector.contentsBarMainGrid, 1);
            maingrid.Children.Add(contentsBarVector.contentsBarMainGrid);
            //toolBar1
            Grid.SetColumn(toolBarTop.toolBarGrid, 0);
            Grid.SetRow(toolBarTop.toolBarGrid, 0);
            Grid.SetColumnSpan(toolBarTop.toolBarGrid, 3);
            maingrid.Children.Add(toolBarTop.toolBarGrid);
            //toolBar3
            Grid.SetColumn(toolBarRight.toolBarGrid, 2);
            Grid.SetRow(toolBarRight.toolBarGrid, 1);
            //Grid.SetColumnSpan(toolBar3.myToolBarGrid, 2);
            maingrid.Children.Add(toolBarRight.toolBarGrid);
        }


        private void SaveLayoutSetting()
        {
            Console.WriteLine("Layout" + LayoutNum);
            Console.WriteLine("ToolBarTop" + "True");
            Console.WriteLine("ToolBarOrder");
            Console.WriteLine("ToolBarTop1_NumArray");
            foreach (int i in ToolBarTop1NumArray)
            {
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
            Console.WriteLine("ContentsBar" + ContentsBarType);
            Console.WriteLine("MainContents");
            foreach (int i in MainContentsNumArray)
            {
                Console.WriteLine(i);
            }
        }

        static int Phase = 1;

        public Boolean scenario(String text1, String text2)
        {
            Console.WriteLine("ScenarioNum" + ScenarioNum);
            String WindowTitle = "Layout3 :";
            String Next = "";
            Boolean Flag = false;
            switch (ScenarioNum % 5)
            {
                //コンテンツバー1番  ContentsBarVector_C01_R01
                case (1):
                    if (text1.Equals("ContentsBarVector") && text2.Equals("Number" + Phase))
                    {
                        //メインコンテンツ1
                        MaincontentsSet(Phase - 1);
                        ScenarioNum++;

                        Next = "MainContentsの1をクリック";
                        Flag = true;
                    }
                    else
                    {
                        Next = "ContentsBarの" + Phase + "をクリック";
                    }

                    break;

                case (2):
                    //クリックした1番の色を変える
                    if (text1.Equals("MainContents") && text2.Equals("Number1"))
                    {
                        //maincontents[0].ChangeColor(1);
                        ScenarioNum++;
                        Next = "ToolBarTopの" + Phase + "の1をクリック";
                        Flag = true;
                    }
                    else
                    {
                        Next = "MainContentsの" + Phase + "をクリック";
                    }
                    break;


                //ツールバー1-1
                case (3):
                    if (text1.Equals("ToolBarTop" + ToolBarTopOrder[Phase - 1]) && text2.Equals("Number1"))
                    {
                        //メインコンテンツの色を変える
                        maincontents[Phase - 1].ChangeColor(2);
                        ScenarioNum++;
                        Next = "MainContentsの2をクリック";
                        Flag = true;
                    }
                    else
                    {
                        Next = "ToolBarTopの" + Phase + "の1をクリック";
                    }
                    break;


                //メインコンテンツ色の変わったところ
                case (4):
                    if (text1.Equals("MainContents") && text2.Equals("Number2"))
                    {
                        ScenarioNum++;
                        Next = "ToolBarRightの" + Phase + "をクリック";
                        Flag = true;
                    }
                    else
                    {
                        Next = "MainContentsの2をクリック";
                    }
                    break;

                //ツールバーの下の1番
                case (0):
                    if (text1.Equals("ToolBarRight") && text2.Equals("Number" + Phase))
                    {
                        ScenarioNum++;
                        Flag = true;
                        Next = "ContentsBarの" + (Phase + 1) + "をクリック";
                        if (Phase == 5)
                        {
                            Next = "実験終了です";
                            Utility.StopWatch("Stop");
                        }
                        Phase++;
                    }
                    else
                    {
                        Next = "ToolBarRightの" + Phase + "をクリック";
                        //Console.WriteLine("NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
                    }
                    //色を変える

                    break;




            }

            /*
             * String WindowTitle = "Layout1 :";
            String Next = "";
             */
            this.Title = WindowTitle + " :" + "Next : " + Next + "                                                                                                   " + "ScenarioNum" + ScenarioNum;
            return Flag;
        }

    }
}
