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
        
        public SelectWindow()
        {
            InitializeComponent();
            Windowlist_ComboBox.SelectedIndex = 0;
            InitializeComboBox();
            
        }

        private void InitializeComboBox()
        {
            string[] window_number = { "ResearchWindow1", "ResearchWindow2", "ResearchWindow3", "ResearchWindow4", "ResearchWindow5" };
            //Windowlist
            foreach (string i in window_number)
            {
                this.Windowlist_ComboBox.Items.Add(i);
            }

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO : Xamlによって作成するWindowの作り分けをする
            //Console.WriteLine(Windowlist_ComboBox.Items.IndexOf(Windowlist_ComboBox.Text));
            //ResarchWindows researchWindow1 = new ResarchWindows();
                
        }
    }

    
}
