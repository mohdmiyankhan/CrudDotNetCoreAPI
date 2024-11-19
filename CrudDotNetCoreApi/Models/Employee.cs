using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        [StringLength(50)]
        public string EmpName { get; set; }

        [StringLength(25)]
        public string EmpCode { get; set; }

        [StringLength(50)]
        public string EmpEmailId { get; set; }

        public int EmpDesignationId { get; set; }

        public int EmpRoleId { get; set; }
        
        [NotMapped]
        public string EmpDesignation { get; set; }

        [NotMapped]
        public string EmpRole { get; set; }
    }
}
