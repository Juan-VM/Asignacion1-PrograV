using Asignacion1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asignacion1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(
            string? name,
            string? department,
            string? jobTitle,
            string? shift,
            bool onlyActive = false)
        {
            EmployeePageViewModel model = new EmployeePageViewModel();

            model.Filters.Name = name;
            model.Filters.Department = department;
            model.Filters.JobTitle = jobTitle;
            model.Filters.Shift = shift;
            model.Filters.OnlyActive = onlyActive;

            model.Employees = EmployeeDAL.GetEmployees(
                    name,
                    department,
                    jobTitle,
                    shift,
                    onlyActive
                );

            return View(model);
        }
    }
}
