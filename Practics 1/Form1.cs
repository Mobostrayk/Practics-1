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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }   
}
