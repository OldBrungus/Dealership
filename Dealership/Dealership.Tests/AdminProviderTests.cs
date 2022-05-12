using Dealership.Factories;
using Dealership.Interfaces;
using Dealership.Models;
using Dealership.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Tests
{
    [TestFixture]
    internal class AdminProviderTests
    {
        [Test]
        public void AddModelTest()
        {
            string modelName = "Canyon";
            int makeID = 0;
            string userName = "admin";

            IAdminProvider adminProvider = AdminFactory.CreateAdminProvider();

            Assert.Throws<SqlException>(() => adminProvider.AddModel(modelName, makeID, userName));
        }
    }
}
