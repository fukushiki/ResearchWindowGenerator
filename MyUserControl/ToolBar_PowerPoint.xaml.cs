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

namespace MyUserControl
{
    /// <summary>
    /// ToolBar_PowerPoint.xaml の相互作用ロジック
    /// </summary>
    public partial class ToolBar_PowerPoint : UserControl
    {
        public ToolBar_PowerPoint()
        {
            //InitializeComponent();
            Button A = new Button();
            this.AddChild(A);
        }
    }
}
