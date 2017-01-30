using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{
    public class WarehouseDocument : Base
    {
        public int WarehouseDocumentId { get; set; }

        public string Number { get; set; }

        public Vehicle Vehicle { get; set; }

        public DocumentType DocumentType { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ConfirmDate { get; set; }
    }
}
