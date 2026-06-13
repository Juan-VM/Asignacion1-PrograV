namespace Asignacion1.Models
{
    public class EmployeePageViewModel
    {
        public EmployeeFilterViewModel Filters { get; set; } = new EmployeeFilterViewModel();
        public List<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
    }
}
