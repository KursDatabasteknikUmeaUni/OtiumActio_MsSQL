using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using OtiumActio.Models;

namespace OtiumActio.DAL
{
    public class Activity_DL
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                string connectionString = ConnectionStringSetting.GetConnectionString();
                    //ConfigurationManager.ConnectionStrings["OtiumActio"].ConnectionString;
                List<Category> categories = new List<Category>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllCategories", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Category category = new Category();
                        category.Id = Convert.ToInt32(rdr["Id"]);
                        category.Name = rdr["Name"].ToString();
                        categories.Add(category);
                    }
                }
                return categories;
            }
        }
    }
}
