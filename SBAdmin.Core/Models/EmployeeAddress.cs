using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Core.Models
{
    public class EmployeeAddress
    {
        [Key]
        public Guid RecordID { get; set; }

        [MaxLength(256)]
        public string ContactName { get; set; }

        [MaxLength(256)]
        public string AddressLine1 { get; set; }

        [MaxLength(256)]
        public string AddressLine2 { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(50)]
        public string CountryID { get; set; }

        public Guid EmployeeID { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        public Employee Employee { get; set; }
    }
}
