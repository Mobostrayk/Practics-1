using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Аргументы события для добавления студента.
    /// </summary>
    public class StudentAddEventArgs : EventArgs
    {
        public Student Student { get; set; }
        public StudentAddEventArgs(Student student)
        {
            Student = student;
        }
    }

    /// <summary>
    /// Аргументы события для вывода гистограммы
    /// </summary>
    public class StudentHistogramEventArgs
    {
        public Dictionary<string, int> Histogram;
        public StudentHistogramEventArgs(Dictionary<string, int> histogram)
        {
            Histogram = histogram;
        }
    }

    public class StudentLoadedEventArgs
    {
        public Student Student;
        public StudentLoadedEventArgs(Student student) { this.Student = student; }
    }

    /// <summary>
    /// Аргументы события для загрузки студентов в список
    /// </summary>
    public class StudentLoadListEventArgs
    {
        public List<String[]> students;
        public StudentLoadListEventArgs(List<String[]> students)
        {
            this.students = students;
        }
    }

    /// <summary>
    /// Аргументы события для выбора студента.
    /// Содержит идентификатор студента, который был выбран.
    /// </summary>
    public class StudentSelectEventArgs
    {
        public int Id;
        public StudentSelectEventArgs(int Id)
        {
            this.Id = Id;
        }
    }

    /// <summary>
    /// Аргументы события для обновления данных студента.
    /// Содержит объект студента с обновлёнными данными.
    /// </summary>
    public class StudentUpdateEventArgs
    {
        public Student StudentToUpdate { get; set; }

        public StudentUpdateEventArgs(Student studentToUpdate)
        {
            StudentToUpdate = studentToUpdate;
        }
    }
}
