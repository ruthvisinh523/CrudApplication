using CrudApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudApplication2.Controllers
{
    public class CityController : Controller
    {
        CityDataAccess cityDataAccess = new CityDataAccess();
        StateDataAccess stateDataAccess = new StateDataAccess();

        [HttpGet]
        public IActionResult Index()
        {
            return View(cityDataAccess.GetallCity());
        }

        [HttpGet]
        public IActionResult CityCreate()
        {
            CityModel cityModel = new CityModel();
            cityModel.listStateModels = (List<SelectListItem>)stateDataAccess.GetAllState()
                .Select(x => new SelectListItem { Value = x.StateId.ToString(), Text = x.StateName.ToString() }).ToList();
            return View(cityModel);
        }

        [HttpPost]
        public IActionResult CityCreate(CityModel cityModel)
        {
            if (cityModel != null)
            {
                cityDataAccess.InsertCityModel(cityModel);
                TempData["CitySuccessInsert"] = "Record Inserted Successfully";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CityUpdate(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityModel cityModel = new CityModel();
            cityModel = cityDataAccess.GetCitybyId(id);
            cityModel.listStateModels = (List<SelectListItem>)stateDataAccess.GetAllState()
               .Select(x => new SelectListItem { Value = x.StateId.ToString(), Text = x.StateName.ToString() }).ToList();
            return View(cityModel);
        }

        [HttpPost]
        public IActionResult CityUpdate(CityModel cityModel)
        {
            if (cityModel != null)
            {
                cityDataAccess.UpdateCityModel(cityModel);
                TempData["CitySuccessUpdate"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CityDelete(int id)
        {
            if (id != null)
            {
                cityDataAccess.DeleteCity(id);
                TempData["CitySuccessDelete"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }

        public IActionResult CityDetails(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityModel cityModel = new CityModel();

            return View(cityDataAccess.GetCitybyId(id));
        }

    }
}

