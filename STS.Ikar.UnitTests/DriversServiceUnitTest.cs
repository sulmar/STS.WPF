using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using STS.Ikar.Interfaces;
using STS.Ikar.MockServices;
using STS.Ikar.DAL;
using STS.Ikar.Models;

namespace STS.Ikar.UnitTests
{
    [TestClass]
    public class DriversServiceUnitTest
    {
        IDriversService driversService;

        [TestInitialize]
        public void Init()
        {
             driversService = new MockDriversService();
        }

        [TestMethod]
        public void GetTest()
        {
            var drivers = driversService.Get();

            Assert.IsNotNull(drivers);

            Assert.IsTrue(drivers.Any());

        }

        [TestMethod]
        public void AddTest()
        {
            // dane wejściowe 
            var driver = new Driver
            {
                FirstName = "Jan",
                LastName = "Nowak",
                Phone = "555-343-229",
                NumberId = "ALB443224"
            };


            // operacja
            driversService.Add(driver);

            var drivers = driversService.Get();

            var existsDriver = drivers
                .Where(d => d.FirstName == driver.FirstName)
                .Where(d => d.LastName == driver.LastName)
                .Where(d => d.Phone == driver.Phone)
                .Where(d => d.NumberId == driver.NumberId)
                .Any();

            // sprawdzenie 

            Assert.IsTrue(existsDriver, "Nie istnieje kierowca");

            Assert.IsTrue(drivers.All(d => d.DriverId > 0), "DriverId jest równy 0");



        }
    }
}
