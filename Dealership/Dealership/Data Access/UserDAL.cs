using Dealership.Helpers;
using Dealership.Interfaces;
using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dealership.Data_Access
{
    public class UserDAL :IUserDAL
    {
        public void AddUserToDb(AddEditUserViewModel userVM, AppUser user)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AddUserToDb";
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@firstName", userVM.FirstName);
            cmd.Parameters.AddWithValue("@lastName", userVM.LastName);
            cmd.Parameters.AddWithValue("@email", userVM.Email);
            cmd.Parameters.AddWithValue("@roleName", userVM.RoleName);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public AddEditUserViewModel GetUserByID(Guid userID)
        {
            AddEditUserViewModel userVM = new AddEditUserViewModel();
            userVM.ID = userID;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetUserByID";
            cmd.Parameters.AddWithValue("@userID", userID);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open ();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userVM.FirstName = ViewModelMappingHelper.Parse<string>(reader, "FirstName");
                        userVM.LastName = ViewModelMappingHelper.Parse<string>(reader, "LastName");
                        userVM.Email = ViewModelMappingHelper.Parse<string>(reader, "Email");
                        userVM.RoleName = ViewModelMappingHelper.Parse<string>(reader, "RoleName");
                    }
                }
            }

            return userVM;
        }

        public void UpdateUser(AddEditUserViewModel userVM)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "dbo.UpdateUser";
            cmd.Parameters.AddWithValue("userID", userVM.ID);
            cmd.Parameters.AddWithValue("@firstName", userVM.FirstName);
            cmd.Parameters.AddWithValue("@lastName", userVM.LastName);
            cmd.Parameters.AddWithValue("@email", userVM.Email);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}