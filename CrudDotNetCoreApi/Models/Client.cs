using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [StringLength(50)]
        public string ContactPersonName { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(6)]
        public string PinCode { get; set; }

        [StringLength(25)]
        public string State { get; set; }

        public int EmployeeStrength { get; set; }

        [StringLength(10)]
        public string ContactNo { get; set; }

        [StringLength(25)]
        public string GSTNo { get; set; }

        [StringLength(25)]
        public string RegNo { get; set; }
    }
}
