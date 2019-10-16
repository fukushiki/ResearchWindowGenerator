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
        string[] windowNames = { "ResearchWindowPowerPoint", "ResearchWindowPDF", "ResearchWindowCalendar", "ResearchWindowTest","ResearchWindowTest_Log" , "WindowTemplate" };

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

            switch (selected_windowname)
            {
                case "ResearchWindowTest":
                    ResearchWindowTest researchWindowTest = new ResearchWindowTest("", false);
                    researchWindowTest.Show();
                    break;
                case "ResearchWindowPowerPoint":
                    ResearchWindowPowerPoint researchWindowPowerPoint = new ResearchWindowPowerPoint("", false);
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
                    /*
                case 3:
                    Console.WriteLine(windowNames[3]);
                    break;
                case 4:
                    Console.WriteLine(windowNames[4]);
                    break;
                case 5:
                    Console.WriteLine(windowNames[5]);
                    ResearchWindowTest researchWindowTest = new ResearchWindowTest("",false);
                    researchWindowTest.Show();
                    break;
                case 6:
                    Console.WriteLine(windowNames[5]);
                    ResearchWindowTest_Log researchWindowTest_Log = new ResearchWindowTest_Log("test");
                    researchWindowTest_Log.Show();
                    break;
                */
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            this.Close();
        }
    }

    
}
