using ResearchWindowGenerator.ResearchWindow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        public StackPanel stackPanel;

        List<Button[]> buttonList;
        List<StackPanel[]> stackPanelList;


        ColumnDefinition colDef_;
        RowDefinition rowDef_;

        private string parentClass;
        private Layout1 layout1;
        private Layout1_Grid layout1_Grid;
        private Layout2 layout2;
        private Layout2_Grid layout2_Grid;
        private Layout3 layout3;
        private Layout3_Grid layout3_Grid;


        static int MainContentsCreateCount = 0;

        /// <summary>
        /// MainContentsの生成番号
        /// </summary>
        private int MainContentsNumber;

        /// <summary>
        /// メインコンテンツの種類 1: 2: 3: 4: 5: 
        /// </summary>
        private int MainContentsGridTypeNum;

        private int[] NumArray;

        private Polygon myPolygonTriangle1;
        private Polygon myPolygonTriangle2;
        
        private Polygon myPolygon_Rectangle1;
        private Polygon myPolygon_Rectangle2;

        private Polygon myPolygon_Circle;


        int[,] Maincontents1 = { { 0, 6 }, { 3, 7 }, { 7, 4 }, { 6, 0 }, { 1, 1 } };
        int[,] Maincontents2 = { { 1, 0 }, { 5, 5 }, { 7, 7 }, { 4, 0 }, { 0, 4 } };
        int[,] Maincontents3 = { { 7, 6 }, { 1, 1 }, { 7, 1 }, { 4, 4 }, { 0, 6 } };
        int[,] Maincontents4 = { { 6, 2 }, { 7, 0 }, { 1, 1 }, { 5, 5 }, { 1, 6 } };
        int[,] Maincontents5 = { { 3, 6 }, { 7, 7 }, { 0, 0 }, { 0, 6 }, { 6, 2 } };
        int[,] Maincontents6 = { { 1, 1 }, { 0, 8 }, { 3, 4 }, { 6, 1 }, { 6, 7 } };
        int[,] Maincontents7 = { { 6, 0 }, { 1, 5 }, { 6, 7 }, { 0, 0 }, { 6, 4 } };
        int[,] Maincontents8 = { { 8, 7 }, { 3, 6 }, { 1, 0 }, { 0, 3 }, { 6, 1 } };
        int[,] Maincontents9 = { { 7, 1 }, { 6, 7 }, { 3, 1 }, { 0, 2 }, { 0, 7 } };
        int[,] Maincontents10 = { { 0, 7 }, { 8, 7 }, { 0, 2 }, { 7, 1 }, { 3, 4 } };
        List<int[,]> MainContents5Place = new List<int[,]>();
        private Ellipse ellipse;
        int[] Maincontents5NumArray = { 1, 2, 3, 4, 5 };

        public MainContents(int[] v)
        {
            NumArray = v;
            MainContentsCreateCount++;
            MainContentsNumber = MainContentsCreateCount;
            
            MainContents5Place.Add(Maincontents1);
            MainContents5Place.Add(Maincontents2);
            MainContents5Place.Add(Maincontents3);
            MainContents5Place.Add(Maincontents4);
            MainContents5Place.Add(Maincontents5);
            MainContents5Place.Add(Maincontents6);
            MainContents5Place.Add(Maincontents7);
            MainContents5Place.Add(Maincontents8);
            MainContents5Place.Add(Maincontents9);
            MainContents5Place.Add(Maincontents10);




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
                //Background = Brushes.DarkOrange,
                //ShowGridLines = true
# endif
            };

            


            //ToolBarOrderの順で定義していく
            
                Console.WriteLine("debug:MainContentsGridType:::::" + MainContentsGridTypeNum);
            
            
            switch (MainContentsGridTypeNum)
            {


                case 1:
                    //6 15
                    SetButtonList(6,15);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(6, 15);

                    //ここでそれぞれ配置
                    SetStackPanels(6,15);



                    break;
                case 2:

                    SetButtonList(40, 5);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(40, 5);

                    //ここでそれぞれ配置
                    SetStackPanels(40, 5);
                    break;
                case 3:
                    SetButtonList(15, 6);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(15, 6);

                    //ここでそれぞれ配置
                    SetStackPanels(15, 6);

                    break;
                case 4:
                    SetButtonList(17, 1);
                    //GridRow 行
                    //GridColumn 列
                    GridSet(17, 1);

                    //ここでそれぞれ配置
                    SetStackPanels(17, 1);

                    break;
                case 5:

                    GridSet5(12, 12);
                    SetObject();

                    break;
            }





        }


        private void GridSet5(int row_, int column_)
        {
            gridHeight = (this.Height - this.Height * 0.05) / (row_ - 2);
            gridWidth = (gridHeight * 1.5) * (row_ - 2) / (column_ - 2);//(this.Width - gridHeight * 3 / 2) /(column_-2) ;

            rowDef = new RowDefinition[row_];
            colDef = new ColumnDefinition[column_];


            rowDef[0] = new RowDefinition { Height = new GridLength((this.Height * 0.05) / 2) };
            mainContentsGrid.RowDefinitions.Add(rowDef[0]);

            colDef[0] = new ColumnDefinition { Width = new GridLength((this.Width - (gridHeight * 1.5) * (row_ - 2)) / 2) };
            mainContentsGrid.ColumnDefinitions.Add(colDef[0]);

            //行の設定
            for (int gridRow_num = 1; gridRow_num < row_ - 1; gridRow_num++)
            {
                rowDef[gridRow_num] = new RowDefinition { Height = new GridLength(gridHeight) };
                mainContentsGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 1; gridColumn_num < column_ - 1; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                mainContentsGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }

            rowDef[row_ - 1] = new RowDefinition { Height = new GridLength((this.Height * 0.05) / 2) };
            mainContentsGrid.RowDefinitions.Add(rowDef[row_ - 1]);

            colDef[column_ - 1] = new ColumnDefinition { Width = new GridLength((this.Width - (gridHeight * 1.5) * (row_ - 2)) / 2) };
            mainContentsGrid.ColumnDefinitions.Add(colDef[column_ - 1]);
        }

        private void SetObject()
        {

            
            Random random = new Random();
            int Maincontents5Pattern = random.Next(0, 9);
            //int aaa = MainContents5Place[Maincontents5Pattern][random.Next(0,9),0];



            List<Canvas> CanvasList = new List<Canvas>();
            
            Maincontents5NumArray = Utility.RamdomArray(Maincontents5NumArray);

            Canvas canvas23 = new Canvas
            {
                Height = gridHeight*2,
                Width = gridWidth*3,
                Background = Brushes.OrangeRed,
                
                Name = "canvas23" + "Row" + (MainContents5Place[Maincontents5Pattern][0, 0] + 1).ToString()
                + "Column" + (MainContents5Place[Maincontents5Pattern][0, 1] + 1).ToString()

            };
            CanvasList.Add(canvas23);
            mainContentsGrid.Children.Add(canvas23);
            Grid.SetRow(canvas23,MainContents5Place[Maincontents5Pattern][0, 0]+1);
            Grid.SetColumn(canvas23, MainContents5Place[Maincontents5Pattern][0, 1]+1);


            //mainContentsGrid.Children.Add(Border_Canvas23);
            TextBlock canvas23text = new TextBlock
            {
                Text = Maincontents5NumArray[0].ToString(),
                FontSize = 20
                
            };
            
            mainContentsGrid.Children.Add(canvas23text);
            Grid.SetRow(canvas23text, MainContents5Place[Maincontents5Pattern][0, 0] + 1);
            Grid.SetColumn(canvas23text, MainContents5Place[Maincontents5Pattern][0, 1] + 1);

            

            








            Canvas canvas32 = new Canvas
            {
                Height = gridHeight * 3,
                Width = gridWidth * 2,
                Background = Brushes.Green,
                Name = "canvas32" + "Row" + (MainContents5Place[Maincontents5Pattern][1, 0] + 1).ToString()
                + "Column" + (MainContents5Place[Maincontents5Pattern][1, 1] + 1).ToString(),
                Tag = "canvas32"

            };
            CanvasList.Add(canvas32);
            mainContentsGrid.Children.Add(canvas32);
            Grid.SetRow(canvas32, MainContents5Place[Maincontents5Pattern][1, 0] + 1);
            Grid.SetColumn(canvas32, MainContents5Place[Maincontents5Pattern][1, 1] + 1);

            TextBlock canvas32text = new TextBlock
            {
                Text = Maincontents5NumArray[1].ToString(),
                FontSize = 20

            };

            mainContentsGrid.Children.Add(canvas32text);
            Grid.SetRow(canvas32text, MainContents5Place[Maincontents5Pattern][1, 0] + 1);
            Grid.SetColumn(canvas32text, MainContents5Place[Maincontents5Pattern][1, 1] + 1);








            Canvas canvas33 = new Canvas
            {
                Height = gridHeight * 3,
                Width = gridWidth * 3,
                Background = Brushes.Blue,
                
                Name = "canvas33" + "Row" + (MainContents5Place[Maincontents5Pattern][2, 0] + 1).ToString()
                + "Column" + (MainContents5Place[Maincontents5Pattern][2, 1] + 1).ToString(),
                Tag = "canvas33"
            };
            CanvasList.Add(canvas33);
            mainContentsGrid.Children.Add(canvas33);
            Grid.SetRow(canvas33, MainContents5Place[Maincontents5Pattern][2, 0] + 1);
            Grid.SetColumn(canvas33, MainContents5Place[Maincontents5Pattern][2, 1] + 1);



            TextBlock canvas33text = new TextBlock
            {
                Text = Maincontents5NumArray[2].ToString(),
                FontSize = 20,
                

            };

            mainContentsGrid.Children.Add(canvas33text);
            Grid.SetRow(canvas33text, MainContents5Place[Maincontents5Pattern][2, 0] + 1);
            Grid.SetColumn(canvas33text, MainContents5Place[Maincontents5Pattern][2, 1] + 1);







            Canvas canvas34 = new Canvas
            {
                Height = gridHeight * 3,
                Width = gridWidth * 4,
                Background = Brushes.Orange,
                Name = "canvas34" + "Row"+(MainContents5Place[Maincontents5Pattern][3, 0] + 1).ToString()
                +"Column" + (MainContents5Place[Maincontents5Pattern][3, 1] + 1).ToString(),
                Tag = "canvas34"


            };
            CanvasList.Add(canvas34);
            mainContentsGrid.Children.Add(canvas34);
            Grid.SetRow(canvas34, MainContents5Place[Maincontents5Pattern][3, 0] + 1);
            Grid.SetColumn(canvas34, MainContents5Place[Maincontents5Pattern][3, 1] + 1);

            TextBlock canvas34text = new TextBlock
            {
                Text = Maincontents5NumArray[3].ToString(),
                FontSize = 20

            };

            mainContentsGrid.Children.Add(canvas34text);
            Grid.SetRow(canvas34text, MainContents5Place[Maincontents5Pattern][3, 0] + 1);
            Grid.SetColumn(canvas34text, MainContents5Place[Maincontents5Pattern][3, 1] + 1);





            Canvas canvas43 = new Canvas
            {
                Height = gridHeight * 4,
                Width = gridWidth * 3,
                Background = Brushes.Yellow,
                Name = "canvas43" + "Row" + (MainContents5Place[Maincontents5Pattern][4, 0] + 1).ToString()
                + "Column" + (MainContents5Place[Maincontents5Pattern][4, 1] + 1).ToString(),
                Tag = "canvas43",
            };
            CanvasList.Add(canvas43);
            mainContentsGrid.Children.Add(canvas43);
            Grid.SetRow(canvas43, MainContents5Place[Maincontents5Pattern][4, 0] + 1);
            Grid.SetColumn(canvas43, MainContents5Place[Maincontents5Pattern][4, 1] + 1);

            TextBlock canvas43text = new TextBlock
            {
                Text = Maincontents5NumArray[4].ToString(),
                FontSize = 20

            };

            mainContentsGrid.Children.Add(canvas43text);
            Grid.SetRow(canvas43text, MainContents5Place[Maincontents5Pattern][4, 0] + 1);
            Grid.SetColumn(canvas43text, MainContents5Place[Maincontents5Pattern][4, 1] + 1);





            Random rnd = new Random();


            //三角
            //Add the Polygon Element
            myPolygonTriangle1 = new Polygon();
            myPolygonTriangle1.Stroke = System.Windows.Media.Brushes.Black;
            myPolygonTriangle1.Fill = System.Windows.Media.Brushes.Gray;
            myPolygonTriangle1.StrokeThickness = 2;
            myPolygonTriangle1.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygonTriangle1.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1_Triangle = new System.Windows.Point((int)rnd.Next(10, (int)CanvasList[0].Width-10), (int)rnd.Next(10, (int)CanvasList[0].Height - 10));
            System.Windows.Point Point2_Triangle = new System.Windows.Point((int)rnd.Next(10, (int)CanvasList[0].Width - 10), (int)rnd.Next(10, (int)CanvasList[0].Height - 10));
            System.Windows.Point Point3_Triangle = new System.Windows.Point((int)rnd.Next(10, (int)CanvasList[0].Width - 10), (int)rnd.Next(10, (int)CanvasList[0].Height - 10));
            PointCollection myPointCollection_Triangle = new PointCollection();
            myPointCollection_Triangle.Add(Point1_Triangle);
            myPointCollection_Triangle.Add(Point2_Triangle);
            myPointCollection_Triangle.Add(Point3_Triangle);
            myPolygonTriangle1.Points = myPointCollection_Triangle;
            CanvasList[0].Children.Add(myPolygonTriangle1);
            myPolygonTriangle1.MouseDown += PolygonMouseDown;
            myPolygonTriangle1.Name = "MainContents_" + MainContentsGridTypeNum ;
            myPolygonTriangle1.Tag = "Number" +  Maincontents5NumArray[0];

            /*
                                 button[j].Name = "MainContents"+ MainContentsGridTypeNum +"C" + j + "R" + i;
                    button[j].Tag = "Number" + NumArray[i * column_ + j];
             */

            //丸

            ellipse = new Ellipse { };
            
            ellipse.Stroke = System.Windows.Media.Brushes.Black;
            ellipse.Fill = System.Windows.Media.Brushes.Gray;
            ellipse.StrokeThickness = 2;

            //ellipse.HorizontalAlignment = HorizontalAlignment.Center;
            //ellipse.VerticalAlignment = VerticalAlignment.Center;
            ellipse.HorizontalAlignment = HorizontalAlignment.Center;
            ellipse.VerticalAlignment = VerticalAlignment.Center;
            Canvas.SetTop(ellipse, 80);
            Canvas.SetLeft(ellipse, 80);
            ellipse.Width = (int)rnd.Next(10, (int)CanvasList[1].Width - 80);
            ellipse.Height = (int)rnd.Next(10, (int)CanvasList[1].Height - 80);
            CanvasList[1].Children.Add(ellipse);
            ellipse.Name = "MainContents_" + MainContentsGridTypeNum;
            ellipse.Tag = "Number" + Maincontents5NumArray[1];

            ellipse.MouseDown += EllipseMouseDown;




            //長方形
            myPolygon_Rectangle1 = new Polygon();
            myPolygon_Rectangle1.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon_Rectangle1.Fill = System.Windows.Media.Brushes.Gray;
            myPolygon_Rectangle1.StrokeThickness = 2;
            myPolygon_Rectangle1.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon_Rectangle1.VerticalAlignment = VerticalAlignment.Center;
            int RectangleX1 = (int)rnd.Next(10, (int)CanvasList[2].Width/2 - 10);
            int RectangleX2 = (int)rnd.Next((int)CanvasList[2].Width/2, (int)CanvasList[2].Width - 10);
            int RectangleY1 = (int)rnd.Next(10, (int)CanvasList[2].Height/2 - 10);
            int RectangleY2 = (int)rnd.Next((int)CanvasList[2].Height/2 , (int)CanvasList[2].Height - 10);

            System.Windows.Point Point1_Rectangle = new System.Windows.Point(RectangleX1, RectangleY1);
            System.Windows.Point Point2_Rectangle = new System.Windows.Point(RectangleX1, RectangleY2);
            System.Windows.Point Point3_Rectangle = new System.Windows.Point(RectangleX2, RectangleY2);
            System.Windows.Point Point4_Rectangle = new System.Windows.Point(RectangleX2, RectangleY1);
            PointCollection myPointCollection_Rectangle = new PointCollection();
            myPointCollection_Rectangle.Add(Point1_Rectangle);
            myPointCollection_Rectangle.Add(Point2_Rectangle);
            myPointCollection_Rectangle.Add(Point3_Rectangle);
            myPointCollection_Rectangle.Add(Point4_Rectangle);
            myPolygon_Rectangle1.Points = myPointCollection_Rectangle;
            CanvasList[2].Children.Add(myPolygon_Rectangle1);
            //CanvasList[2].MouseDown += new MouseButtonEventHandler(Rectangle_MouseDown(RectangleX1,RectangleX2,RectangleY1,RectangleY2));
            //CanvasList[2].MouseDown += ((CanvasList[2], e, RectangleX1, RectangleX2, RectangleY1, RectangleY2) => MouseButtonEventHandler(Rectangle_MouseDown));

            //myPolygon_Rectangle1.MouseDown += (myPolygon_Rectangle1, e) => MouseButtonEventHandler(myPolygon_Rectangle1,e); 
            myPolygon_Rectangle1.Name = "MainContents_" + MainContentsGridTypeNum;
            myPolygon_Rectangle1.Tag = "Number" + Maincontents5NumArray[2];
            myPolygon_Rectangle1.MouseDown += PolygonMouseDown;

            //長方形
            myPolygon_Rectangle2 = new Polygon();
            myPolygon_Rectangle2.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon_Rectangle2.Fill = System.Windows.Media.Brushes.Gray;
            myPolygon_Rectangle2.StrokeThickness = 2;
            myPolygon_Rectangle2.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon_Rectangle2.VerticalAlignment = VerticalAlignment.Center;
            int Rectangle2X1 = (int)rnd.Next(10, (int)CanvasList[3].Width / 2 - 10);
            int Rectangle2X2 = (int)rnd.Next((int)CanvasList[3].Width / 2, (int)CanvasList[2].Width - 10);
            int Rectangle2Y1 = (int)rnd.Next(10, (int)CanvasList[3].Height / 2 - 10);
            int Rectangle2Y2 = (int)rnd.Next((int)CanvasList[3].Height / 2, (int)CanvasList[2].Height - 10);

            System.Windows.Point Point1_Rectangle2 = new System.Windows.Point(Rectangle2X1, Rectangle2Y1);
            System.Windows.Point Point2_Rectangle2 = new System.Windows.Point(Rectangle2X1, Rectangle2Y2);
            System.Windows.Point Point3_Rectangle2 = new System.Windows.Point(Rectangle2X2, Rectangle2Y2);
            System.Windows.Point Point4_Rectangle2 = new System.Windows.Point(Rectangle2X2, Rectangle2Y1);
            PointCollection myPointCollection_Rectangle2 = new PointCollection();
            myPointCollection_Rectangle2.Add(Point1_Rectangle2);
            myPointCollection_Rectangle2.Add(Point2_Rectangle2);
            myPointCollection_Rectangle2.Add(Point3_Rectangle2);
            myPointCollection_Rectangle2.Add(Point4_Rectangle2);
            myPolygon_Rectangle2.Points = myPointCollection_Rectangle2;
            CanvasList[3].Children.Add(myPolygon_Rectangle2);

            myPolygon_Rectangle2.Name = "MainContents_" + MainContentsGridTypeNum;
            myPolygon_Rectangle2.Tag = "Number" + Maincontents5NumArray[3];

            myPolygon_Rectangle2.MouseDown += PolygonMouseDown;

            //myPolygon_Rectangle.MouseDown += (sender, e) => Rectangle_MouseDown(sender, e, Rectangle2X1, Rectangle2X2, Rectangle2Y1, Rectangle2Y2);
            //myPolygon_Rectangle2.MouseDown += MouseDown;//(myPolygon_Rectangle2, e) => Rectangle_MouseDown(myPolygon_Rectangle2, e, Rectangle2X1, Rectangle2X2, Rectangle2Y1, Rectangle2Y2);


            //三角
            //Add the Polygon Element
            myPolygonTriangle2 = new Polygon();
            myPolygonTriangle2.Stroke = System.Windows.Media.Brushes.Black;
            myPolygonTriangle2.Fill = System.Windows.Media.Brushes.Gray;
            myPolygonTriangle2.StrokeThickness = 2;
            myPolygonTriangle2.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygonTriangle2.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1_Triangle2 = new System.Windows.Point((int)rnd.Next(10, (int)CanvasList[4].Width - 10), (int)rnd.Next(10, (int)CanvasList[4].Height - 10));
            System.Windows.Point Point2_Triangle2 = new System.Windows.Point((int)rnd.Next(10, (int)CanvasList[4].Width - 10), (int)rnd.Next(10, (int)CanvasList[4].Height - 10));
            System.Windows.Point Point3_Triangle2 = new System.Windows.Point((int)rnd.Next(10, (int)CanvasList[4].Width - 10), (int)rnd.Next(10, (int)CanvasList[4].Height - 10));
            PointCollection myPointCollection_Triangle2 = new PointCollection();
            myPointCollection_Triangle2.Add(Point1_Triangle2);
            myPointCollection_Triangle2.Add(Point2_Triangle2);
            myPointCollection_Triangle2.Add(Point3_Triangle2);
            myPolygonTriangle2.Points = myPointCollection_Triangle2;
            CanvasList[4].Children.Add(myPolygonTriangle2);

            myPolygonTriangle2.Name = "MainContents_" + MainContentsGridTypeNum;
            myPolygonTriangle2.Tag = "Number" + Maincontents5NumArray[4];

            myPolygonTriangle2.MouseDown += PolygonMouseDown;






        }

        private void PolygonMouseDown(object sender, MouseButtonEventArgs e)
        {
            Polygon polygon = sender as Polygon;
            polygon.Fill = System.Windows.Media.Brushes.Red;

            Console.WriteLine(polygon.Name);
            Console.WriteLine(polygon.Tag);

            string[] sprit = polygon.Name.Split('_');
            string text2 = polygon.Tag.ToString();

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

        private void EllipseMouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            ellipse.Fill = System.Windows.Media.Brushes.Red;

            Console.WriteLine(ellipse.Name);
            Console.WriteLine(ellipse.Tag);

            string[] sprit = ellipse.Name.Split('_');
            string text2 = ellipse.Tag.ToString();

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




        //private void MouseDown(object sender, MouseButtonEventArgs e) => (Polygon)sender.Fill = Brushes.Red;

        //polygon.Fill = System.Windows.Media.Brushes.Red;





        private void Rectangle_MouseDown(Polygon sender, MouseEventArgs e,  int rectangleX1, int rectangleX2, int rectangleY1, int rectangleY2)
        {
            /*
            Console.WriteLine("^^"+ e.GetPosition((Canvas)sender).X + e.GetPosition((Canvas)sender).Y);
            ;
            int ClickX = (int)e.GetPosition((Canvas)sender).X;
            int ClickY = (int)e.GetPosition((Canvas)sender).Y;
            
            if(rectangleX1 > rectangleX2)
            {
                int tmp;
                tmp = rectangleX1;
                rectangleX1 = rectangleX2;
                rectangleX2 = tmp;
            }
            if (rectangleY1 > rectangleY2)
            {
                int tmp;
                tmp = rectangleY1;
                rectangleY1 = rectangleY2;
                rectangleY2 = tmp;
            }


            if (ClickX > rectangleX1 && ClickX < rectangleX2) Console.WriteLine("X ok");
            if (ClickY > rectangleY1 && ClickY < rectangleY2) Console.WriteLine("Y ok");*/

            sender.Fill = System.Windows.Media.Brushes.Red;

        }

        private void SetButtonList(int row_, int column_)
        {
            buttonList = new List<Button[]>();
            for (int i = 0; i < row_; i++)
            {
                Button[] button = new Button[column_];
                for (int j = 0; j < column_; j++)
                {
                    button[j] = new Button();
                    //button[j].Click += MyMainContentsButton_Clicked;
                    button[j].Height = this.Height / row_;
                    button[j].Width = this.Width / column_;
                    button[j].Name = "MainContents_"+ MainContentsGridTypeNum +"C" + j + "R" + i;
                    button[j].Tag = "Number" + NumArray[i * column_ + j];
                    button[j].Click +=  MainContentsButton_Clicked;


                    



                }
                buttonList.Add(button);
            }

        }



        private void GridSet(int row_, int column_)
        {
            gridHeight = this.Height / row_;
            gridWidth = this.Width / column_ ;

            rowDef = new RowDefinition[row_];
            colDef = new ColumnDefinition[column_];

            //行の設定
            for (int gridRow_num = 0; gridRow_num < row_; gridRow_num++)
            {
                rowDef[gridRow_num] = new RowDefinition { Height = new GridLength(gridHeight) };
                mainContentsGrid.RowDefinitions.Add(rowDef[gridRow_num]);
            }

            //列の設定
            for (int gridColumn_num = 0; gridColumn_num < column_; gridColumn_num++)
            {
                colDef[gridColumn_num] = new ColumnDefinition { Width = new GridLength(gridWidth) };
                mainContentsGrid.ColumnDefinitions.Add(colDef[gridColumn_num]);
            }
        }


        public void SetStackPanels(int row_, int column_)
        {
            stackPanelList = new List<StackPanel[]>();

            /*
            List<int> numberList = new List<int>();
            for (int num = 1; num < ((( - 1) * (column_ - 1))); num++)
            {
                Console.WriteLine("天空橋" + num);
                numberList.Add(num);
            }

            Random r = new Random();
            numberList = numberList.OrderBy(a => r.Next(numberList.Count)).ToList();
            //numberListbuffer = numberList;



            string[] files = Directory.GetFiles("../../../ImageFolder", "*");
            List<Uri> uriList = new List<Uri>();
            int x = 0;
            foreach (string str in files)
            {
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + x);
                uriList.Add(new Uri(System.IO.Path.GetFullPath(str), UriKind.RelativeOrAbsolute));
                x++;
            }

            uriList = uriList.OrderBy(a => r.Next(uriList.Count)).ToList();
            //numberListbuffer = numberList;
            */






            int counter = 0;
            for (int i = 0; i < row_; i++)
            {
                StackPanel[] stackPanels = new StackPanel[column_];
                for (int j = 0; j < column_; j++)
                {


                    stackPanels[j] = new StackPanel
                    {
                        //TODO: StackPanelの中身を2~のやつも作る
                        Width = gridWidth,
                        Height = gridHeight,


                    };

                    Grid contentsGrid = new Grid
                    {
                        Width = stackPanels[j].Width,
                        Height = stackPanels[j].Height,
#if DEBUG
                        ShowGridLines = true,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
#endif
                    };

                    /*
                    System.Random r_ = new System.Random(1000);
                    //シード値を指定しないとシード値として Environment.TickCount が使用される
                    //System.Random r = new System.Random();

                    //0以上10未満の乱数を整数で返す
                    int i1 = r_.Next(i + j);
                    Grid contentsGrid = new Grid
                    {
                        Width = stackPanels[j].Width,
                        Height = stackPanels[j].Height,
#if DEBUG
                        ShowGridLines = true,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
#endif
                    };
                    stackPanels[j].Children.Add(contentsGrid);

                    
                    //Console.WriteLine("aaaaaaaaaa" + ((i + j).ToString()));
                    //img.Source = new BitmapImage(uriList[GridRow * (i - 1) + j + 2 ]);
                    //Console.WriteLine((i * GridRow).ToString() +"/"+ j.ToString());
                    //Console.WriteLine("眠たい"+counter);
                    //img.Source = new BitmapImage(uriList.ElementAt(counter));
                    img.Source = new BitmapImage(uriList.ElementAt(j + i + i1));
                    //Console.WriteLine("^^");
                    counter++;
                    */


                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"../../../ImageFolder/"+ NumArray[i * column_ + j] + ".png"), UriKind.RelativeOrAbsolute));
                    img.Height = stackPanels[j].Height * 0.8;

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = NumArray[i * column_ + j].ToString();
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.FontSize = stackPanels[j].Height * 0.8;



                    //ここでそれぞれ_maingrid_layoutnumでmaincontentsの中身を変更する

                    ColumnDefinition colDef1;
                    ColumnDefinition colDef2;
                    ColumnDefinition colDef3;
                    RowDefinition rowDef1;
                    RowDefinition rowDef2;
                    RowDefinition rowDef3;




                    switch (MainContentsGridTypeNum)
                    {
                        case (1)://特大アイコン
                            //Row : 列 Height
                            rowDef1 = new RowDefinition { Height = new GridLength() };
                            rowDef2 = new RowDefinition { Height = new GridLength() };
                            contentsGrid.RowDefinitions.Add(rowDef1);
                            contentsGrid.RowDefinitions.Add(rowDef2);
                            contentsGrid.Children.Add(img);
                            contentsGrid.Children.Add(textBlock);
                            textBlock.FontSize = 30;
                            Grid.SetRow(img, 0);
                            Grid.SetRow(textBlock, 1);
                            break;
                        
                        case (2)://一覧
                            //Column : 行 Width

                            colDef1 = new ColumnDefinition { Width = new GridLength() };
                            colDef2 = new ColumnDefinition { Width = new GridLength() };
                            contentsGrid.ColumnDefinitions.Add(colDef1);
                            contentsGrid.ColumnDefinitions.Add(colDef2);
                            contentsGrid.Children.Add(img);
                            contentsGrid.Children.Add(textBlock);
                            textBlock.FontSize = 20;
                            Grid.SetColumn(img, 0);
                            Grid.SetColumn(textBlock, 1);
                            break;
                        case (3)://並べて表示
                            //Column : 行 Width
                            colDef1 = new ColumnDefinition { Width = new GridLength() };
                            colDef2 = new ColumnDefinition { Width = new GridLength() };
                            contentsGrid.ColumnDefinitions.Add(colDef1);
                            contentsGrid.ColumnDefinitions.Add(colDef2);
                            contentsGrid.Children.Add(img);
                            //textBlock.Text = "Row:" + i + ", Col:" + j + "\n" + "TXTファイル" + "\n" + "0バイト";
                            contentsGrid.Children.Add(textBlock);
                            //textBlock.FontSize = 20;
                            Grid.SetColumn(img, 0);
                            Grid.SetColumn(textBlock, 1);
                            break;
                        case (4)://コンテンツ
                            //Column : 行 Width
                            colDef1 = new ColumnDefinition { Width = new GridLength() };
                            colDef2 = new ColumnDefinition { Width = new GridLength() };
                            colDef3 = new ColumnDefinition { Width = new GridLength() };
                            contentsGrid.ColumnDefinitions.Add(colDef1);
                            contentsGrid.ColumnDefinitions.Add(colDef2);
                            contentsGrid.ColumnDefinitions.Add(colDef3);
                            contentsGrid.Children.Add(img);
                            textBlock.FontSize = 30;
                            contentsGrid.Children.Add(textBlock);
                            TextBlock textBlock2 = new TextBlock
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                            };
                            textBlock2.Text = "更新日時: 2019/11/09 20:00" + "\n" + "サイズ: 0バイト";
                            //contentsGrid.Children.Add(textBlock2);

                            Grid.SetColumn(img, 0);
                            Grid.SetColumn(textBlock, 1);
                            //Grid.SetColumn(textBlock2, 2);
                            break;
                        case (5)://ランダム表示
                            break;
                        
                        default:
                            break;
                    };

                    /*
                     * 
                    StackPanel stack = new StackPanel();
                    stack.Width = button[j].Width;
                    stack.Height = button[j].Height;
                    button[j].Content = stack;
                    */

                    stackPanels[j].Children.Add(contentsGrid);





                    buttonList[i][j].Content = stackPanels[j];
                    //buttonList[i][j].Background = Brushes.Transparent;
                    this.mainContentsGrid.Children.Add(buttonList[i][j]);
                    Grid.SetRow(buttonList[i][j], i);
                    Grid.SetColumn(buttonList[i][j], j);




                }
                stackPanelList.Add(stackPanels);

            }


        }

        internal void ChangeColor(int i_)
        {
            
        }

        private void MainContentsButton_Clicked(object sender, RoutedEventArgs e)
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
