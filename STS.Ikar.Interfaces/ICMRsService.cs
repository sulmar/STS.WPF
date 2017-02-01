using STS.Ikar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Interfaces
{
    public interface ICMRsService
    {
        Task AddAsync(CMR cmr);

        Task<CMR> GetAsync(int id);

    }
}
