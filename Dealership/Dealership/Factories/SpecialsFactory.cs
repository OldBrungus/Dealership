using Dealership.Data_Access;
using Dealership.Interfaces;
using Dealership.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Factories
{
    public static class SpecialsFactory
    {
        public static ISpecialsProvider GetSpecialsProvider()
        {
            return new SpecialsProvider(GetSpecialsDAL());
        }

        public static ISpecialsDAL GetSpecialsDAL()
        {
            return new SpecialsDAL();
        }
    }
}