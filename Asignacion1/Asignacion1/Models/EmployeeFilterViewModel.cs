namespace Asignacion1.Models
{
    public class EmployeeFilterViewModel
    {
        public string? Name { get; set; }

        public string? Department { get; set; }

        public string? JobTitle { get; set; }

        public string? Shift { get; set; }

        public bool OnlyActive { get; set; }
    }
}
