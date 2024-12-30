using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestProject.Models
{
    public class Tbl_HRM_EmployeeInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }

        [StringLength(50)]
        public string? EmpContact { get; set; }

        [StringLength(50)]
        public string? EmpAddress { get; set; }
        //public List<SelectListItem> RoleList { get; set; }
    }
}
