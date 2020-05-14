using Microsoft.EntityFrameworkCore;
using SBAdmin.Api.Repositories;
using SBAdmin.Core.Models;
using SBAdmin.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        // resturn the context from the generic repository
        private HRDbContext hrContext
        {
            get { return context as HRDbContext; }
        }

        public EmployeeRepository(HRDbContext context)
            : base(context)
        { }

        public override Employee Update(Employee entity)
        {
            // just to demonistrate the ability to override any method
            var dbEntity = hrContext.Employee.Single(p => p.EmployeeID == entity.EmployeeID);

            dbEntity.Mobile = "+974" + dbEntity.Mobile.Trim();

            return base.Update(entity);
        }

        // From IEmployeeRepository
        async Task<IEnumerable<Employee>> IEmployeeRepository.GetAllWithAddresses()
        {
            return await hrContext.Employee
                .Include(a => a.EmployeeAddress)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithAddresses()
        {
            return await hrContext.Employee
                .Include(a => a.EmployeeAddress)
                .ToListAsync();
        }
    }
}