using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class Logic
    {
        List<Student> Students = new List<Student>() { new Student("Александр 3000", "КомБез", "Ки23-05"), new Student("Максим Абсолют", "ИСИТ", "Ки23-12Б"), new Student("Иван Пистолет", "ПрогИнж", "Ки23-9Б"), new Student("Иван Пистолет", "ИСИТ", "Ки23-9Б") };   
        public  void AddStudent(string Name, string Speciality, string Group)
        {
            Student newstudent = new Student(Name,Speciality,Group);
            Students.Add(newstudent);
            
        }
        public  void DeleteStudent(string Name, string Speciality, string Group)
        {
            Student badstudent = Students.FirstOrDefault(a => a.Name == Name && a.Speciality == Speciality && a.Group == Group);
            Students.Remove(badstudent);
        }
        public void  ChangeStudent(string OldName, string OldSpeciality, string OldGroup, string NewName, string NewSpeciality, string NewGroup)
        {
            Student newstudent = new Student(NewName, NewSpeciality, NewGroup);
            Student oldstudent = Students.FirstOrDefault(a => a.Name == OldName && a.Speciality == OldSpeciality && a.Group == OldGroup);
            if (oldstudent != null)
            {
                Students.Remove(oldstudent);
                Students.Add(newstudent);
            }
        }
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
        public Dictionary<string, int> CreateGystogram()
        {
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
