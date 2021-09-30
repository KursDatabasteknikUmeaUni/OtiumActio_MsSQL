using Microsoft.AspNetCore.Mvc;
using OtiumActio.Models;
using System.Collections.Generic;
using OtiumActio.Helpers;
using OtiumActio.DAL;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtiumActio.Interfaces;

namespace OtiumActio.Controllers
{
    public class ActivityController : Controller
    {
        private IEditActivityController _service;
        public ActivityController(IEditActivityController service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            DataAccessLayer adl = new DataAccessLayer();
            var allActivities = adl.Activities.ToList();
            return View("Activity", allActivities);
        }
        public IActionResult Delete(Activity activity)
        {
            DataAccessLayer adl = new DataAccessLayer();
            try
            {
                adl.DeleteActivity(activity.Id);
                TempData["Success"] = "Aktiviteten tas bort!";
            }
            catch (System.Exception)
            {
                ViewData["Error"] = "Oops! Försök igen senare!";
            }
            return View("_successMessage");
        }
        public void Update(Activity activity)
        {
            ///Activity/Update/30
            _service.Edit(activity.Id);
        }
    }
}
