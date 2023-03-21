using CleanARCHiLMS_Application;
using CleanARCHiLMS_Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanARCHiLMS_Api.ApiContollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            var students = _studentServices.GetAllStudents();
            return Ok(students);
        }
        [HttpPost]
        public ActionResult<Student> postStudents(Student student)
        {
            var students = _studentServices.CreateStudent(student);
            return Ok(students);
        }


    }
}
