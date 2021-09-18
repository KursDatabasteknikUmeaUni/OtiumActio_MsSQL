using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtiumActio.Enums;
using OtiumActio.Helpers;
using OtiumActio.Models;
using OtiumActio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OtiumActio.Controllers
{
    public class SuggestedActivityController : Controller
    {
        private static List<ActivityViewModel> ListOfAllActivities = new List<ActivityViewModel>();
        public IActionResult Index()
        {
            var categories = new List<SelectListItem>()
            {
               new SelectListItem{ Text= Enums.Category.Naturvanrding.ToString(), Value = "1" },
               new SelectListItem{ Text= Enums.Category.Idrott.ToString(), Value = "2" },
               new SelectListItem{ Text= Enums.Category.Bio.ToString(), Value = "3" },
               new SelectListItem{ Text= Enums.Category.Matlagning.ToString(), Value = "4" },
               };
            ViewData["SelectableCategories"] = categories;
            return View("SuggestedActivity");
        }
        [HttpPost]
        public IActionResult AddNewActivity(ActivityViewModel model)
        {
            model.Categories.ToString().Trim('"');
            try
            {
               // ListOfAllActivities.Add(new ActivityViewModel { Id = 1, Category = (Enum.GetName(typeof(Category), model.Categories)), Description = model.Description, Participants = model.Participants, Date = model.Date });
                TempData["Success"] = "Tack! Aktiviteten skapades.";
            }
            catch (Exception)
            {
                //TempData["Success"] = new Exception();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult GetAllActivities()
        {
            Response.Cookies.Append("Cookie", "listFetched");
            return PartialView("_addedActivities", ListOfAllActivities);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            try
            {
                ListOfAllActivities.Remove(ListOfAllActivities.Where(l => l.Id == id).FirstOrDefault());
                TempData["Deleted"] = "Aktiviteten togs bort.";

            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public string Get(string key)
        {
            return Request.Cookies[key];
        }
    }
}

