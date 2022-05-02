using Dealership.Data_Access;
using Dealership.Interfaces;
using Dealership.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Factories
{
    public class AdminFactory
    {
        public static IAdminProvider CreateAdminProvider()
        {
            return new AdminProvider(CreateInventoryDAL(), CreateUserDAL());
        }

        private static IUserDAL CreateUserDAL()
        {
            return new UserDAL();
        }

        public static IInventoryDAL CreateInventoryDAL()
        {
            return new InventoryDAL();
        }
    }
}