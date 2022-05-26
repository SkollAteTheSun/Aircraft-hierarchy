using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
//using System.Threading;

namespace VP7
{
    public partial class Form1 : Form
    {
        private static TreeNode root = new TreeNode("Летательные аппараты");
        public static ArrayList mas = new ArrayList();
        ToolStripLabel  dateLabel, timeLabel;

        public Form1()
        {
            InitializeComponent();
            statusStrip1Initizlization();
            AllowDrop = true;
            pictureBox1.AllowDrop = true;
            this.KeyPreview = true;
            TreeRoots();
            treeView1.Nodes.Add(root);
            Output();
            ToolTip.GetToolTip = "м³ (метр в кубе) -единицы измерения в СИ размера пространства, занимаемого твёрдым, сыпучим или жидким.";
        }

        //private void userControl22_Load(object sender, EventArgs e)
        //{
        //    UserControl2.form = this;
        //}

        private void Clear()
        {
            root.Nodes[0].Nodes[0].Nodes.Clear();
            root.Nodes[0].Nodes[1].Nodes.Clear();
            root.Nodes[1].Nodes[0].Nodes.Clear();
            root.Nodes[1].Nodes[1].Nodes.Clear();
            root.Nodes[2].Nodes[0].Nodes.Clear();
            root.Nodes[2].Nodes[1].Nodes.Clear();
        }

        private void Output()
        {
            Clear();
            foreach (var f in mas)
            {
                if (f is Airship) //head
                {
                    Airship temp = (Airship)f;
                    root.Nodes[0].Nodes[0].Nodes.Add(temp.Name);
                }
                else
                {
                    if (f is Balloon) // joint
                    {
                        Balloon temp = (Balloon)f;
                        root.Nodes[0].Nodes[1].Nodes.Add(temp.Name);
                    }
                    else
                    {
                        if (f is Helicopter) //sedative
                        {
                            Helicopter temp = (Helicopter)f;
                            root.Nodes[1].Nodes[0].Nodes.Add(temp.Name);

                        }

                        else
                        {
                            if (f is Plane) 
                            {
                                Plane temp = (Plane)f;
                                root.Nodes[1].Nodes[1].Nodes.Add(temp.Name);
                            }
                            else
                            {
                                if (f is Satellite) 
                                {
                                    Satellite temp = (Satellite)f;
                                    root.Nodes[2].Nodes[0].Nodes.Add(temp.Name);
                                }
                                else
                                {
                                    if (f is Station) 
                                    {
                                        Station temp = (Station)f;
                                        root.Nodes[2].Nodes[1].Nodes.Add(temp.Name);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            root.ExpandAll();
        }

        private void TreeRoots()
        {
            root.Nodes.Add(new TreeNode("Аэростатические"));
            root.Nodes.Add(new TreeNode("Аэродинамические"));
            root.Nodes.Add(new TreeNode("Инерционные"));
            root.Nodes[0].Nodes.Add(new TreeNode("Дирижабли"));
            root.Nodes[0].Nodes.Add(new TreeNode("Воздушные шары"));
            root.Nodes[1].Nodes.Add(new TreeNode("Вертолеты"));
            root.Nodes[1].Nodes.Add(new TreeNode("Самолеты"));
            root.Nodes[2].Nodes.Add(new TreeNode("Спутники"));
            root.Nodes[2].Nodes.Add(new TreeNode("Станции"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add newRoot = new Add();
            newRoot.ShowDialog();
            if (!newRoot.checkingName)
            {
                if (newRoot.radioButton1.Checked)
                {
                    Airship airship = new Airship(newRoot.textBox1.Text, newRoot.textBox2.Text, newRoot.textBox3.Text, newRoot.textBox4.Text, newRoot.textBox5.Text, newRoot.numericUpDown1.Value, newRoot.textBox6.Text);
                    mas.Add(airship);
                }
                else
                {
                    if (newRoot.radioButton2.Checked)
                    {
                        Balloon balloon = new Balloon(newRoot.textBox1.Text, newRoot.textBox2.Text, newRoot.textBox3.Text, newRoot.textBox4.Text, newRoot.textBox5.Text, newRoot.numericUpDown1.Value, newRoot.textBox7.Text);
                        mas.Add(balloon);
                    }
                    else
                    {
                        if (newRoot.radioButton3.Checked)
                        {
                            Helicopter helicopter = new Helicopter(newRoot.textBox1.Text, newRoot.textBox2.Text, newRoot.textBox3.Text, newRoot.textBox4.Text, newRoot.numericUpDown2.Value, newRoot.numericUpDown3.Value);
                            mas.Add(helicopter);
                        }
                        else
                        {
                            if (newRoot.radioButton4.Checked)
                            {
                                Plane plane = new Plane(newRoot.textBox1.Text, newRoot.textBox2.Text, newRoot.textBox3.Text, newRoot.textBox4.Text, newRoot.numericUpDown2.Value, newRoot.numericUpDown4.Value); ;
                                mas.Add(plane);
                            }
                            else
                            {
                                if (newRoot.radioButton5.Checked)
                                {
                                    Satellite satellite = new Satellite(newRoot.textBox1.Text, newRoot.textBox2.Text, newRoot.textBox3.Text, newRoot.textBox4.Text, newRoot.textBox8.Text, newRoot.numericUpDown5.Value);
                                    mas.Add(satellite);
                                }
                                else
                                {
                                    if (newRoot.radioButton6.Checked)
                                    {
                                        Station station = new Station(newRoot.textBox1.Text, newRoot.textBox2.Text, newRoot.textBox3.Text, newRoot.textBox4.Text, newRoot.textBox8.Text, newRoot.numericUpDown5.Value, newRoot.numericUpDown6.Value);
                                        mas.Add(station);
                                    }

                                }
                            }
                        }
                    }
                }

                Output();
            }    
            //}
        }




        private void ClearInformation()  ////////? private //////////////////////////////////
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
                numericUpDown4.Value = 0;
                numericUpDown5.Value = 0;
                numericUpDown6.Value = 0;
                groupBox1.Enabled = false;
                
            }

        private void FindInformation()
        {
            ClearInformation();
            groupBox1.Enabled = true;
            foreach (var f in mas)
            {
                if (f is Airship)
                {
                    Airship airship = (Airship)f;
                    if (airship.Name == treeView1.SelectedNode.Text)
                    {
                        textBox1.Text = airship.Name;
                        textBox1.ReadOnly = true;
                        textBox2.Text = airship.Producer;
                        textBox2.ReadOnly = true;
                        textBox3.Text = airship.Function;
                        textBox3.ReadOnly = true;
                        textBox4.Text = airship.MaxTime;
                        textBox4.ReadOnly = true;
                        textBox5.Text = airship.ShellType;
                        textBox5.ReadOnly = true;
                        textBox6.Text = airship.Form;
                        textBox6.ReadOnly = true;
                        numericUpDown1.Value = airship.ShellVolume;
                        numericUpDown1.ReadOnly = true;

                        numericUpDown1.BackColor = SystemColors.Window;
                        textBox1.BackColor = SystemColors.Window;
                        textBox2.BackColor = SystemColors.Window;
                        textBox3.BackColor = SystemColors.Window;
                        textBox4.BackColor = SystemColors.Window;
                        textBox5.BackColor = SystemColors.Window;
                        textBox6.BackColor = SystemColors.Window;

                        numericUpDown1.Enabled = true;
                        numericUpDown2.Enabled = false;
                        numericUpDown3.Enabled = false;
                        numericUpDown4.Enabled = false;
                        numericUpDown5.Enabled = false;
                        numericUpDown6.Enabled = false;
                        label5.Enabled = true;
                        label6.Enabled = true;
                        label7.Enabled = false;
                        label8.Enabled = false;
                        label9.Enabled = true;
                        label10.Enabled = false;
                        label11.Enabled = false;
                        label12.Enabled = false;
                        label13.Enabled = false;
                        label14.Enabled = false;
                        textBox5.Enabled = true;
                        textBox6.Enabled = true;
                        textBox7.Enabled = false;
                        textBox8.Enabled = false;

                        return;
                    }
                }
                else
                {
                    if (f is Balloon)
                    {
                        Balloon balloon = (Balloon)f;
                        if (balloon.Name == treeView1.SelectedNode.Text)
                        {
                            textBox1.Text = balloon.Name;
                            textBox1.ReadOnly = true;
                            textBox2.Text = balloon.Producer;
                            textBox2.ReadOnly = true;
                            textBox3.Text = balloon.Function;
                            textBox3.ReadOnly = true;
                            textBox4.Text = balloon.MaxTime;
                            textBox4.ReadOnly = true;
                            textBox5.Text = balloon.ShellType;
                            textBox5.ReadOnly = true;
                            textBox7.Text = balloon.Color;
                            textBox7.ReadOnly = true;
                            numericUpDown1.Value = balloon.ShellVolume;
                            numericUpDown1.ReadOnly = true;

                            textBox1.BackColor = SystemColors.Window;
                            textBox2.BackColor = SystemColors.Window;
                            textBox3.BackColor = SystemColors.Window;
                            textBox4.BackColor = SystemColors.Window;
                            textBox5.BackColor = SystemColors.Window;
                            textBox7.BackColor = SystemColors.Window;
                            numericUpDown1.BackColor = SystemColors.Window;

                            numericUpDown1.Enabled = true;
                            numericUpDown2.Enabled = false;
                            numericUpDown3.Enabled = false;
                            numericUpDown4.Enabled = false;
                            numericUpDown5.Enabled = false;
                            numericUpDown6.Enabled = false;
                            label5.Enabled = true;
                            label6.Enabled = false;
                            label7.Enabled = true;
                            label8.Enabled = false;
                            label9.Enabled = true;
                            label10.Enabled = false;
                            label11.Enabled = false;
                            label12.Enabled = false;
                            label13.Enabled = false;
                            label14.Enabled = false;
                            textBox5.Enabled = true;
                            textBox7.Enabled = true;
                            textBox6.Enabled = false;
                            textBox8.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        if (f is Helicopter)
                        {
                            Helicopter helicopter = (Helicopter)f;
                            if (helicopter.Name == treeView1.SelectedNode.Text)
                            {
                                textBox1.Text = helicopter.Name;
                                textBox1.ReadOnly = true;
                                textBox2.Text = helicopter.Producer;
                                textBox2.ReadOnly = true;
                                textBox3.Text = helicopter.Function;
                                textBox3.ReadOnly = true;
                                textBox4.Text = helicopter.MaxTime;
                                textBox4.ReadOnly = true;
                                numericUpDown2.Value = helicopter.Crew;
                                numericUpDown2.ReadOnly = true;
                                numericUpDown3.Value = helicopter.СountBlades;
                                numericUpDown3.ReadOnly = true;

                                textBox1.BackColor = SystemColors.Window;
                                textBox2.BackColor = SystemColors.Window;
                                textBox3.BackColor = SystemColors.Window;
                                textBox4.BackColor = SystemColors.Window;
                                numericUpDown2.BackColor = SystemColors.Window;
                                numericUpDown3.BackColor = SystemColors.Window;

                                numericUpDown1.Enabled = false;
                                numericUpDown2.Enabled = true;
                                numericUpDown3.Enabled = true;
                                numericUpDown4.Enabled = false;
                                numericUpDown5.Enabled = false;
                                numericUpDown6.Enabled = false;
                                label5.Enabled = false;
                                label6.Enabled = false;
                                label7.Enabled = false;
                                label8.Enabled = false;
                                label9.Enabled = false;
                                label10.Enabled = true;
                                label11.Enabled = true;
                                label12.Enabled = false;
                                label13.Enabled = false;
                                label14.Enabled = false;
                                textBox5.Enabled = false;
                                textBox6.Enabled = false;
                                textBox7.Enabled = false;
                                textBox8.Enabled = false;

                                return;
                            }
                        }
                        else
                        {
                            if (f is Plane)
                            {
                                Plane plane = (Plane)f;
                                if (plane.Name == treeView1.SelectedNode.Text)
                                {
                                    textBox1.Text = plane.Name;
                                    textBox1.ReadOnly = true;
                                    textBox2.Text = plane.Producer;
                                    textBox2.ReadOnly = true;
                                    textBox3.Text = plane.Function;
                                    textBox3.ReadOnly = true;
                                    textBox4.Text = plane.MaxTime;
                                    textBox4.ReadOnly = true;
                                    numericUpDown2.Value = plane.Crew;
                                    numericUpDown2.ReadOnly = true;
                                    numericUpDown4.Value = plane.Wingspan;
                                    numericUpDown4.ReadOnly = true;

                                    textBox1.BackColor = SystemColors.Window;
                                    textBox2.BackColor = SystemColors.Window;
                                    textBox3.BackColor = SystemColors.Window;
                                    textBox4.BackColor = SystemColors.Window;
                                    numericUpDown2.BackColor = SystemColors.Window;
                                    numericUpDown4.BackColor = SystemColors.Window;

                                    numericUpDown1.Enabled = false;
                                    numericUpDown2.Enabled = true;
                                    numericUpDown3.Enabled = false;
                                    numericUpDown4.Enabled = true;
                                    numericUpDown5.Enabled = false;
                                    numericUpDown6.Enabled = false;
                                    label5.Enabled = false;
                                    label6.Enabled = false;
                                    label7.Enabled = false;
                                    label8.Enabled = false;
                                    label9.Enabled = false;
                                    label10.Enabled = true;
                                    label11.Enabled = false;
                                    label12.Enabled = true;
                                    label13.Enabled = false;
                                    label14.Enabled = false;
                                    textBox5.Enabled = false;
                                    textBox6.Enabled = false;
                                    textBox7.Enabled = false;
                                    textBox8.Enabled = false;

                                    return;
                                }
                            }
                            else
                            {
                                if (f is Satellite)
                                {
                                    Satellite satellite = (Satellite)f;
                                    if (satellite.Name == treeView1.SelectedNode.Text)
                                    {
                                        textBox1.Text = satellite.Name;
                                        textBox1.ReadOnly = true;
                                        textBox2.Text = satellite.Producer;
                                        textBox2.ReadOnly = true;
                                        textBox3.Text = satellite.Function;
                                        textBox3.ReadOnly = true;
                                        textBox4.Text = satellite.MaxTime;
                                        textBox4.ReadOnly = true;
                                        textBox8.Text = satellite.CirculationPeriod;
                                        textBox8.ReadOnly = true;
                                        numericUpDown5.Value = satellite.TimeОrbit;
                                        numericUpDown5.ReadOnly = true;


                                        textBox1.BackColor = SystemColors.Window;
                                        textBox2.BackColor = SystemColors.Window;
                                        textBox3.BackColor = SystemColors.Window;
                                        textBox4.BackColor = SystemColors.Window;
                                        textBox8.BackColor = SystemColors.Window;
                                        numericUpDown5.BackColor = SystemColors.Window;

                                        numericUpDown1.Enabled = false;
                                        numericUpDown2.Enabled = false;
                                        numericUpDown3.Enabled = false;
                                        numericUpDown4.Enabled = false;
                                        numericUpDown5.Enabled = true;
                                        numericUpDown6.Enabled = false;
                                        label5.Enabled = false;
                                        label6.Enabled = false;
                                        label7.Enabled = false;
                                        label8.Enabled = true;
                                        label9.Enabled = false;
                                        label10.Enabled = false;
                                        label11.Enabled = false;
                                        label12.Enabled = false;
                                        label13.Enabled = true;
                                        label14.Enabled = false;
                                        textBox5.Enabled = false;
                                        textBox6.Enabled = false;
                                        textBox7.Enabled = false;
                                        textBox8.Enabled = true;

                                        return;
                                    }
                                }
                                else
                                {
                                    if (f is Station)
                                    {
                                        Station station = (Station)f;
                                        if (station.Name == treeView1.SelectedNode.Text)
                                        {
                                            textBox1.Text = station.Name;
                                            textBox1.ReadOnly = true;
                                            textBox2.Text = station.Producer;
                                            textBox2.ReadOnly = true;
                                            textBox3.Text = station.Function;
                                            textBox3.ReadOnly = true;
                                            textBox4.Text = station.MaxTime;
                                            textBox4.ReadOnly = true;
                                            textBox8.Text = station.CirculationPeriod;
                                            textBox8.ReadOnly = true;
                                            numericUpDown5.Value = station.TimeОrbit;
                                            numericUpDown5.ReadOnly = true;
                                            numericUpDown6.Value = station.DockingNodes;
                                            numericUpDown6.ReadOnly = true;


                                            textBox1.BackColor = SystemColors.Window;
                                            textBox2.BackColor = SystemColors.Window;
                                            textBox3.BackColor = SystemColors.Window;
                                            textBox4.BackColor = SystemColors.Window;
                                            textBox8.BackColor = SystemColors.Window;
                                            numericUpDown5.BackColor = SystemColors.Window;
                                            numericUpDown6.BackColor = SystemColors.Window;

                                            numericUpDown1.Enabled = false;
                                            numericUpDown2.Enabled = false;
                                            numericUpDown3.Enabled = false;
                                            numericUpDown4.Enabled = false;
                                            numericUpDown5.Enabled = true;
                                            numericUpDown6.Enabled = true;
                                            label5.Enabled = false;
                                            label6.Enabled = false;
                                            label7.Enabled = false;
                                            label8.Enabled = true;
                                            label9.Enabled = false;
                                            label10.Enabled = false;
                                            label11.Enabled = false;
                                            label12.Enabled = false;
                                            label13.Enabled = true;
                                            label14.Enabled = true;
                                            textBox5.Enabled = false;
                                            textBox6.Enabled = false;
                                            textBox7.Enabled = false;
                                            textBox8.Enabled = true;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ClearInformation();
        }

        private void EditElement()
        {
            if ((treeView1.SelectedNode.Text == "Летательные аппараты") || (treeView1.SelectedNode.Text == "Аэростатические") || (treeView1.SelectedNode.Text == "Аэродинамические") || (treeView1.SelectedNode.Text == "Инерционные") || (treeView1.SelectedNode.Text == "Дирижабли") || (treeView1.SelectedNode.Text == "Воздышные шары") || (treeView1.SelectedNode.Text == "Вертолеты") || (treeView1.SelectedNode.Text == "Самолеты") || (treeView1.SelectedNode.Text == "Спутники") || (treeView1.SelectedNode.Text == "Станции"))
            {
                MessageBox.Show("Изменять категории нельзя!");
            }
            else
            {
                foreach (var v in mas)
                {
                    if (v is Airship)
                    {
                        Airship airship = (Airship)v;
                        if (airship.Name == treeView1.SelectedNode.Text)
                        {
                            Add newRoot = new Add(airship);
                            newRoot.ShowDialog();
                            Output();
                            break;
                        }
                    }
                    else
                    {
                        if (v is Balloon)
                        {
                            Balloon balloon = (Balloon)v;
                            if (balloon.Name == treeView1.SelectedNode.Text)
                            {
                                Add newRoot = new Add(balloon);
                                newRoot.ShowDialog();
                                Output();
                            }
                        }
                        else

                            if (v is Helicopter)
                        {
                            Helicopter helicopter = (Helicopter)v;
                            if (helicopter.Name == treeView1.SelectedNode.Text)
                            {
                                Add newRoot = new Add(helicopter);
                                newRoot.ShowDialog();
                                Output();
                            }
                        }
                        else
                        {
                            if (v is Plane)
                            {
                                Plane plane = (Plane)v;
                                if (plane.Name == treeView1.SelectedNode.Text)
                                {
                                    Add newRoot = new Add(plane);
                                    newRoot.ShowDialog();
                                    Output();
                                }
                            }
                            else

                                if (v is Satellite)
                            {
                                Satellite satellite = (Satellite)v;
                                if (satellite.Name == treeView1.SelectedNode.Text)
                                {
                                    Add newRoot = new Add(satellite);
                                    newRoot.ShowDialog();
                                    Output();
                                }
                            }

                            else
                            {
                                if (v is Station)
                                {
                                    Station station = (Station)v;
                                    if (station.Name == treeView1.SelectedNode.Text)
                                    {
                                        Add newRoot = new Add(station);
                                        newRoot.ShowDialog();
                                        Output();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            Removing();
        }

        private void Removing()
        {
            RemovingConfirmation form = new RemovingConfirmation();
            form.ShowDialog();
            if (form.button)
            {
                foreach (var v in mas)
                {
                    if (v is Airship)
                    {
                        Airship airship = (Airship)v;
                        if (airship.Name == treeView1.SelectedNode.Text)
                        {
                            mas.Remove(v);
                            break;
                        }
                    }
                    else
                    {
                        if (v is Balloon)
                        {
                            Balloon balloon = (Balloon)v;
                            if (balloon.Name == treeView1.SelectedNode.Text)
                            {
                                mas.Remove(v);
                                break;
                            }
                        }
                        else

                            if (v is Helicopter)
                         {
                            Helicopter helicopter = (Helicopter)v;
                            if (helicopter.Name == treeView1.SelectedNode.Text)
                            {
                                mas.Remove(v);
                                break;
                            }
                         }
                        else
                        {
                            if (v is Plane)
                            {
                                Plane plane = (Plane)v;
                                if (plane.Name == treeView1.SelectedNode.Text)
                                {
                                    mas.Remove(v);
                                    break;
                                }
                            }
                            else
                            
                                if (v is Satellite)
                                {
                                    Satellite satellite = (Satellite)v;
                                    if (satellite.Name == treeView1.SelectedNode.Text)
                                    {
                                        mas.Remove(v);
                                        break;
                                    }
                                }

                                else
                                {
                                    if (v is Station)
                                    {
                                        Station station = (Station)v;
                                        if (station.Name == treeView1.SelectedNode.Text)
                                        {
                                            mas.Remove(v);
                                            break;
                                        }
                                    }
                                }

                            
                        }
                    }
                }
            }
            if (form.button)
            {
                MessageBox.Show("Объект успешно удалён");
                Output();
                ClearInformation();
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if ((treeView1.SelectedNode.Text == "Летательные аппараты") || (treeView1.SelectedNode.Text == "Аэростатические") || (treeView1.SelectedNode.Text == "Аэродинамические") || (treeView1.SelectedNode.Text == "Инерционные") || (treeView1.SelectedNode.Text == "Дирижабли") || (treeView1.SelectedNode.Text == "Воздышные шары") || (treeView1.SelectedNode.Text == "Вертолеты") || (treeView1.SelectedNode.Text == "Самолеты") || (treeView1.SelectedNode.Text == "Спутники") || (treeView1.SelectedNode.Text == "Станции"))
            {
                MessageBox.Show("Удалять категории нельзя!");
            }
            else
            {
                treeView1.DoDragDrop(treeView1.SelectedNode, DragDropEffects.Move);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Type[] Types = new Type[10];
            Types[0] = typeof(Aerostatic);
            Types[1] = typeof(Airship);
            Types[2] = typeof(Balloon);
            Types[3] = typeof(Aerodynamic);
            Types[4] = typeof(Helicopter);
            Types[5] = typeof(Plane);
            Types[6] = typeof(Inertial);
            Types[7] = typeof(Satellite);
            Types[8] = typeof(Station);
            Types[9] = typeof(Aircraft);
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), Types);
            SaveFileDialog SPF = new SaveFileDialog();
            SPF.Filter = "Файлы|*.xml";
            SPF.AddExtension = true;
            SPF.DefaultExt = "xml";
            SPF.OverwritePrompt = true;
            if (SPF.ShowDialog() == DialogResult.OK)
            {
                string checking = SPF.FileName;
                int len = checking.Length;
                if (len > 4)
                {
                    if ((checking[len - 1] == 'l') && (checking[len - 2] == 'm') && (checking[len - 3] == 'x'))
                    {
                        using (FileStream file = new FileStream(SPF.FileName, FileMode.Create))
                        {
                            serializer.Serialize(file, mas);
                        }
                        MessageBox.Show("Данные успешно сохранены");
                    }
                    else
                    {
                        MessageBox.Show("Неверное расширение файла");
                    }
                }
                else
                {
                    MessageBox.Show("Неверное расширение файла");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Type[] Types = new Type[10];
            Types[0] = typeof(Aerostatic);
            Types[1] = typeof(Airship);
            Types[2] = typeof(Balloon);
            Types[3] = typeof(Aerodynamic);
            Types[4] = typeof(Helicopter);
            Types[5] = typeof(Plane);
            Types[6] = typeof(Inertial);
            Types[7] = typeof(Satellite);
            Types[8] = typeof(Station);
            Types[9] = typeof(Aircraft);
            XmlSerializer deserializer = new XmlSerializer(typeof(ArrayList), Types);
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы|*.xml";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                using (FileStream file = new FileStream(OPF.FileName, FileMode.OpenOrCreate))
                {
                    mas = (ArrayList)deserializer.Deserialize(file);
                }
                MessageBox.Show("Данные успешно загружены");
                Output();
            }
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

            if ((treeView1.SelectedNode.Text == "Летательные аппараты") || (treeView1.SelectedNode.Text == "Аэростатические") || (treeView1.SelectedNode.Text == "Аэродинамические") || (treeView1.SelectedNode.Text == "Инерционные") || (treeView1.SelectedNode.Text == "Дирижабли") || (treeView1.SelectedNode.Text == "Воздышные шары") || (treeView1.SelectedNode.Text == "Вертолеты") || (treeView1.SelectedNode.Text == "Самолеты") || (treeView1.SelectedNode.Text == "Спутники") || (treeView1.SelectedNode.Text == "Станции"))
            {
                ClearInformation();
            }
            else
            {
                FindInformation();
            }

        }

        private void развернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void свернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void создатьОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            reference.ShowDialog();
        }

        private void SortAircraft()
        {
            List<Airship> sortAirship = new List<Airship>();
            List<Balloon> sortBalloon = new List<Balloon>();
            List<Helicopter> sortHelicopter = new List<Helicopter>();
            List<Plane> sortPlane = new List<Plane>();
            List<Satellite> sortSatellite = new List<Satellite>();
            List<Station> sortStation= new List<Station>();
            foreach (var v in mas)
            {
                if (v is Airship)
                {
                    sortAirship.Add((Airship)v);
                }
                else
                {
                    if (v is Balloon)
                    {
                        sortBalloon.Add((Balloon)v);
                    }
                    else
                    {
                        if (v is Helicopter)
                        {
                            sortHelicopter.Add((Helicopter)v);
                        }
                        else
                        {
                            if (v is Plane)
                            {
                                sortPlane.Add((Plane)v);
                            }
                            else
                            {
                                if (v is Satellite)
                                {
                                    sortSatellite.Add((Satellite)v);
                                }
                                else
                                {
                                    if (v is Plane)
                                    {
                                        sortPlane.Add((Plane)v);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sortAirship.Sort();
            sortBalloon.Sort();
            sortHelicopter.Sort();
            sortPlane.Sort();
            sortSatellite.Sort();
            sortStation.Sort();
            mas.Clear();
            foreach (var v in sortAirship)
                mas.Add(v);
            foreach (var v in sortBalloon)
                mas.Add(v);
            foreach (var v in sortHelicopter)
                mas.Add(v);
            foreach (var v in sortPlane)
                mas.Add(v);
            foreach (var v in sortSatellite)
                mas.Add(v);
            foreach (var v in sortStation)
                mas.Add(v);
            Output();
        }

        private void поВозрастаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortAircraft();
            Output();
        }

        private void поУбываниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortAircraft();
            mas.Reverse();
            Output();
        }

        
        private void поискToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
            string name = search.name;
            foreach (var v in mas)
            {
                if (v is Airship)
                {
                    Airship airship = (Airship)v;
                    if (airship.Name == name)
                    {
                        foreach (TreeNode item in treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes)
                        {
                            if (item.Text == name)
                            {
                                treeView1.SelectedNode = item;

                            }
                        }
                    }
                }
                else
                {
                    if (v is Balloon)
                    {
                        Balloon balloon = (Balloon)v;
                        if (balloon.Name == name)
                        {
                            foreach (TreeNode item in treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes)
                            {
                                if (item.Text == name)
                                    treeView1.SelectedNode = item;
                            }
                        }
                    }
                    else
                    {
                        if (v is Helicopter)
                        {
                            Helicopter helicopter = (Helicopter)v;
                            if (helicopter.Name == name)
                            {
                                foreach (TreeNode item in treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes)
                                {
                                    if (item.Text == name)
                                        treeView1.SelectedNode = item;
                                }
                            }
                        }

                        else
                        {
                            if (v is Plane)
                            {
                                Plane plane = (Plane)v;
                                if (plane.Name == name)
                                {
                                    foreach (TreeNode item in treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes)
                                    {
                                        if (item.Text == name)
                                            treeView1.SelectedNode = item;
                                    }
                                }
                            }
                            else
                            {
                                if (v is Satellite)
                                {
                                    Satellite satellite = (Satellite)v;
                                    if (satellite.Name == name)
                                    {
                                        foreach (TreeNode item in treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes)
                                        {
                                            if (item.Text == name)
                                                treeView1.SelectedNode = item;
                                        }
                                    }
                                }
                                else
                                {
                                    if (v is Station)
                                    {
                                        Station station = (Station)v;
                                        if (station.Name == name)
                                        {
                                            foreach (TreeNode item in treeView1.Nodes[0].Nodes[2].Nodes[1].Nodes)
                                            {
                                                if (item.Text == name)
                                                    treeView1.SelectedNode = item;
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            ClearInformation();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                button2.PerformClick();
            if (e.Control && e.KeyCode == Keys.L)
                button3.PerformClick();
            if (e.Control && e.KeyCode == Keys.O)
            {
                About about = new About();
                about.ShowDialog();
            }
            if (e.KeyCode == Keys.F1)
            {
                Reference reference = new Reference();
                reference.ShowDialog();
            }
            if (e.Control && e.KeyCode == Keys.A)
                button1.PerformClick();
            if (e.KeyCode == Keys.Delete)
                Removing();
            }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Removing();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            EditElement();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                About about = new About();
                about.ShowDialog();
            }
        }

        private void statusStrip1Initizlization()
        {
            ToolStripLabel infoLabel = new ToolStripLabel();
            infoLabel.Text = "Дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            Timer timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
    }
    }


