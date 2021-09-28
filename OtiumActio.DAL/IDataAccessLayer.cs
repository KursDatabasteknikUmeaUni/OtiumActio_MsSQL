using OtiumActio.Models;
using System.Collections.Generic;

namespace OtiumActio.DAL
{
    public interface IDataAccessLayer
    {
        IEnumerable<Category> Categories { get; }

        string AddActivity(Activity activity);
        //string AddActivityCategory(Activity activity);
    }
}