using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Core.Models
{
    public class Employee
    {
        [Key] 
        public Guid EmployeeID { get; set; }
        [MaxLength(100)]
        public string EmployeeName { get; set; }

        public string ProfilePicture { get; set; }

        public bool Gender { get; set; }
        public DateTime Birthdate { get; set; }

        public DateTime HiringDate { get; set; }

        public string Mobile { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }


        //public Guid DepartmentID { get; set; }

        //[ForeignKey(nameof(DepartmentID))]
        //public Department Department { get; set; }


        public List<EmployeeAddress> EmployeeAddress { get; set; } = new List<EmployeeAddress>();
    }
}
