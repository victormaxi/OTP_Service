using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTP_Application.Data;

namespace OTP_Application.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult GetAllEmployee()
        {
            var result = _context.Employees.ToList();
            return View(result);
        }
    }
}
