using Asignacion1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asignacion1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<EmployeeViewModel> list = EmployeeDAL.GetEmployees();

            return View(list);
        }
    }
}
