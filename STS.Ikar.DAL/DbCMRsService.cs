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
    public class DbCMRsService : ICMRsService
    {
        public async Task AddAsync(CMR cmr)
        {
            using (var context = new IkarContext())
            {
                context.CMRs.Add(cmr);

                await context.SaveChangesAsync();
            }
        }

        public async Task<CMR> GetAsync(int id)
        {
            using (var context = new IkarContext())
            {
                var cmr = await context.CMRs
                    .SingleOrDefaultAsync(s => s.CMRId == id);

                // Pobieranie wskazanej kolekcji
                await context.Entry(cmr).Collection(p => p.WarehouseDocuments).LoadAsync();

                await context.Entry(cmr).Reference(p => p.ArrivalAddress).LoadAsync();
                await context.Entry(cmr).Reference(p => p.DeliveryAddress).LoadAsync();

                // Pobranie wskaznej właściwości
                await context.Entry(cmr).Reference(p => p.Truck).LoadAsync();

                // Zachłanne pobieranie 
                //var cmr = await context.CMRs
                //    .Include(p=>p.Truck)
                //    .Include(p=>p.Driver)
                //    .Include(p=>p.WarehouseDocuments.Select(x=>x.Vehicle))
                //    .SingleOrDefaultAsync(s => s.CMRId == id);

                return cmr;
            }
        }
    }
}
