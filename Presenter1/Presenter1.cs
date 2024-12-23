using BusinessLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter1
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
        /// <summary>
        /// Метод добававления студента
        /// </summary>
        /// <param name="e">Параметры студента</param>
        public void OnAddStudent(StudentEventArgs e)
        {
            logic.AddStudent(e.Name, e.Speciality, e.Group);
        }
       /// <summary>
       /// Метод удаления студента
       /// </summary>
       /// <param name="id"> id студента</param>
        public void OnDeleteStudent(int id)
        {
            logic.DeleteStudent(id);
        }
        /// <summary>
        /// Метод изменения студента
        /// </summary>
        /// <param name="e">Параметры студента</param>
        public void OnUpdateStudent(StudentEventArgs e)
        {
            logic.ChangeStudent(e.Id, e.Name, e.Speciality, e.Group);
        }
        /// <summary>
        /// Метод отображения всех студентов
        /// </summary>
        public void OnShowAllStudents()
        {
            logic.GiveStudents();
        }
        /// <summary>
        /// Метод распределения по специальностям
        /// </summary>
        public void OnShowGistogramm()
        {
            logic.CreateDictForGist();
        }
    }
}
