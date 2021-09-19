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
                string connectionString = GetSrting();
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
                        category.Id = Convert.ToInt32(rdr["Cat_Id"]);
                        category.Name = rdr["Cat_Name"].ToString();
                        categories.Add(category);
                    }
                }
                return categories;
            }
        }

        public string AddActivity(Activity activity) //int id, int category, string description, int participant, DateTime date
        {
            string connectionString = GetSrting();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("AddActivityUpdateActCat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", activity.Id);
                    cmd.Parameters.AddWithValue("@category", activity.Category);
                    cmd.Parameters.AddWithValue("@description", activity.Description);
                    cmd.Parameters.AddWithValue("@participants", activity.Participants);
                    cmd.Parameters.AddWithValue("@date", activity.Date);
                    AddActivityCategory(activity);
                    cmd.ExecuteNonQuery();
                    return null; // success   
                }
                catch (Exception ex)
                {
                    return ex.Message; // return error message  
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public string AddActivityCategory(Activity activity)
        {
            string connectionString = GetSrting();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateActCat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@activity", activity.Id);
                    cmd.Parameters.AddWithValue("@category", activity.Category);

                    cmd.ExecuteNonQuery();
                    return null; // success   
                }
                catch (Exception ex)
                {
                    return ex.Message; // return error message  
                }

            }
        }
            public static string GetSrting() => ConnectionStringSetting.GetConnectionString();
    }
}
