using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Interfaces
{
    public interface IContactRequestProvider
    {
        void SubmitRequest(ContactRequest request);
    }
}