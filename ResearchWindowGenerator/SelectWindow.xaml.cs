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
        string[] windowNames = { "ResearchWindow1", "ResearchWindow2", "ResearchWindow3", "ResearchWindow4", "ResearchWindow5" ,"ResarchWindowTest","ResearchWindowTest_Log"};

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

            switch (Array.IndexOf(windowNames, selected_windowname))
            {
                case 0:
                    Console.WriteLine(windowNames[0]);
                    
                    break;
                case 1:
                    Console.WriteLine(windowNames[1]);
                    break;
                case 2:
                    Console.WriteLine(windowNames[2]);
                    break;
                case 3:
                    Console.WriteLine(windowNames[3]);
                    break;
                case 4:
                    Console.WriteLine(windowNames[4]);
                    break;
                case 5:
                    Console.WriteLine(windowNames[5]);
                    ResarchWindowTest resarchWindowTest = new ResarchWindowTest();
                    resarchWindowTest.Show();
                    break;
                case 6:
                    Console.WriteLine(windowNames[5]);
                    ResarchWindowTest_Log resarchWindowTest_Log = new ResarchWindowTest_Log("test");
                    resarchWindowTest_Log.Show();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            //TODO : Windowが選択できるようにする
            //ResarchWindowTest resarchWindowTest = new ResarchWindowTest();
            this.Close();
        }
    }

    
}
