using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Core.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentID{ get; set; }

        public string DepartmentName { get; set; }

        public Guid ParentDepartmentID { get; set; }

        public List<Employee> Employee { get; set; } = new List<Employee>();
    }
}