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
        event Action ShowAllStudentsEvent;
        event Action ShowGistogramm;
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="student"> Добавляемый студент </param>
        void AddStudent(string name, string speciality, string group);
        /// <summary>
        /// Удаление студента по ID
        /// </summary>
        /// <param name="id"> ID студента </param>
        void DeleteStudent(int id);
        /// <summary>
        /// Изменение параментров студента по ID
        /// </summary>
        /// <param name="student"> Изменяемый студент </param>
        void ChangeStudent(int Id, string NewName, string NewSpeciality, string NewGroup);
        /// <summary>
        /// Выдает список студентов 
        /// </summary>
        /// <returns>Список студентов </returns>
        List<String[]> GiveStudents();
        /// <summary>
        /// Создает словарь для гистограммы в виде - (Специальность/кол-во студентов)
        /// </summary>
        /// <returns> Словарь для гистограммы в виде - (Специальность/кол-во студентов) </returns>
        Dictionary<string, int> CreateGystogram();
    }
}
