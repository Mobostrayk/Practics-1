using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practics_1
{
    public partial class Form2 : Form
    {
        Form1 form1;
        string oldname;
        string oldspeciality;
        string oldgroup;
        public Form2(Form1 owner)
        {
            form1 = owner;
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            oldname = textBox1.Text;
            oldspeciality = textBox2.Text;
            oldgroup = textBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (form1.flag == false) form1.logic.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text);
            else form1.logic.ChangeStudent(oldname, oldspeciality, oldgroup, textBox1.Text, textBox2.Text, textBox3.Text);
        }

    }
}
