using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Interfaces
{
    public interface ISpecialsDAL
    {
        List<Special> GetSpecials();
        void AddSpecial(Special special);
        void DeleteSpecial(int id);
    }
}
