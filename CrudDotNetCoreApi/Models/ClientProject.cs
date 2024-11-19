using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class ClientProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientProjectId { get; set; }

        [StringLength(50)]
        public string ProjectName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpectedDate { get; set; }

        public int LeadByEmpId { get; set; }

        public DateTime CompletedDate { get; set; }

        [StringLength(50)]
        public string ContactPersonName { get; set; }

        [StringLength(10)]
        public string ContactPersonContactNo { get; set; }

        [StringLength(50)]
        public string ContactPersonEmailId { get; set; }

        public int TotalEmpWorking { get; set; }

        public int ProjectCost { get; set; }

        [StringLength(200)]
        public string ProjectDetails { get; set; }

        public int ClientId { get; set; }

        [NotMapped]
        public string LeadByEmp { get; set; }

        [NotMapped]
        public string Client { get; set; }
    }
}
