using Dealership.Data_Access;
using Dealership.Interfaces;
using Dealership.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Factories
{
    public static class ContactFactory
    {
        public static IContactRequestProvider CreateContactRequestProvider()
        {
            return new ContactRequestProvider(CreateContactRequestDAL());
        }
        public static IContactRequestDAL CreateContactRequestDAL()
        {
            return new ContactRequestDAL();
        }
    }
}