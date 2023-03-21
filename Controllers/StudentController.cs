using CleanARCHiLMS_Application;
using CleanARCHiLMS_Domain;
using CleanARCHiLMS_Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CleanARCHiLMS_Api.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDBContext _context;
        public StudentController(StudentDBContext context)
        {
           _context = context;  
        }

        public IActionResult Index()
        {
            //List<Student> obj= _context.students.ToList();

             return View();
        }
    }
}
