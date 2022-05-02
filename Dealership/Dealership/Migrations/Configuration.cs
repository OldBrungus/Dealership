namespace Dealership.Migrations
{
    using Dealership.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCarsDbContext context)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new AppRole() { Name = "admin" });

                var user = new AppUser()
                {
                    UserName = "admin"
                };

                userMgr.Create(user, "Testing123!");

                userMgr.AddToRole(user.Id, "admin");
            }

            if (!roleMgr.RoleExists("sales"))
            {
                roleMgr.Create(new AppRole() { Name = "sales" });

                var user1 = new AppUser()
                {
                    UserName = "sales"
                };

                userMgr.Create(user1, "Sales123!");

                userMgr.AddToRole(user1.Id, "sales");
            }

        }
    }
}
