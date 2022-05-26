using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP7
{
    public partial class RemovingConfirmation : Form
    {
            public RemovingConfirmation()
            {
                InitializeComponent();
            }

            public bool button;

        private void button1_Click_1(object sender, EventArgs e)
        {
            button = true;
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button = false;
            Close();
        }
    }
    
}
