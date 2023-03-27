using CleanARCHiLMS_Domain;
using CleanARCHiLMS_Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Controllers
{
    public class StudentController : Controller
    {
        //private readonly StudentDBContext _context;
        //public StudentController(StudentDBContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult StudentForm(int id)
        {
            if (id == 0)
            {
                return PartialView("_student");
            }
            else
            {
                // Student d = _context.students.Find(id);
                return PartialView("_student");
            }
        }
     





    }
}
