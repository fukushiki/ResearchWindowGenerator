using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ResearchWindowGenerator
{
    /// <summary>
    /// ResarchWindowTest.xaml の相互作用ロジック
    /// </summary>
    public partial class ResarchWindowTest : Window
    {
        public ResarchWindowTest()
        {
            InitializeComponent();
            // タイトルバーとの境界線を表示しない
            //this.WindowStyle = WindowStyle.None;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //最大化表示
            this.WindowState = WindowState.Maximized;

            //TODO : マウスカーソルをウィンドウ外に出ないように固定する
            InitializeCursor();
            
        }

        public void InitializeCursor() {
            Console.WriteLine(this.Height +":"+ this.Width);
            System.Windows.Forms.Cursor.Clip = new System.Drawing.Rectangle(0,0,(int)this.Width,(int)this.Height);
        }
    }
}
