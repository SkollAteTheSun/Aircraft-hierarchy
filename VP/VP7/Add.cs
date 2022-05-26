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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
            ToolTip1.SetToolTip(label12, ToolTip.GetToolTip);
            //radioButton2.Checked = true;

        }
        public Add(Aircraft f)
        {
            InitializeComponent();
            ToolTip1.SetToolTip(label12, ToolTip.GetToolTip);

            if (f is Airship)
            {
                Airship airship = (Airship)f;
                textBox1.Text = airship.Name;
                textBox2.Text = airship.Producer;
                textBox3.Text = airship.Function;
                textBox4.Text = airship.MaxTime;
                textBox5.Text = airship.ShellType;
                textBox6.Text = airship.Form;
                numericUpDown1.Value = airship.ShellVolume;
                radioButton1.Checked = true;
            }
            else
            {
                if (f is Balloon)
                {
                    Balloon balloon = (Balloon)f;
                    textBox1.Text = balloon.Name;
                    textBox2.Text = balloon.Producer;
                    textBox3.Text = balloon.Function;
                    textBox4.Text = balloon.MaxTime;
                    textBox5.Text = balloon.ShellType;
                    textBox7.Text = balloon.Color;
                    numericUpDown1.Value = balloon.ShellVolume;
                    radioButton2.Checked = true;
                }
                else
                {
                    if (f is Helicopter)
                    {
                        Helicopter helicopter = (Helicopter)f;
                        textBox1.Text = helicopter.Name;
                        textBox2.Text = helicopter.Producer;
                        textBox3.Text = helicopter.Function;
                        textBox4.Text = helicopter.MaxTime;
                        numericUpDown2.Value = helicopter.Crew;
                        numericUpDown3.Value = helicopter.СountBlades;
                        radioButton4.Checked = true;
                    }
                    else
                    {
                        if (f is Plane)
                        {
                            Plane plane = (Plane)f;
                            textBox1.Text = plane.Name;
                            textBox2.Text = plane.Producer;
                            textBox3.Text = plane.Function;
                            textBox4.Text = plane.MaxTime;
                            numericUpDown2.Value = plane.Crew;
                            numericUpDown4.Value = plane.Wingspan;
                            radioButton4.Checked = true;
                        }
                        else
                        {
                            if (f is Satellite)
                            {
                                Satellite satellite = (Satellite)f;
                                textBox1.Text = satellite.Name;
                                textBox2.Text = satellite.Producer;
                                textBox3.Text = satellite.Function;
                                textBox4.Text = satellite.MaxTime;
                                textBox8.Text = satellite.CirculationPeriod;
                                numericUpDown5.Value = satellite.TimeОrbit;
                                radioButton5.Checked = true;
                            }
                            else
                            {
                                if (f is Station)
                                {
                                    Station station = (Station)f;                          
                                    textBox1.Text = station.Name;
                                    textBox2.Text = station.Producer;
                                    textBox3.Text = station.Function;
                                    textBox4.Text = station.MaxTime;
                                    textBox8.Text = station.CirculationPeriod;
                                    numericUpDown5.Value = station.TimeОrbit;
                                    numericUpDown6.Value = station.DockingNodes;
                                    radioButton6.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool checkingName;

        public bool CheckingUniqueName(string search)
        {
            foreach (var v in Form1.mas)
            {
                if (v is Airship)
                {
                    Airship p = (Airship)v;
                    if (search == p.Name)
                    {
                        return false;
                    }
                }
                else
                {
                    if (v is Balloon)
                    {
                        Balloon p = (Balloon)v;
                        if (search == p.Name)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (v is Helicopter)
                        {
                            Helicopter p = (Helicopter)v;
                            if (search == p.Name)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (v is Plane)
                            {
                                Plane p = (Plane)v;
                                if (search == p.Name)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (v is Satellite)
                                {
                                    Satellite p = (Satellite)v;
                                    if (search == p.Name)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (v is Station)
                                    {
                                        Station p = (Station)v;
                                        if (search == p.Name)
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkingName = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ошибка. Заполните наименование");
                    checkingName = true;
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Ошибка. Заполните производителя");
                    }
                    else
                    {
                        if (textBox3.Text == "")
                        {
                            MessageBox.Show("Ошибка. Заполните назначение");
                        }
                        else
                        {
                            if (textBox4.Text == "")
                            {
                                MessageBox.Show("Ошибка. Заполните максимальную длительность полета");
                            }
                            else
                            {
                                if (CheckingUniqueName(textBox1.Text))
                                {
                                    checkingName = false;
                                    Close();
                                }
                                else
                                {
                                    checkingName = true;
                                    MessageBox.Show("Ошибка. Имя не уникальное");
                                }
                            }
                        }
                    }
                }
            
        }
    

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;

            label5.Enabled = true;
            label6.Enabled = true;
            label10.Enabled = false;
            label11.Enabled = false;
            label12.Enabled = true;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            label16.Enabled = false;
            label17.Enabled = false;

            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;

            label5.Enabled = true;
            label6.Enabled = false;
            label10.Enabled = true;
            label11.Enabled = false;
            label12.Enabled = true;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            label16.Enabled = false;
            label17.Enabled = false;

            textBox5.Enabled = true;
            textBox6.Enabled = false;
            textBox7.Enabled = true;
            textBox8.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;

            label5.Enabled = false;
            label6.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = false;
            label12.Enabled = false;
            label13.Enabled = true;
            label14.Enabled = true;
            label15.Enabled = false;
            label16.Enabled = false;
            label17.Enabled = false;

            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;

            label5.Enabled = false;
            label6.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = false;
            label12.Enabled = false;
            label13.Enabled = true;
            label14.Enabled = false;
            label15.Enabled = true;
            label16.Enabled = false;
            label17.Enabled = false;

            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = false;

            label5.Enabled = false;
            label6.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = true;
            label12.Enabled = false;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            label16.Enabled = true;
            label17.Enabled = false;

            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = true;
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = true;

            label5.Enabled = false;
            label6.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = true;
            label12.Enabled = false;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            label16.Enabled = true;
            label17.Enabled = true;

            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = true;
        }
    }
}
