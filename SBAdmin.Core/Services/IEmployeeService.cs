using SBAdmin.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBAdmin.Core.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task UpdateEmployee(Employee employeeToBeUpdated, Employee employee);
        Task DeleteEmployee(Employee employee);
    }
}