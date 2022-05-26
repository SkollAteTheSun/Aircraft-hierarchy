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
    public partial class UserControl2 : UserControl
    {
        public static Add fomr;

        public UserControl2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите текст чтобы модифицировать подсказку", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                ToolTip.GetToolTip = textBox1.Text;
             
            }

          
        }

    }
}
