using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBAdmin.Core;
using SBAdmin.Core.Models;
using SBAdmin.Core.Services;

namespace SBAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            this.employeeService = employeeService;
        }

        [HttpGet()]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _unitOfWork.EmployeeRepository.GetAll();
                var employees2 = employeeService.GetAllEmployee();

                if (employees == null)
                    return NotFound();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<Employee>> CreateArtist([FromBody] Employee saveEmployee)
        {
            await _unitOfWork.EmployeeRepository.AddAsync(saveEmployee);
            await _unitOfWork.SaveChangesAsync();

            var newEmployee2 = await employeeService.CreateEmployee(saveEmployee);

            return Ok(newEmployee2);
        }
    }
}