using Microsoft.AspNetCore.Mvc;
using OtiumActio.ViewModels;
using System.Collections.Generic;
using OtiumActio.Helpers;
using OtiumActio.Models;

namespace OtiumActio.Controllers
{
    public class ActivityController : Controller
    {
        private static List<Activity> ListOfAllActivities = new List<Activity>();
        public IActionResult Index()
        {
            SeedData sd = new SeedData();
            ListOfAllActivities = sd.GetListOfHardcodedActivities(ListOfAllActivities);
            List<ActivityViewModel> viewModel = new List<ActivityViewModel>();
                foreach (var list in ListOfAllActivities)
                {
                viewModel.Add(new ActivityViewModel { 
                    //Category = Category, 
                    Description = list.Description, 
                    Participants = list.Participants, 
                    Date = list.Date });
                };
            ViewBag.ActivitiesList = viewModel;

            return View("Activity");
        }
    }
}
