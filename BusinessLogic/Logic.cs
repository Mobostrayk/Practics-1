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
        List<Student> Students = new List<Student>() { new Student("Александр 3000", "КомБез", "Ки23-05"), new Student("Максим Абсолют", "ИСИТ", "Ки23-12Б") };   
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
        public  List<string> CreateGystogram(string Name, string Speciality, string Group)
        {
            Student newstudent = new Student(Name, Speciality, Group);
            //Students.Add(newstudent);
            return new List<string> { Name, Speciality, Group };
        }
    }
}
