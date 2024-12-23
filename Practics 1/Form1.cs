using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Practics_1 
{
    public partial class Form1 : Form, IView
    {
        public event Action<StudentEventArgs> AddStudentEvent = delegate { };
        public event Action<int> DeleteStudentEvent = delegate { };
        public event Action<StudentEventArgs> UpdateStudentEvent = delegate { };
        public event Action ShowAllStudentsEvent = delegate { };
        public event Action ShowGistogramm = delegate { };

        public IKernel ninjectKernel;

        public bool flag;
        public StudentEventArgs args;
        public Form1()
        {

            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            listView1.Columns.Add("ID", 200);
            listView1.Columns.Add("ФИО студента", 200);
            listView1.Columns.Add("Специальность", 120);
            listView1.Columns.Add("Группа", 120);
            ShowAllStudentsEvent?.Invoke();
        }

        private void Form2_DataPassed(StudentEventArgs data)
        {
            var args = data;   
            if (flag == false) AddStudentEvent?.Invoke(args);
            else UpdateStudentEvent?.Invoke(args);
            ShowAllStudentsEvent?.Invoke();
        }

        /// <summary>
        /// Функция обновления списка студентов
        /// </summary>
        public void ShowStudents(List<string[]> students)
        {
            listView1.Items.Clear();
            foreach (String[] student in students)
            {
                ListViewItem studentitem = new ListViewItem(student);
                listView1.Items.Add(studentitem);
            }
        }
        /// <summary>
        /// Обновление списка студентов
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Обновить список студентов
            ShowAllStudentsEvent?.Invoke();
        }
        /// <summary>
        /// Открытие второй формы для добавления студента
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            //Открыть вторую форму
            flag = false;
            Form2 form2 = new Form2(this);
            form2.DataPassed += Form2_DataPassed;
            form2.Show();
            
        }

        /// <summary>
        /// Удаление выбранного студента
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            // Проверяем выбран ли студент, если выбраны несколько или не выбрано вообще, то предупреждаем пользователя
            if (listView1.SelectedItems.Count == 1)
            {
                DeleteStudentEvent?.Invoke(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
            }
            ShowAllStudentsEvent?.Invoke();

        }
        /// <summary>
        /// Открытие второй формы для добавления студента
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            // Передаем в форм2 необходимые данные для изменения студента
            if (listView1.SelectedItems.Count == 1)
            {
                flag = true;
                Form2 form2 = new Form2(this);
                form2.textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                form2.textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
                form2.textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
                form2.DataPassed += Form2_DataPassed;
                form2.Show();
            
                

            }

        }
        /// <summary>
        /// Создание гистограммы по выданному словарю
        /// </summary>
        /// <param Словарь из неотсортированных элементов="notsorted"></param>
        public void DisplayGistogramm(Dictionary<string, int> notsorted)
        {
            // Создаем базу для гистограммы
            chart1.Series[0].Points.Clear();
            chart1.Series.Clear();
            chart1.Series.Add("Распределение студентов по специальностям");
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -80;

            // Сортируем и добавляем значения в гистограмму
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

        /// <summary>
        /// Вывод гистограммы
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            ShowGistogramm?.Invoke();
        }
    }   
}
