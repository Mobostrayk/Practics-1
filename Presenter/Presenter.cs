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
            this.view.ShowGistogramm += OnShowGistogramm;
        }
        public void OnAddStudent(StudentEventArgs e)
        {
            logic.AddStudent(e.Name, e.Speciality, e.Group);
            //OnShowAllStudents();
        }
        public void OnDeleteStudent(int id)
        {
            logic.DeleteStudent(id);
            //OnShowAllStudents();
        }
        public void OnUpdateStudent(StudentEventArgs e)
        {
            logic.ChangeStudent(e.Id, e.Name, e.Speciality, e.Group);
            //OnShowAllStudents();
        }
        public void OnShowAllStudents()
        {
            var students = logic.GiveStudents();
            view.ShowStudents(students);
        }
        public void OnShowGistogramm()
        {
            var data = logic.CreateGystogram();
            view.DisplayGistogramm(data);
        }
    }
}