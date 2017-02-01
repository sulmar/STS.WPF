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

        Driver Get(int id);

        void Add(Driver driver);

        void Update(Driver driver);


        Task AddAsync(Driver driver);

        Task<IList<Driver>> GetAsync();

        Task<Driver> GetAsync(int id);

        Task UpdateAsync(Driver driver);

        Task DeleteAsync(Driver driver);
    }
}
