using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared
{
    public interface IView
    {
        /// <summary>
        /// Событие, возникающее при добавление студента
        /// </summary>
        event Action<StudentEventArgs> AddStudentEvent;
        /// <summary>
        /// Событие, возникающее при удалении студента
        /// </summary>
        event Action<int> DeleteStudentEvent;
        /// <summary>
        /// Событие, возникающее при изменении студента
        /// </summary>
        event Action<StudentEventArgs> UpdateStudentEvent;
        /// <summary>
        /// Событие, возникающее при отображении всех студентов
        /// </summary>
        event Action ShowAllStudentsEvent;
        /// <summary>
        /// Событие, возникающее при обновлении гистограммы
        /// </summary>
        event Action ShowGistogramm;
        /// <summary>
        /// Метод вывода студетов
        /// </summary>
        /// <param name="students"> Лист студентов</param>
        void ShowStudents(List<string[]> students);
        /// <summary>
        /// Метод отрисовки гистограммы
        /// </summary>
        /// <param name="data"> Словарь распределения по специальностям</param>
        void DisplayGistogramm(Dictionary<string, int> data);
    }
    public class StudentEventArgs : EventArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Group { get; set; }

        public StudentEventArgs(int id, string name, string speciality, string group)
        {
            Id = id;
            Name = name;
            Speciality = speciality;
            Group = group;
        }
    }
}