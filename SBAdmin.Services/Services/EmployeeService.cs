using SBAdmin.Core;
using SBAdmin.Core.Models;
using SBAdmin.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBAdmin.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            await _unitOfWork.EmployeeRepository.AddAsync(newEmployee);

            await _unitOfWork.SaveChangesAsync();

            return newEmployee;
        }

        public Task DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _unitOfWork.EmployeeRepository.GetAllAsync();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(Employee employeeToBeUpdated, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
