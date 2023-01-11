using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface IEmployeeBusiness
    {
        IList<EmployeeContract> GetAllEmployee();
        string AddEmployee(EmployeeContract employeeContract);
        string UpdateEmployee(EmployeeContract employeeContract, int EmpId);
        EmployeeContract GetById(int empId);
        string DeleteEmployee(int empId);
    }
}
