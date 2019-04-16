using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Sandeeptest.Models;

namespace Sandeeptest.DAL
{
    public class UserDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
        internal List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_COUNTRIES";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Country country = new Country();
                        country.CountryName = dr["CountryName"].ToString();
                        country.CountryId = Convert.ToInt32(dr["CountryId"]);
                        countries.Add(country);
                    }
                }

            }
            return countries;
        }

        internal int DeleteUserById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_USERS_BY_ID";
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
               return cmd.ExecuteNonQuery();
            }
        }

        internal bool CheckEmailInDataBase(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               
                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Test_Sandeep] WHERE ([Email] = @Email)", con);
                check_User_Name.Parameters.AddWithValue("@Email", email);
                con.Open();
                int UserExist = (int)check_User_Name.ExecuteScalar();

                if (UserExist > 0)
                {
                   return true;
                }
                else
                {
                   return false;
                }
            }
        }

        internal User GetUserById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                User user = new User();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_USERS_BY_ID";
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user.Id = Convert.ToInt32(dr["Id"]);
                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.Email = dr["Email"].ToString();
                        user.CityId =Convert.ToInt32(dr["CityId"]);
                        user.CountryId = Convert.ToInt32(dr["CountryId"]);

                    }
                }
                return user;
            }
        }

        internal List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_USERS";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(dr["Id"]);
                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.Email = dr["Email"].ToString();
                        user.CityName = dr["CityName"].ToString();
                        user.CountryName = dr["CountryName"].ToString();
                        users.Add(user);
                    }
                }

            }
            return users;
        }

        internal int CreateUser(DataTable dt)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USER_INSERT_UPDATE";
                cmd.Parameters.AddWithValue("@UserListTable", dt);
                con.Open();
                return cmd.ExecuteNonQuery();

            }
        }

        internal List<City> GetCitiesByCountryId(int countryId)
        {
            List<City> cities = new List<City>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_CITIES";
                cmd.Parameters.AddWithValue("@CountryId", countryId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        City city = new City();
                        city.CityName = dr["CityName"].ToString();
                        city.CityId = Convert.ToInt32(dr["CityId"]);
                        cities.Add(city);
                    }
                }

            }
            return cities;
        }
    }
}