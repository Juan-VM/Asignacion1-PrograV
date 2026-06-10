using Asignacion1.DatabaseHelper;
using System.Data;

namespace Asignacion1.Models
{
    public static class EmployeeDAL
    {
        public static List<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> list = new List<EmployeeViewModel>();

            DataTable ds = DatabaseSql.executeStoredProcedure("[dbo].[uspGetEmployees]");

            if (ds != null)
            {
                foreach (DataRow dr in ds.Rows)
                {
                    EmployeeViewModel employee = new EmployeeViewModel();

                    employee.BusinessEntityID = (int)dr["BusinessEntityID"];
                    employee.FullName = dr["FullName"].ToString() ?? string.Empty;
                    employee.JobTitle = dr["JobTitle"].ToString() ?? string.Empty;
                    employee.Department = dr["Department"].ToString() ?? string.Empty;
                    employee.ShiftName = dr["ShiftName"].ToString() ?? string.Empty;
                    employee.ActiveEmployee = Convert.ToBoolean(dr["ActiveEmployee"]);

                    list.Add(employee);
                }
            }

            return list;
        }
    }
}