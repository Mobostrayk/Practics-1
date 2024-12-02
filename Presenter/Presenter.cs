using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Shared;


namespace Presenter
{
    public class Presenter1
    {
        public IView view;
        public ILogic logic;

        public Presenter1(IView view, ILogic logic)
        {
            this.view = view;
            this.logic = logic;

            this.view.AddStudentEvent += OnAddStudent;
            this.view.DeleteStudentEvent += OnDeleteStudent;
            this.view.UpdateStudentEvent += OnUpdateStudent;
            this.view.ShowAllStudentsEvent += OnShowAllStudents;
        }
        public void OnAddStudent(object sender, StudentEventArgs e)
        {
            logic.AddStudent(Student student);
            OnShowAllStudents(sender, EventArgs.Empty);
        }
        public void OnDeleteStudent(object sender, int id)
        {
            logic.DeleteStudent(id);
            OnShowAllStudents(sender, EventArgs.Empty);
        }
        public void OnUpdateStudent(object sender, StudentEventArgs e)
        {
            logic.Edit(e.Id, e.Name, e.Speciality, e.Group);
            OnShowAllStudents(sender, EventArgs.Empty);
        }
        public void OnShowAllStudents(object sender, EventArgs e)
        {
            var students = logic.ShowAllStudents();
            view.ShowStudents(students);
        }
    }
}