using TestProject.Data;
using TestProject.Models;

namespace TestProject.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) { _context = context; } 
        public void AddEmployee(EmployeeViewModel model)
        {
            try
            {
                Tbl_HRM_EmployeeInformation obj = new Tbl_HRM_EmployeeInformation();
                obj.EmpId = model.EmpId;
                obj.EmpName = model.EmpName;
                obj.EmpContact = model.EmpContact;
                obj.EmpAddress = model.EmpAddress;
                obj.RoleId = model.RoleId;
                obj.Status = model.Status;
                _context.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EmployeeViewModel> GetAllEmployee()
        {
            try
            {
                var result = _context.Tbl_HRM_EmployeeInformation
                    .Select(x => new EmployeeViewModel
                    {
                        EmpId = x.EmpId,
                        EmpName = x.EmpName,
                        EmpContact = x.EmpContact,
                        EmpAddress = x.EmpAddress,
                        RoleId = x.RoleId,
                        Status = x.Status
                    }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployeeViewModel GetEmployeeByEmpId(int EmpId)
        {
            try
            {
                var result = _context.Tbl_HRM_EmployeeInformation.Where(x=>x.EmpId==EmpId)
                    .Select(x => new EmployeeViewModel
                    {
                        EmpId = x.EmpId,
                        EmpName = x.EmpName,
                        EmpContact = x.EmpContact,
                        EmpAddress = x.EmpAddress,
                        RoleId = x.RoleId,
                        Status = x.Status
                    }).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateEmployee(EmployeeViewModel model)
        {
            var result = _context.Tbl_HRM_EmployeeInformation.FirstOrDefault(x => x.EmpId == model.EmpId);
            if (result != null)
            {
                result.EmpName = model.EmpName;
                result.EmpContact = model.EmpContact;
                result.EmpAddress = model.EmpAddress;
                result.RoleId = model.RoleId;
                result.Status = model.Status;
                _context.SaveChanges();
            }
        }
    }
}
