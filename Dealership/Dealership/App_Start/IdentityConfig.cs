using Dealership.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new GuildCarsDbContext());

            app.CreatePerOwinContext<UserManager<AppUser>>((options, context) =>
                new UserManager<AppUser>(
                    new UserStore<AppUser>(context.Get<GuildCarsDbContext>())));

            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<GuildCarsDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}