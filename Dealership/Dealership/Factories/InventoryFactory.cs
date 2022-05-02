using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dealership.Data_Access;
using Dealership.Interfaces;
using Dealership.Providers;

namespace Dealership.Factories
{
    public static class InventoryFactory
    {
        public static IInventoryProvider CreateInventoryProvider()
        {
            return new InventoryProvider(CreateInventoryDAL());
        }

        public static IInventoryDAL CreateInventoryDAL()
        {
            return new InventoryDAL();
        }
    }
}