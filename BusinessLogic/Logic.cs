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
    public class Logic : ILogic
    {
        public event Action<List<String[]>> GiveStudentsEvent = delegate { };
        public event Action<Dictionary<string, int>> CreateGistogramm = delegate { };
        public IRepository<Student> repository { get; set; }

        public Logic(IRepository<Student> Repository)
        {
            repository = Repository;
        }

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
        public void DeleteStudent(int id)
        {
            repository.Delete(id);
        }
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
        public void GiveStudents()
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
            GiveStudentsEvent?.Invoke(stringedStudents);
        }

        public void CreateDictForGist()
        {
            // Создаем и наполняем словарь (Специальность/кол-во студентов)
            var Students = repository.ReadAll();
            //// Создаем и наполняем словарь (Специальность/кол-во студентов)
            Dictionary<string, int> SpecialityCount = new Dictionary<string, int>();

            foreach (Student student in Students)
                    SpecialityCount[student.Speciality] = 1;

            CreateGistogramm?.Invoke(SpecialityCount);
        }
    }
}