using STS.Ikar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.DAL.Configurations
{
    public class CMRConfiguration : EntityTypeConfiguration<CMR>
    {
        public CMRConfiguration()
        {
            Property(p => p.Number)
               .HasMaxLength(20)
               .IsUnicode(false);

            Property(p => p.CreateDate)
                .HasColumnType("datetime2");

        }
    }
}
