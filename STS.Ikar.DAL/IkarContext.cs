using STS.Ikar.DAL.Configurations;
using STS.Ikar.DAL.Conventions;
using STS.Ikar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.DAL
{
    public class IkarContext  : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CMR> CMRs { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<WarehouseDocument> WarehouseDocuments { get; set; }


        public IkarContext()
            : base("IkarConnection")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = true;

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new TruckConfiguration())
                .Add(new CMRConfiguration());

            modelBuilder.Conventions
                .Add(new DateTime2Convention());

            base.OnModelCreating(modelBuilder);
        }
    }
}
