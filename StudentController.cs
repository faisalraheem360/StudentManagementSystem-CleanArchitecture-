using CleanARCHiLMS_Application;
using CleanARCHiLMS_Domain;
using CleanARCHiLMS_Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanARCHiLMS_Api.ApiContollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        private readonly StudentDBContext _context;

        public StudentController(IStudentServices studentServices,StudentDBContext context)
        {
            _studentServices = studentServices;
            _context = context;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult Get()
        {
            var students = _studentServices.GetAllStudents();
            return Ok(new { data = students });
        }
        [HttpGet("GetStudentByID/{ID}")]
        public Student GetStudentByID(int ID)
        {
            var students = _studentServices.GetStudentByID(ID);
            return students;
        }
        [HttpPost]
        public ActionResult<Student> postStudents(Student student)
        {
            if(student.StuId!=0)
            {
               var us= _studentServices.UpdateStudent(student);
                return Ok(us);   
            }
            else
            {
                var students = _studentServices.CreateStudent(student);
                return Ok(new { data = students });
            }
         
        } 
        // DELETE: api/Students/5
     //   [HttpDelete("{id}")]
        [HttpGet("DeleteStudent/{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = _context.students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            _context.SaveChanges();

            return student;
        }
    }
}
