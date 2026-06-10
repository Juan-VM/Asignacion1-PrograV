namespace Asignacion1.Models
{
    public class EmployeeViewModel
    {
        public int BusinessEntityID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string ShiftName { get; set; } = string.Empty;

        public bool ActiveEmployee { get; set; }
    }
}
