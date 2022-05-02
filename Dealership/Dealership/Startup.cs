using Dealership.Controllers;
using Dealership.Data_Access;
using Dealership.Helpers;
using Dealership.Interfaces;
using Dealership.Providers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dealership.Startup))]
namespace Dealership
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}