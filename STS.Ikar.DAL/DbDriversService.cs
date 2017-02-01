using STS.Ikar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Ikar.Models;

namespace STS.Ikar.DAL
{
    public class DbDriversService : IDriversService
    {


        public void Add(Driver driver)
        {
            using (var context = new IkarContext())
            {
                context.Drivers.Add(driver);

                context.SaveChanges();
            }
        }

        public IList<Driver> Get()
        {
            using (var context = new IkarContext())
            {
                return context.Drivers.ToList();
            }
        }

        public Driver Get(int id)
        {
            using (var context = new IkarContext())
            {
                return context.Drivers.SingleOrDefault(d => d.DriverId == id);
            }
        }

        public void Update(Driver driver)
        {
            using (var context = new IkarContext())
            {
                context.SaveChanges();
            }
        }

        
    }
}
