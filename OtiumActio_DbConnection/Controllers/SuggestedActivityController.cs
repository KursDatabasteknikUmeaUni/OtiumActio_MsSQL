using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtiumActio.DAL;
using OtiumActio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OtiumActio.Controllers
{
    public class SuggestedActivityController : Controller
    {
        private static List<ActivityViewModel> ListOfAllActivities = new List<ActivityViewModel>();
        //private readonly DataAccessLayer _dataAccess;
        //public SuggestedActivityController(DataAccessLayer dataAccess)
        //{
        //    _dataAccess = dataAccess;
        //}
        public IActionResult Index()
        {
            DataAccessLayer adl = new DataAccessLayer();
            var allCategories = adl.Categories.ToList();
            List<SelectListItem> categories = new List<SelectListItem>();
            foreach (var category in allCategories)
            {
                categories.Add(new SelectListItem { Text = category.Name.ToString(), Value = category.Id.ToString() });
            }
            ViewData["SelectableCategories"] = categories;

            return View("SuggestedActivity");
        }
        [HttpPost]
        public IActionResult AddNewActivity(ActivityViewModel model)
        {
            //model.Categories.ToString().Trim('"');
            //try
            //{
            //   // ListOfAllActivities.Add(new ActivityViewModel { Id = 1, Category = (Enum.GetName(typeof(Category), model.Categories)), Description = model.Description, Participants = model.Participants, Date = model.Date });
            //    TempData["Success"] = "Tack! Aktiviteten skapades.";
            //}
            //catch (Exception)
            //{
            //    //TempData["Success"] = new Exception();
            //}
            //return RedirectToAction("Index");
            DataAccessLayer adl = new DataAccessLayer();
            //var catId = (Enum.GetName(typeof(Enums.Category), model.Categories));
           // var catId = ()
            var activity = new Activity
            {
                //Id = 6,
                Category = (int)model.Category, 
                Description = model.Description,
                Participants = model.Participants,
                Date = model.Date

            };
            adl.AddActivity(activity);
            var allCategories = adl.Categories.ToList();
            List<SelectListItem> categories = new List<SelectListItem>();
            foreach (var category in allCategories)
            {
                categories.Add(new SelectListItem { Text = category.Name.ToString(), Value = category.Id.ToString() });
            }
            ViewData["SelectableCategories"] = categories;

            return View("SuggestedActivity");
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

