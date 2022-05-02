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
    public class ContactRequestDAL : IContactRequestDAL
    {
        public void SubmitRequest(ContactRequest request)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.SubmitRequest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", request.Name);
            cmd.Parameters.AddWithValue("@email", request.Email);
            cmd.Parameters.AddWithValue("@message", request.Message);
            cmd.Parameters.AddWithValue("@phoneNumber", request.PhoneNumber);

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }    
        }
    }
}