using STS.Ikar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Interfaces
{
    public interface IDriversService
    {
        IList<Driver> Get();

        void Add(Driver driver);

        void Update(Driver driver);
    }
}
