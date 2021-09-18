using System;
using System.Collections.Generic;
using OtiumActio.Enums;
using OtiumActio.Models;
using Category = OtiumActio.Enums.Category;

namespace OtiumActio.Helpers
{
    public class SeedData
    {
        public List<Activity> GetListOfHardcodedActivities(List<Activity> list)
        {
            list = new List<Activity>()
            {
                new Activity { Category = (long)Category.Naturvanrding, 
                    Description = "Göteborg. Träffpunkt: Ruddalen entre", 
                    Participants = 3, 
                    Date = FormatDateTime(7) },
                new Activity { Category = (long)Category.Idrott, 
                    Description = "Borås. Träffpunkt: Central station", 
                    Participants = 8, 
                    Date = FormatDateTime(10) },
                new Activity { Category = (long)Category.Bio, 
                    Description = "Göteborg. Träffpunkt: HagaBion.", 
                    Participants = 2, 
                    Date = FormatDateTime(3) },
            };
            return list;

        }
        public DateTime FormatDateTime(int days)
        {
            var unformatted = DateTime.Today.AddDays(days);
            var formattedDate = unformatted.Date;
            return formattedDate;
        }
    }
}
