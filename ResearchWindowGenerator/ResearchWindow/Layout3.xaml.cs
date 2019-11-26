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
    /// Layout3.xaml の相互作用ロジック
    /// </summary>
    public partial class Layout3 : Window
    {
        static double WindowWidth;
        static double WindowHeight;
        public Layout3()
        {
            InitializeComponent();
            /*Windowのサイズ指定*/
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.WindowState = WindowState.Maximized;

            WindowWidth = this.Width;
            WindowHeight = this.Height;
        }
    }
}
