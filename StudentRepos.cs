using CleanARCHiLMS_Application;
using CleanARCHiLMS_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanARCHiLMS_Infrastructure
{

    // infrastructure depend on application Leyar

    // now we can inherid with Istudentrepo interface 
    public class StudentRepos : IStudentRepos
    {
        private readonly StudentDBContext _studentDBContext;

        public StudentRepos(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }
        public Student CreateStudent(Student student)
        {
           _studentDBContext.students.Add(student);
            _studentDBContext.SaveChanges();
            return student;
        }

        public Student DeleteStudent(int id)
        {
            var student = _studentDBContext.students.Find(id);
            if (student == null)
            {
                return null;
            }

            _studentDBContext.students.Remove(student);
            _studentDBContext.SaveChanges();

            return student;

        }
        public Student GetStudentByID(int id)
        {
            var student = _studentDBContext.students.Find(id);
            if (student == null)
            {
                return null;
            }
            return student;

        }

        public List<Student> GetAllStudents()
        {
            return _studentDBContext.students.ToList();
        }

        public Student SaveStudent(Student student)
        {
            _studentDBContext.students.Add(student);
            _studentDBContext.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            if (student.StuId != 0)
            {
                _studentDBContext.students.Update(student);
                _studentDBContext.SaveChanges();
                return student;
            }
            return student;
        }
    }
}
