using Asignacion1.DatabaseHelper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Asignacion1.Models
{
    public static class EmployeeDAL
    {
        public static List<EmployeeViewModel> GetEmployees(
            string? name,
            string? department,
            string? jobTitle,
            string? shift,
            bool onlyActive)
        {
            List<EmployeeViewModel> list = new List<EmployeeViewModel>();

            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", string.IsNullOrWhiteSpace(name) ? DBNull.Value : name),
                new SqlParameter("@Department", string.IsNullOrWhiteSpace(department) ? DBNull.Value : department),
                new SqlParameter("@JobTitle", string.IsNullOrWhiteSpace(jobTitle) ? DBNull.Value : jobTitle),
                new SqlParameter("@Shift", string.IsNullOrWhiteSpace(shift) ? DBNull.Value : shift),
                new SqlParameter("@OnlyActive", onlyActive)
            };

            DataTable ds = DatabaseSql.executeStoredProcedure("[dbo].[uspGetEmployees]", parameters);

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