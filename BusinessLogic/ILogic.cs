using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public interface ILogic
    {
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="student"> Добавляемый студент </param>
        void AddStudent(Student student);
        /// <summary>
        /// Удаление студента по ID
        /// </summary>
        /// <param name="id"> ID студента </param>
        void DeleteStudent(int id);
        /// <summary>
        /// Изменение параментров студента по ID
        /// </summary>
        /// <param name="student"> Изменяемый студент </param>
        void ChangeStudent(Student student);
        /// <summary>
        /// Выдает список студентов 
        /// </summary>
        /// <returns>Список студентов </returns>
        void GiveStudents();
        /// <summary>
        /// Создает словарь для гистограммы в виде - (Специальность/кол-во студентов)
        /// </summary>
        /// <returns> Словарь для гистограммы в виде - (Специальность/кол-во студентов) </returns>
        void CreateGystogram();

        /// <summary>
        /// Событие, возникающее при добавлении студента.
        /// </summary>
        event EventHandler<StudentAddEventArgs> EventStudentAdded;

        /// <summary>
        /// Событие, возникающее при обновлении данных студента.
        /// </summary>
        event EventHandler<StudentUpdateEventArgs> EventStudentUpdated;

        /// <summary>
        /// Событие, возникающее при удалении студента.
        /// </summary>
        event EventHandler<StudentSelectEventArgs> EventStudentDeleted;

        /// <summary>
        /// Событие, возникающее при загрузке списка студентов.
        /// </summary>
        event EventHandler<StudentLoadListEventArgs> EventStudentList;

        /// <summary>
        /// Событие, возникающее при генерации отчёта о распределении студентов.
        /// </summary>
        event EventHandler<StudentHistogramEventArgs> EventStudentHistogram;
    }
}
