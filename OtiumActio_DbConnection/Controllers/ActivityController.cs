using Microsoft.AspNetCore.Mvc;
using OtiumActio.Models;
using System.Collections.Generic;
using OtiumActio.Helpers;
using OtiumActio.DAL;
using System.Linq;

namespace OtiumActio.Controllers
{
    public class ActivityController : Controller
    {
        //private static List<Activity> ListOfAllActivities = new List<Activity>();
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
            return PartialView("_successMessage");
        }
    }
}
