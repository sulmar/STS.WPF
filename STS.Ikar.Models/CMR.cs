using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{
    public class CMR : Base
    {
        public int CMRId { get; set; }

        public string Number { get; set; }

        public Truck Truck { get; set; }

        public Driver Driver { get; set; }

        public string ArrivalAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? PickupDate { get; set; }

        public DateTime? DeliveryDate { get; set; }



        public IList<WarehouseDocument> WarehouseDocuments { get; set; }
    }
}
