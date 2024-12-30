using TestProject.Models;

namespace TestProject.Services
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetAllEmployee();
        void AddEmployee(EmployeeViewModel model);
        void UpdateEmployee(EmployeeViewModel model);
        EmployeeViewModel GetEmployeeByEmpId(int EmpId);
    }
}
