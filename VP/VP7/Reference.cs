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
    public partial class Reference : Form
    {
        public Reference()
        {
            InitializeComponent();
            label1.Text = "Комбинации клавиш:\r\n" +
                " Ctrl+S  - Сохранить данные\r\n Ctrl+L - Загрузить данные\r\n Ctrl+O - О программе\r\n F1 - Справка\r\n" +
                " Ctrl+A - добавить новый элемент\r\n" +
                " Delete - удалить выбранный элемент";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
