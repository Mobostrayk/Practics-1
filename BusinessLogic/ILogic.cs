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
        event Action<List<String[]>> GiveStudentsEvent;
        event Action<Dictionary<string, int>> CreateGistogramm;
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="name">Имя нового студента</param>
        /// <param name="group">Группа нового студента</param>
        /// <param name="speciality">Специальность нового студента</param>
        void AddStudent(string name, string speciality, string group);
        /// <summary>
        /// Удаление студента по ID
        /// </summary>
        /// <param name="id"> ID студента </param>
        void DeleteStudent(int id);
        /// <summary>
        /// Изменение студента
        /// </summary>
        /// <param name="id">ID студента, которого необходимо изменить</param>
        /// <param name="NewName">Имя студента, которого необходимо изменить</param>
        /// <param name="NewGroup">Группа студента, которого необходимо изменить</param>
        /// <param name="NewSpeciality">Специальность студента, которого необходимо изменить</param>
        void ChangeStudent(int Id, string NewName, string NewSpeciality, string NewGroup);
        /// <summary>
        /// Получение списка студентов
        /// </summary>
        /// <returns>Список студентов (или вывод об ошибке)</returns>
        void GiveStudents();
        /// <summary>
        /// Сбор статистических данных для гистограммы
        /// </summary>
        /// <returns>Статистические данные</returns>
        void CreateDictForGist();
    }
}
