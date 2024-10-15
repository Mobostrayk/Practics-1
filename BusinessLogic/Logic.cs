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

namespace BusinessLogic
{
    public class Logic
    {
        List<Student> Students = new List<Student>() { new Student("Александр 3000", "КомБез", "Ки23-05"), new Student("Максим Абсолют", "ИСИТ", "Ки23-12Б"), new Student("Иван Пистолет", "ПрогИнж", "Ки23-9Б"), new Student("Иван Пистолет", "ИСИТ", "Ки23-9Б"), new Student("Елисей Автомат", "ИСИТ", "Ки23-12Б") };

        /// <summary>
        /// Добавление студента в список
        /// </summary>
        /// <param name="Name"> Имя студента </param>
        /// <param name="Speciality"> Специальность студента</param>
        /// <param name="Group"> Группа студента</param>
        public void AddStudent(string Name, string Speciality, string Group)
        {
            Student newstudent = new Student(Name, Speciality, Group);
            Students.Add(newstudent);
            
        }
        /// <summary>
        /// Удаление студента из списка
        /// </summary>
        /// <param name="Name"> Имя студента </param>
        /// <param name="Speciality"> Специальность студента</param>
        /// <param name="Group"> Группа студента</param>
        public void DeleteStudent(string Name, string Speciality, string Group)
        {
            Student badstudent = Students.FirstOrDefault(a => a.Name == Name && a.Speciality == Speciality && a.Group == Group);
            Students.Remove(badstudent);
        }
        /// <summary>
        /// Изменение определенного студента в списке
        /// </summary>
        /// <param name="OldName"> Старое имя</param>
        /// <param name="OldSpeciality"> Старая специальность</param>
        /// <param name="OldGroup"> Старая группа</param>
        /// <param name="NewName"> Новое имя </param>
        /// <param name="NewSpeciality"> Новая специальность</param>
        /// <param name="NewGroup"> Новая группа </param>
        public void  ChangeStudent(string OldName, string OldSpeciality, string OldGroup, string NewName, string NewSpeciality, string NewGroup)
        {
                // Ищем нужного нам студента и переписываем его
                for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Name == OldName && Students[i].Speciality == OldSpeciality && Students[i].Group == OldGroup)
                {
                    Students[i].Name = NewName;
                    Students[i].Speciality = NewSpeciality;
                    Students[i].Group = NewGroup;
                }
            }
        }
        /// <summary>
        /// Выдает список студентов в виде массива String[]
        /// </summary>
        /// <returns> Список студентов в виде массива String[] </returns>
        public List<String[]> GiveStudents()
        {
            List<String[]> stringedstudents = new List<String[]>();
            foreach (Student student in Students)
            {
                String[] stringedstudent = new String[] { student.Name, student.Speciality, student.Group };
                stringedstudents.Add(stringedstudent);
            }
            return stringedstudents;
        }
        /// <summary>
        /// Создает словарь для гистограммы в виде - (Специальность/кол-во студентов)
        /// </summary>
        /// <returns> Словарь для гистограммы в виде - (Специальность/кол-во студентов) </returns>
        public Dictionary<string, int> CreateGystogram()
        {
            // Создаем и наполняем словарь (Специальность/кол-во студентов)
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
