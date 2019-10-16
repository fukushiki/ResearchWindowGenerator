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

namespace MyUserControl
{
    /// <summary>
    /// UserControlTestWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControlTestWindow : Window
    {
        public UserControlTestWindow()
        {
            InitializeComponent();
            Console.WriteLine(SystemParameters.WorkArea.Width);
            Console.WriteLine(SystemParameters.WorkArea.Height);
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
        }
    }
}
