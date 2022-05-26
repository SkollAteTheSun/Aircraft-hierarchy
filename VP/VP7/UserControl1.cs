using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP7
{
    public partial class UserControl1 : UserControl
    {


    public UserControl1()
        {
            InitializeComponent();
            label2.Text = "0";
            label3.Text = "X: \nY: ";
            label4.Text = "Количество символов: ";
            this.MouseMove += UserControl1_MouseMove;

        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            string text = "";
            label1.Text = e.X.ToString() + "\n" + e.Y.ToString();
            text = label1.Text;
            label2.Text = Convert.ToString(text.Length - 1);   
        }


    }
}
