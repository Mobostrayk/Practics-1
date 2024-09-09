using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practics_1
{
    public partial class Form1 : Form
    {
        public Logic logic = new Logic();
        public bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listView1.Columns.Add("ФИО студента", 200);
            listView1.Columns.Add("Специальность", 120);
            listView1.Columns.Add("Группа", 120);

            //String[] aa = { "Саня", "Комбез", "КИ23-02" };
            //ListViewItem seconditem = new ListViewItem(aa);
            //ListViewItem firstitem = new ListViewItem("Максим");
            //firstitem.SubItems.Add("ИСИТ");
            //firstitem.SubItems.Add("КИ23-12Б");
            //listView1.Items.Add(firstitem);
            //listView1.Items.Add(seconditem);

            //listView1.Items.Add(Logic.)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<String[]> students = logic.GiveStudents();
            foreach (String[] student in students)
            {
                ListViewItem studentitem = new ListViewItem(student);
                listView1.Items.Add(studentitem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
            new Form2(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logic.DeleteStudent(listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text);   
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                flag = true;
                Form2 form2 = new Form2(this);
                form2.textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                form2.textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                form2.textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
                form2.Show();

            }

        }
        private void CreateChart(Dictionary<string, int> notsorted)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series.Clear();
            chart1.Series.Add("Распределение студентов по специальностям");
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -80;

            // Сортируем
            var sortedWords = notsorted.OrderByDescending(keys => keys.Value);

            int count = 0;

            foreach (var kases in sortedWords)
            {
                if (count < 7)
                {
                    chart1.Series[0].Points.AddXY(kases.Key, kases.Value);
                    count++;
                }
                else
                {
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> SpecialityCount = logic.CreateGystogram();
            CreateChart(SpecialityCount);
        }
    }   
}
