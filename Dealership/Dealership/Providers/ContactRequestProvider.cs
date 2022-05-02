using Dealership.Interfaces;
using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Providers
{
    public class ContactRequestProvider : IContactRequestProvider
    {
        private IContactRequestDAL _contactRequestDAL;

        public ContactRequestProvider(IContactRequestDAL contactRequestDAL)
        {
            _contactRequestDAL = contactRequestDAL;
        }
        public void SubmitRequest(ContactRequest request)
        {
            _contactRequestDAL.SubmitRequest(request);
        }
    }
}