using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManager.Interface
       
{
    public interface IEmployeeRepository
    {
        IList<EmployeeContract> GetAllEmployee();


        int AddEmployee(EmployeeContract employeeContract);

        int UpdateEmployee(EmployeeContract employeeContract, int EmpId);

        EmployeeContract GetById(int empId);

        int DeleteEmployee(int empId);

        EmployeeContract GetEmployeeByEmail(string email);

    }

}
