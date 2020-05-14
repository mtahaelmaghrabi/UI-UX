using SBAdmin.Api.Repositories;
using SBAdmin.Core;
using SBAdmin.Core.Models;
using SBAdmin.Core.Repositories;
using SBAdmin.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext context;

        public UnitOfWork(HRDbContext context)
        {
            this.context = context;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        private IRepository<Employee> _EmployeeRepository;
        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_EmployeeRepository == null)
                {
                    _EmployeeRepository = new EmployeeRepository(context);
                }

                return _EmployeeRepository;
            }
        }

        private IRepository<Department> _DepartmentRepository;
        public IRepository<Department> DepartmentRepository
        {
            get
            {
                if (_DepartmentRepository == null)
                {
                    _DepartmentRepository = new DepartmentRepository(context);
                }

                return _DepartmentRepository;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}