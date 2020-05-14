using SBAdmin.Core.Models;
using SBAdmin.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> EmployeeRepository { get; }

        IRepository<Department> DepartmentRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
