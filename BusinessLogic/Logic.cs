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
        public IRepository<Student> repository { get; set; }

        public event EventHandler<StudentAddEventArgs> EventStudentAdded = delegate { };
        public event EventHandler<StudentUpdateEventArgs> EventStudentUpdated = delegate { };
        public event EventHandler<StudentSelectEventArgs> EventStudentDeleted = delegate { };
        public event EventHandler<StudentLoadListEventArgs> EventStudentList = delegate { };
        public event EventHandler<StudentHistogramEventArgs> EventStudentHistogram = delegate { };
        public event EventHandler<StudentLoadedEventArgs> EventStudentLoaded = delegate { };

        public Logic(IRepository<Student> Repository)
        {
            repository = Repository;
        }

        public void AddStudent(Student student)
        {
            EventStudentAdded(this, new StudentAddEventArgs(student));
            repository.Create(student);
        }
        public void DeleteStudent(int id)
        {
            var student = repository.Read(id);
            repository.Delete(id);
            EventStudentDeleted(this, new StudentSelectEventArgs(student.Id));
        }
        public void ChangeStudent(Student student)
        {
            repository.Update(student);
            EventStudentUpdated(this, new StudentUpdateEventArgs(student));

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
            EventStudentList(this, new StudentLoadListEventArgs(stringedStudents));
        }

        public void CreateGystogram()
        {
            var students = repository.ReadAll();
            EventStudentHistogram(this, new StudentHistogramEventArgs(students.GroupBy(s => s.Speciality)
                                                                              .ToDictionary(g => g.Key, g => g.Count())));
        }
    }
}
