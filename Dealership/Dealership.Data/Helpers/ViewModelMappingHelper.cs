using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dealership.Helpers
{
    public static class ViewModelMappingHelper
    {
        public static T Parse<T>(SqlDataReader reader, string columnName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return (T)reader[columnName];
            }

            return default(T);
        }
    }
}