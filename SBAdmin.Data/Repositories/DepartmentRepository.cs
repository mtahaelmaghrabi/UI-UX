using Microsoft.EntityFrameworkCore;
using SBAdmin.Core.Models;
using SBAdmin.Core.Repositories;
using SBAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Api.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        // resturn the context from the generic repository
        private HRDbContext hrContext
        {
            get { return context as HRDbContext; }
        }

        public DepartmentRepository(HRDbContext context)
            : base(context)
        { }

        public override Department Update(Department entity)
        {
            var dbEntity = context.Department.Single(p => p.DepartmentID == entity.DepartmentID);
            return base.Update(entity);
        }

        async Task<IEnumerable<Department>> IDepartmentRepository.GetAllChildDepartments(Guid id)
        {
            var childDepartments = await hrContext.Department.
                 Where(d => d.ParentDepartmentID == id).ToListAsync();

            return childDepartments;
        }
        public async Task<IEnumerable<Department>> GetAllChildDepartments(Guid id)
        {
            var childDepartments = await hrContext.Department.
                 Where(d => d.ParentDepartmentID == id).ToListAsync();

            return childDepartments;
        }

    }
}