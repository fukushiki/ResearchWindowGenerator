using ResearchWindowGenerator.ResearchWindow;
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

namespace ResearchWindowGenerator
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectWindow : Window
    {
        //string[] windowNames = { "ResearchWindowPowerPoint", "ResearchWindowPDF", "ResearchWindowCalendar", "ResearchWindowTest","ResearchWindowTest_Log" , "WindowTemplate" , "WindowTest"};
        //string[] windowNames = { "ResarchWindowLayout" };
        string[] windowNames = { "Layout1", "Layout1_2", "Layout2", "Layout2_2", "Layout3", "Layout3_2" };
        public SelectWindow()
        {
            InitializeComponent();
            Windowlist_ComboBox.SelectedIndex = 0;
            InitializeComboBox();
            
        }

        private void InitializeComboBox()
        {
            
            //Windowlist
            foreach (string i in windowNames)
            {
                this.Windowlist_ComboBox.Items.Add(i);
            }

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO : Xamlによって作成するWindowの作り分けをする
            string selected_windowname = Windowlist_ComboBox.Text;
            Console.WriteLine(selected_windowname);

            /*
            switch (selected_windowname)
            {
                case "ResearchWindowTest":
                    ResearchWindowTest researchWindowTest = new ResearchWindowTest("", false);
                    researchWindowTest.Show();
                    break;
                case "ResearchWindowPowerPoint":
                    ResearchWindowPowerPoint researchWindowPowerPoint = new ResearchWindowPowerPoint("ResarchWindowPowerPoint","","", false);
                    researchWindowPowerPoint.Show();
                    break;
                case "ResearchWindowPDF":
                    ResearchWindowPDF researchWindowPDF = new ResearchWindowPDF("","",false);
                    researchWindowPDF.Show();
                    break;
                case "WindowTemplate":
                    WindowTemplate windowTemplate = new WindowTemplate("WindowTemplate","","", false);
                    windowTemplate.Show();
                    break;
                case "WindowTest":
                    WindowTest windowTest = new WindowTest("WindowTest", "", "", false);
                    windowTest.Show();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            */

            switch (selected_windowname)
            {
                case "ResarchWindowLayout":
                    //TODO: ここを動的に設定
                    int patternnum = 1;
                    ResearchWindowLayout researchWindowLayout = new ResearchWindowLayout("ResarchWindowLayout", patternnum, "", "", false);
                    researchWindowLayout.Show();
                    break;
                case "Layout1":
                    Layout1 layout1 = new Layout1();
                    layout1.Show();
                    break;
                case "Layout1_2":
                    Layout1_2 layout1_2 = new Layout1_2();
                    layout1_2.Show();
                    break;
                case "Layout2":
                    Layout2 layout2 = new Layout2();
                    layout2.Show();
                    break;
                case "Layout2_2":
                    Layout2_Grid layout2_Grid = new Layout2_Grid();
                    layout2_Grid.Show();
                    break;
                case "Layout3":
                    Layout3 layout3 = new Layout3();
                    layout3.Show();
                    break;
                case "Layout3_Grid":
                    Layout3_Grid layout3_Grid = new Layout3_Grid();
                    layout3_Grid.Show();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;

            }
            this.Close();
        }
    }

    
}
