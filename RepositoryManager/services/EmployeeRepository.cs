using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RepositoryManager.Interface;
using RepositoryManager.Model;

namespace RepositoryManager.services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeManagementEntitiesEntities employeeManagementEntitiesObject;
        public EmployeeRepository()
        {
            employeeManagementEntitiesObject = new EmployeeManagementEntitiesEntities();
        }

        public IList<EmployeeContract> GetAllEmployee()
        {
            var query = (from a in employeeManagementEntitiesObject.EmployeeDetails select a).Distinct();
            List<EmployeeContract> employeeData = new List<EmployeeContract>();

            query.ToList().ForEach(x =>
            {
                employeeData.Add(new EmployeeContract
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Salary = x.Salary,
                });
            });

            return employeeData;
        }

        public int AddEmployee(EmployeeContract employeeContract)
        {
            EmployeeDetails employee = new EmployeeDetails()
            {
                Name = employeeContract.Name,
                Email = employeeContract.Email,
                Salary = employeeContract.Salary,
            };
            employeeManagementEntitiesObject.EmployeeDetails.Add(employee);
            return employeeManagementEntitiesObject.SaveChanges();
        }
        public int UpdateEmployee(EmployeeContract employeeContract, int EmpId)
        {
            EmployeeDetails employee = employeeManagementEntitiesObject.EmployeeDetails.Find(EmpId);
            if (employee != null)
            {
                employee.Email = employeeContract.Email;
                employee.Name = employeeContract.Name;
                employee.Salary = employeeContract.Salary;
                return employeeManagementEntitiesObject.SaveChanges();
            }
            else
            {
                throw new Exception("Employee do not exists");
            }
        }
        public EmployeeContract GetById(int empId)
        {
            var Employee = employeeManagementEntitiesObject.EmployeeDetails.Find(empId);
            EmployeeContract employeeContract = new EmployeeContract()
            {
                Name = Employee.Name,
                Email = Employee.Email,
                Salary = Employee.Salary,
                Id = Employee.Id
            };
            return employeeContract;
        }
        public int DeleteEmployee(int empId)
        {
            var employee = (from a in employeeManagementEntitiesObject.EmployeeDetails
                            where a.Id == empId
                            select a).FirstOrDefault();
            if (employee != null)
            {
                employeeManagementEntitiesObject.EmployeeDetails.Remove(employee);
                return employeeManagementEntitiesObject.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        public EmployeeContract GetEmployeeByEmail(string email)
        {
            EmployeeDetails employeeDetail = (from a in employeeManagementEntitiesObject.EmployeeDetails
                                             where a.Email == email
                                             select a).FirstOrDefault();

            if (employeeDetail != null)
            {
                EmployeeContract employeeContract = new EmployeeContract()
                {
                    Name = employeeDetail.Name,
                    Email = employeeDetail.Email,
                    Salary = employeeDetail.Salary,
                    Id = employeeDetail.Id
                };
                return employeeContract;
            }
            return null;
        }
    }
}
