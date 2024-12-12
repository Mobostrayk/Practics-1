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

            this.logic.GiveStudentsEvent += view.ShowStudents;
            this.logic.CreateGistogramm += view.DisplayGistogramm;
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
            logic.GiveStudents();
        }
        public void OnShowGistogramm()
        {
            logic.CreateDictForGist();
        }
    }
}