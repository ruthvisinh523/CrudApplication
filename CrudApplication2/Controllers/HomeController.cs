using Azure.Identity;
using CrudApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudApplication2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Home()
        {
            return View();
        }





        //===================================================State=============================================================






      
        StateDataAccess stateDataAccess = new StateDataAccess();

        [HttpGet]
        public IActionResult Index()
        {
            return View(stateDataAccess.GetAllState());
        }

        [HttpGet]
        public IActionResult StateCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StateCreate(StateModel stateModel)

        {
            if (stateModel != null)
            {
                stateDataAccess.InsertStateModel(stateModel);
                TempData["StateSuccess"] = "Record Insert";
            }
            return RedirectToAction("Index");
        }



        public IActionResult StateUpDate(int id)

        {
            if(id == 0)
            {
                return NotFound();
            }

            StateModel stateModel = new StateModel();
            return View(stateDataAccess.GetStateById(id));
        }



        [HttpPost]
            public IActionResult StateUpDate(StateModel stateModel)
        {
            if(stateModel != null)
            {
                stateDataAccess.UpdateStateModel(stateModel);
                TempData["StateSuccessUpdate"] = "Record Update SuccessFull";
            }
            return RedirectToAction("Index");

        }



        [HttpGet]

        public IActionResult StateDelete(int id)


        {
            if(id !=null)
            {
                stateDataAccess.DeleteStateById(id);
                TempData["StateSuccessDelete"] = "Record Update Successfuy";
            }
            return RedirectToAction("Index");
        }







        public IActionResult Privacy()
        {
            return View();
        }





        //=======================================Details





        public IActionResult Details(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            StateModel stateModel = new StateModel();

            return View(stateDataAccess.GetStateById(id));

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult CityCreate()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult CityCreate(StateModel cityModel)

        //{
        //    if (cityModel != null)
        //    {
        //        cityDataAccess.InsertCityModel(cityModel);
        //        TempData["CitySuccess"] = "Record Insert";
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
