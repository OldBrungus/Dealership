using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class GuildCarsDbContext : IdentityDbContext<AppUser>
    {
        public GuildCarsDbContext() : base("GuildCars")
        {

        }
    }
}