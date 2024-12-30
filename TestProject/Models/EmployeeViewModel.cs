using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class EmployeeViewModel
    {
        public int EmpId { get; set; }
        public int Id { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
        public string EmpName { get; set; } = null!;
        public string? EmpContact { get; set; }
        public string? EmpAddress { get; set; }
    }
}
