using SBAdmin.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBAdmin.Core.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllChildDepartments(Guid id );
    }
}