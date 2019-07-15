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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;

namespace ResearchWindowGenerator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>


    public partial class MainWindow : Window
    {
        private const string filePathCsv = @"../../../ResearchProperties/UserListConfig.csv";
        private List<string[]> csvList = new List<string[]>();
        string[] csvContents = File.ReadAllLines(filePathCsv);
        //string UserClassList =
        SelectWindow selectWindow;
        public MainWindow()
        {
            InitializeComponent(); //XAMLから初期配置を設定するらしい
            //ReadCsv();
            
            InitializeComboBox();
            Subject_Name.Text = "";
            Belonglist_ComboBox.SelectedIndex = 0;
            Gradelist_ComboBox.SelectedIndex = 0;
            //TODO:設定ファイルがないなら設定メモファイルを生成するように設計
            Initialize.InitializeDesktopInfo();


        }
        //TODO :いつか設定をCSVファイルでできるようにします
        public void ReadCsv()
        {
            string[] csvContents = File.ReadAllLines(filePathCsv);
            foreach(string s in csvContents){
                Console.WriteLine(s);
            }
            
        }
        //コンボボックスのInit
        private void InitializeComboBox()
        {
            string[] belong = {"経済学部","教育学部"};
            string[] grade = { "1年", "2年", "3年", "4年", "M1", "M2" };
            //Belong_List 所属
            foreach (string i in belong)
            {
                this.Belonglist_ComboBox.Items.Add(i);
            }
            
            //Grade_List 学年
            foreach(string i in grade)
            {
                this.Gradelist_ComboBox.Items.Add(i);
            }
        }

        private void Belonglist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Gradelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //ボタンをクリックした際の挙動
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //中身の有無のチェック
            string[] allstring = { Subject_Name.Text, Belonglist_ComboBox.Text, Gradelist_ComboBox.Text };
            bool is_contents_flag = true;
            //foreach(string str in allstring) { Console.WriteLine((!(str).Equals("")) ? str : "記入漏れがあります") ; }
            foreach (string str in allstring) { is_contents_flag = (!(str).Equals("")&&!(str).Equals("選択してください") )? true : false; }

            if (is_contents_flag) {
                //ログ生成
                /*
                Console.WriteLine("ユーザー名 : "+Subject_Name.Text);
                Console.WriteLine("所属 : "+Belonglist_ComboBox.Text);
                Console.WriteLine("学年 : "+Gradelist_ComboBox.Text);
                */
                Logger.SaveUserData(Subject_Name.Text, Belonglist_ComboBox.Text, Gradelist_ComboBox.Text);

                selectWindow = new SelectWindow();
                selectWindow.Show();
                this.Close();

            }
            else
            {
                Console.WriteLine("記入漏れがあります");
                AlertTextBox.Text = "記入漏れがあります";
            }

        }
    }
}
    