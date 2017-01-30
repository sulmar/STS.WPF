using STS.Ikar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Ikar.Models;

namespace STS.Ikar.MockServices
{
    public class MockDriversService : IDriversService
    {
        private static IList<Driver> drivers = new List<Driver>
        {
            new Driver
            {
                DriverId = 1,
                FirstName = "Marcin",
                LastName = "Sulecki",
                NumberId = "539875423",
                Phone = "609-851-649",
            },

            new Driver
            {
                DriverId = 2,
                FirstName = "Bartosz",
                LastName = "Sulecki",
                NumberId = "5747474",
                Phone = "555-000-444",
            },

            new Driver
            {
                DriverId = 3,
                FirstName = "Kasia",
                LastName = "Sulecka",
                NumberId = "5757565",
                Phone = "555-111-222",
            },

        };

        public void Add(Driver driver)
        {
            var maxId = drivers.Max(d => d.DriverId);

            maxId++;

            driver.DriverId = maxId;

            drivers.Add(driver);
        }

        public IList<Driver> Get()
        {
            return drivers;
        }

        public void Update(Driver driver)
        {
            throw new NotSupportedException();
        }


        public void Delete(int driverId)
        {
            throw new NotSupportedException();
        }
    }
}
