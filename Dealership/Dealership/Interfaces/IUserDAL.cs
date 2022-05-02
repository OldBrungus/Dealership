using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Interfaces
{
    public interface IUserDAL
    {
        void AddUserToDb(AddEditUserViewModel userVM, AppUser user);
        AddEditUserViewModel GetUserByID(Guid userID);
        void UpdateUser(AddEditUserViewModel userVM);
    }
}
