using STS.Ikar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.DAL.Configurations
{
    public class TruckConfiguration : EntityTypeConfiguration<Truck>
    {
        public TruckConfiguration()
        {
               Property(p => p.Color)
               .HasMaxLength(10)
               .IsRequired();
        }
    }
}
