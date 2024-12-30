using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _iEmployeeRepository;

        public EmployeeController(IEmployeeRepository iEmployeeRepository)
        {
            _iEmployeeRepository = iEmployeeRepository;
        }

        [HttpGet]   
        public IActionResult EmployeeInformation()
        {
            //model.RoleList = iRoleRepository.GetAll().Select(x => new SelectListItem { Text = x.RoleName, Value = x.RoleID.ToString() }).ToList();
            //model.RoleList.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            //Tbl_HRM_EmployeeInformation model =new Tbl_HRM_EmployeeInformation();
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeList()
        {
           var results= _iEmployeeRepository.GetAllEmployee().OrderBy(x => x.EmpId).ToList();
            return PartialView("_EmployeeList", results);
        }
        [HttpPost]
        public IActionResult SaveEmployee(EmployeeViewModel model)
        {
            try
            {
                var result = _iEmployeeRepository.GetAllEmployee().Where(x => x.EmpId != model.EmpId && x.EmpName.Trim().ToLower() == model.EmpName.Trim().ToLower()).FirstOrDefault();
                if (result != null)
                {
                    return Json(new { Success = false, Message = "Employee Name is already exist! " });
                }
                if (model.EmpId == 0)
                {
                    _iEmployeeRepository.AddEmployee(model);
                    return Json(new { Success = true, Message = "Saved Successfuly" });
                }
                else
                {
                    _iEmployeeRepository.UpdateEmployee(model);
                    return Json(new { Success = true, Message = "Updated Successfuly" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ex.Message });
            }
        }
        [HttpGet]
        public IActionResult EditEmployee(int EmpId)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            try
            {
                var EmpInfo = _iEmployeeRepository.GetEmployeeByEmpId(EmpId);
                if (EmpInfo == null)
                {
                    return Json(new { Success = false, Message = "Employee Info not Found" });
                }
                model.EmpId = EmpInfo.EmpId;
                model.RoleId = EmpInfo.RoleId;
                model.EmpName = EmpInfo.EmpName;
                model.EmpContact = EmpInfo.EmpContact;
                model.EmpAddress = EmpInfo.EmpAddress;
                model.Status = EmpInfo.Status;
                return Json(new { Success = true, Record = model });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ex.Message });
            }
        }
    }
}
