using Shared;
using BusinessLogic;
using Ninject;
using Presenter;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practics_1
{

    public partial class Form2 : Form
    {
        public event Action<StudentEventArgs> DataPassed;
        public StudentEventArgs args1;

        //public IKernel ninjectKernel;
        //public ILogic logic;
        //public Presenter1 presenter;

        Form1 form1;
        public Form2(Form1 owner)
        {
            form1 = owner;
            //ninjectKernel = new StandardKernel(new SimpleConfigModule());
            //logic = ninjectKernel.Get<Logic>();
            //presenter = new Presenter1(form1, logic);
            InitializeComponent();
        }
        /// <summary>
        /// Загрузка формы2
        /// </summary>
        public void Form2_Load(object sender, EventArgs e)
        {
        }
        
        /// <summary>
        /// Добавление/изменение студента в зависимости от flag и нажатой кнопки в форм1
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (form1.flag == false)
            {
                //form1.logic.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text);
                args1 = new StudentEventArgs(1, textBox1.Text, textBox2.Text, textBox3.Text);
                //AddStudentEvent?.Invoke(args1);
            }

            else
            {
                //form1.logic.ChangeStudent(Convert.ToInt32(form1.listView1.SelectedItems[0].SubItems[0].Text),
                //textBox1.Text, textBox2.Text, textBox3.Text);
                args1 = new StudentEventArgs(Convert.ToInt32(form1.listView1.SelectedItems[0].SubItems[0].Text), textBox1.Text, textBox2.Text, textBox3.Text);
                //UpdateStudentEvent?.Invoke(args1);
            }
           
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Вызываем событие, передавая данные из текстового поля
            DataPassed?.Invoke(args1);
            base.OnFormClosing(e);
        }
    }
}
