﻿using System;
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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            label1.Text = "Курсовая работа по дисциплине \r\n визуальное программирование\r\nпо теме Иерархия летаельных аппаратов \r\nвыполнил студент группы ИТ-32\r\nНасыпалов Н.А.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
