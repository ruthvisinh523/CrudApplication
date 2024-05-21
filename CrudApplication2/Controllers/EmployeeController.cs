using CrudApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CrudApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        CityDataAccess cityDataAccess = new CityDataAccess();
        StateDataAccess stateDataAccess = new StateDataAccess();

        [HttpGet]
        public IActionResult Index()
        {
            return View(employeeDataAccess.GetAllEmployee());
        }

        [HttpGet]



        public IActionResult EmployeeCreate()

        {
            EmployeeModel employeeModel = new EmployeeModel();

            employeeModel.listEmployrrModels = (List<SelectListItem>)cityDataAccess.GetallCity()
                .Select(x => new SelectListItem { Value = x.CityId.ToString(), Text = x.CityName.ToString() }).ToList();

            employeeModel.listStateModels = (List<SelectListItem>)stateDataAccess.GetAllState()
               .Select(x => new SelectListItem { Value = x.StateId.ToString(), Text = x.StateName.ToString() }).ToList();

            //var vm = new EmployeeModel
            //{
            //    listGender = new List<Gender>
            //    {
            //        new Gender{Id="M",GenderName="Male"},
            //         new Gender{Id="F",GenderName="Female"},
            //          new Gender{Id="O",GenderName="Other"}
            //    }
            //};

            //employeeModel.listGender = (IEnumerable<Gender>)stateDataAccess.GetAllState()
            //   .Select(x => new SelectListItem { Value = x.StateId.ToString(), Text = x.StateName.ToString() }).ToList();

            return View(employeeModel);
        }

        [HttpPost]
        public IActionResult Employeecreate(EmployeeModel employeeModel)

        {
            if (employeeModel != null)
            {
                employeeDataAccess.InsertEmployeeModel(employeeModel);
                TempData["StateSuccess"] = "Record Insert";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EmployeeUpdate(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel = employeeDataAccess.GetEmployeebyId(id);
            employeeModel.listEmployrrModels = (List<SelectListItem>)cityDataAccess.GetallCity()
                .Select(x => new SelectListItem { Value = x.CityId.ToString(), Text = x.CityName.ToString() }).ToList();


            employeeModel.listStateModels = (List<SelectListItem>)stateDataAccess.GetAllState()
               .Select(x => new SelectListItem { Value = x.StateId.ToString(), Text = x.StateName.ToString() }).ToList();


            return View(employeeModel);
        }

        [HttpPost]
        public IActionResult EmployeeUpdate(EmployeeModel employeeModel)
        {
            if (employeeModel != null)
            {
                employeeDataAccess.UpdateEmployeeModel(employeeModel);
                TempData["StateSuccessUpdate"] = "Record Update SuccessFull";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EmployeeDelete(int id)
        {
            if (id != null)
            {
                employeeDataAccess.DeleteEmployee(id);
                TempData["EmployeeSuccessDelete"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EmployeeDetails(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            EmployeeModel   employeeModel = new EmployeeModel();

            return View(employeeDataAccess.GetEmployeebyId(id));

        }
    }
}
