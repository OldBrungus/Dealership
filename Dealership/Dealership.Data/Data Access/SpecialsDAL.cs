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
    public class SpecialsDAL : ISpecialsDAL
    {
        public List<Special> GetSpecials()
        {
            List<Special> specials = new List<Special>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.GetSpecials";
            cmd.CommandType = CommandType.StoredProcedure;
            
            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Special special = new Special();

                        special.SpecialTitle = ViewModelMappingHelper.Parse<string>(reader, "Title");
                        special.SpecialID = ViewModelMappingHelper.Parse<int>(reader, "ID");
                        special.Description = ViewModelMappingHelper.Parse<string>(reader, "Description");
                        
                        specials.Add(special);
                    }
                }
            }
            return specials;
        }

        public void AddSpecial(Special special)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AddSpecial";
            cmd.Parameters.AddWithValue("@title", special.SpecialTitle);
            cmd.Parameters.AddWithValue("@description", special.Description);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSpecial(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.DeleteSpecial";
            cmd.Parameters.AddWithValue("@id", id);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}