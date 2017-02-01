using STS.Ikar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Ikar.Models;
using System.Data.Entity;

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

        public async Task AddAsync(Driver driver)
        {
            using (var context = new IkarContext())
            {
                context.Drivers.Add(driver);

                System.Diagnostics.Debug.WriteLine(context.Entry(driver).State);

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Driver driver)
        {
            using (var context = new IkarContext())
            {
                context.Drivers.Remove(driver);

                await context.SaveChangesAsync();
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

        public async Task<IList<Driver>> GetAsync()
        {
            using (var context = new IkarContext())
            {
                return await context.Drivers.ToListAsync();
            }
        }

        public async Task<Driver> GetAsync(int id)
        {
            using (var context = new IkarContext())
            {
                return await context.Drivers
                    .SingleOrDefaultAsync(d => d.DriverId == id);
            }
        }

        public void Update(Driver driver)
        {
            using (var context = new IkarContext())
            {
                context.SaveChanges();
            }
        }

        public async Task UpdateAsync(Driver driver)
        {
            using (var context = new IkarContext())
            {
              //  context.Drivers.Attach(driver);

                context.Entry(driver).State = EntityState.Modified;

                System.Diagnostics.Debug.WriteLine(context.Entry(driver).State);

                await context.SaveChangesAsync();
            }
        }
    }
}
