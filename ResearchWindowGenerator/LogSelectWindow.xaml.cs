using System;
using System.Collections.Generic;
using System.IO;
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
    /// LogSelectWindow.xaml の相互作用ロジック
    /// </summary>
    /// 

    public partial class LogSelectWindow : Window
    {
        String filePath = @"../../../LogFolder/";
        String[] csvlist;
        public LogSelectWindow()
        {
            InitializeComponent();
            LogFetch();
            csvList_ConboBox.SelectedIndex = 0;

        }

        private void LogFetch()
        {
            try
            {
                csvlist = Directory.GetFiles(filePath, "*");
                foreach (string name in csvlist)
                {
                    Console.WriteLine(name);
                }
                InitializeComboBox(csvlist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        private void InitializeComboBox(string[] _csvNameList)
        {

            //Windowlist
            foreach (string i in _csvNameList)
            {
                this.csvList_ConboBox.Items.Add(i);
            }

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LogDrawing_Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedCsvName = csvList_ConboBox.Text;
            int csvNum = Array.IndexOf(csvlist, selectedCsvName);
            string file_pass = this.csvList_ConboBox.Text;
            ResarchWindowTest_Log resarchWindowTest_Log = new ResarchWindowTest_Log(file_pass);
            resarchWindowTest_Log.Show();
            this.Close();
        }


    }
}
