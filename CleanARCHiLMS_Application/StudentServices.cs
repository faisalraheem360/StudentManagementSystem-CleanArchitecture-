using CleanARCHiLMS_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanARCHiLMS_Application
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepos _studentRepos;

        // constructor Dependency injection
        //we can pass in parameters IStudentRepo interface
        public StudentServices(IStudentRepos studentRepos)
        {
            _studentRepos = studentRepos;
        }

        public Student CreateStudent(Student student)
        {
           _studentRepos.CreateStudent(student);
            return student;
        }
        public List<Student> GetAllStudents()
        {
          var students = _studentRepos.GetAllStudents();
            return students;
        }
    }
}
