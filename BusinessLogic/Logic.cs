using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;
using DataAccessLayer;

namespace BusinessLogic
{
    public class Logic
    {
        //ENTITY
        IRepository<Student> repository = new EntityFrameworkRepository<Student>();
        List<Student> Students = new List<Student>();
        //DAPPER
        //IRepository<Student> repository = new RepositoryDapper<Student>();

        /// <summary>
        /// Добавление студента в список
        /// </summary>
        /// <param name="name"> Имя студента </param>
        /// <param name="speciality"> Специальность студента</param>
        /// <param name="group"> Группа студента</param>
        public void AddStudent(string name, string speciality, string group)
        {

            Student student = new Student()
            {
                Name = name,
                Speciality = speciality,
                Group = group
            };
            repository.Create(student);
        }
        /// <summary>
        /// Удаление студента из списка
        /// </summary>
        /// <param name="id"> ID студента </param>

        public void DeleteStudent(int id)
        {
            repository.Delete(id);
        }
        /// <summary>
        /// Изменение определенного студента в списке
        /// </summary>
        /// <param name="Id"> Id студента</param>
        /// <param name="NewName"> Новое имя </param>
        /// <param name="NewSpeciality"> Новая специальность</param>
        /// <param name="NewGroup"> Новая группа </param>
        public void ChangeStudent(int Id, string NewName, string NewSpeciality, string NewGroup)
        {
            //Ищем нужного нам студента и переписываем его
            var student = repository.Read(Id);
            if (student != null)
            {
                student.Name = NewName;
                student.Speciality = NewSpeciality;
                student.Group = NewGroup;
                repository.Update(student);
            }

        }
        /// <summary>
        /// Выдает список студентов в виде массива String[]
        /// </summary>
        /// <returns> Список студентов в виде массива String[] </returns>
        public List<String[]> GiveStudents()
        {
            List<String[]> stringedStudents = new List<String[]>();
            foreach (Student student in repository.ReadAll())
            {
                String[] selectedStudent = new string[4];
                selectedStudent[0] = student.Id.ToString();
                selectedStudent[1] = student.Name;
                selectedStudent[2] = student.Speciality;
                selectedStudent[3] = student.Group;
                stringedStudents.Add(selectedStudent);
            }
            return stringedStudents;
        }
        /// <summary>
        /// Создает словарь для гистограммы в виде - (Специальность/кол-во студентов)
        /// </summary>
        /// <returns> Словарь для гистограммы в виде - (Специальность/кол-во студентов) </returns>
        public Dictionary<string, int> CreateGystogram()
        {
            var Students = repository.ReadAll();
            //// Создаем и наполняем словарь (Специальность/кол-во студентов)
            Dictionary<string, int> SpecialityCount = new Dictionary<string, int>();

            foreach (Student student in Students)
            {
                if (SpecialityCount.ContainsKey(student.Speciality))
                {
                    SpecialityCount[student.Speciality]++;
                }
                else
                {
                    SpecialityCount[student.Speciality] = 1;
                }
            }
            return SpecialityCount;
        }
    }
}
