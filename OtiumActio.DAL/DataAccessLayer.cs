using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OtiumActio.Models;

namespace OtiumActio.DAL
{
    public class DataAccessLayer : IDataAccessLayer
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
                    //var catName = Enum.GetNames(typeof(Category));
                    //var catId = Enum.GetValues(typeof(Category));
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
        public IEnumerable<Activity> Activities
        {
            get
            {
                string connectionString = GetSrting();
                List<Activity> activities = new List<Activity>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllActivities", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //var catName = Enum.GetNames(typeof(Category));
                    //var catId = Enum.GetValues(typeof(Category));
                    while (rdr.Read())
                    {
                        Activity activity = new Activity();
                        activity.Id = Convert.ToInt32(rdr["Ac_Id"]);
                        activity.Description = rdr["Ac_Description"].ToString();
                        var categoryId = Convert.ToInt32(rdr["Ac_CategoryId"]);
                        var categoryName = CategoryName(categoryId);
                        activity.Categories.Name = categoryName;

                        activity.Date = (DateTime)rdr["Ac_Date"];
                        activity.Participants = Convert.ToInt32(rdr["Ac_Participants"]);
                        activities.Add(activity);
                    }
                }
                return activities;
            }
        }
        public string CategoryName(int catId)
        {
                string connectionString = GetSrting();
            //List<Activity> activities = new List<Activity>();
            Category category = new Category();

            using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCategoryName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@categoryId", catId);

                SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        category.Id = Convert.ToInt32(rdr["Cat_Id"]);
                        category.Name = rdr["Cat_Name"].ToString();
                    }
                }
                return category.Name;
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
                    //cmd.Parameters.AddWithValue("@id", activity.Id);
                    cmd.Parameters.AddWithValue("@category", activity.Category);
                    cmd.Parameters.AddWithValue("@description", activity.Description);
                    cmd.Parameters.AddWithValue("@participants", activity.Participants);
                    cmd.Parameters.AddWithValue("@date", activity.Date);
                    //AddActivityCategory(activity);
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
        //public string AddActivityCategory(Activity activity)
        //{
        //    string connectionString = GetSrting();
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand("UpdateActCat", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@activity", activity.Id);
        //            cmd.Parameters.AddWithValue("@category", activity.Category);

        //            cmd.ExecuteNonQuery();
        //            return null; // success   
        //        }
        //        catch (Exception ex)
        //        {
        //            return ex.Message; // return error message  
        //        }

        //    }
        //}
        public static string DeleteActivity(int id)
        {
            string connectionString = GetSrting();
            using (SqlConnection con = new SqlConnection(connectionString)) { 
                try
                {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteActivity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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
        public static string GetSrting() => ConnectionStringSetting.GetConnectionString();
    }
}
