using BusinessManager.Interface;
using BusinessManager.services;
using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagmentApplication.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeBusiness empBusiness;
        public EmployeeService()
        {
            empBusiness = new EmployeeBusiness();
        }
        public string AddEmployee(EmployeeContract employeeContract)
        {
            try
            {
                return empBusiness.AddEmployee(employeeContract);
            }
            catch(Exception ex)
            {
                //ErrorClass err = new ErrorClass();
                //err.success = false;
                //err.message = ex.Message;
                //throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
                return ex.Message;
            }
        }

        public string DeleteEmployee(string empId)
        {
            int Id = Convert.ToInt32(empId);
            return empBusiness.DeleteEmployee(Id);
        }
                
        public IList<EmployeeContract> GetAllEmloyee()
        {
            return empBusiness.GetAllEmployee();
        }

        public EmployeeContract GetById(string empId)
        {
            int Id = Convert.ToInt32(empId);
            return empBusiness.GetById(Id);
        }
        public string UpdateEmployee(EmployeeContract employeeContract, string empId)
        {
            int Id = Convert.ToInt32(empId);
            return empBusiness.UpdateEmployee(employeeContract, Id);
        }
    }
}
