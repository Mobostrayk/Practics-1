using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared
{
    public interface IView
    {
        event EventHandler<StudentEventArgs> AddStudentEvent;
        event EventHandler<int> DeleteStudentEvent;
        event EventHandler<StudentEventArgs> UpdateStudentEvent;
        event EventHandler ShowAllStudentsEvent;
        event EventHandler<StudentEventArgs> ShowGistogramm;

        void ShowStudents(List<string[]> students);
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