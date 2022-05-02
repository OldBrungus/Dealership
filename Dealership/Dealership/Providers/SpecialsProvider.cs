using Dealership.Interfaces;
using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Providers
{
    public class SpecialsProvider : ISpecialsProvider
    {
        private ISpecialsDAL _specialsDAL;

        public SpecialsProvider(ISpecialsDAL specialsDAL)
        {
            _specialsDAL = specialsDAL;
        }

        public List<Special> GetSpecials()
        {
            return _specialsDAL.GetSpecials();
        }

        public void AddSpecial(Special special)
        {
            _specialsDAL.AddSpecial(special);
        }

        public void DeleteSpecial(int id)
        {
            _specialsDAL.DeleteSpecial(id);
        }
    }
}