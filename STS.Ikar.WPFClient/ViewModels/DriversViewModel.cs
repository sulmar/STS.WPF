using STS.Ikar.Interfaces;
using STS.Ikar.MockServices;
using STS.Ikar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.WPFClient.ViewModels
{
    public class DriversViewModel : BaseViewModel
    {
        public IList<Driver> Drivers { get; set; }

        public Driver SelectedDriver { get; set; }

        private IDriversService _DriversService;

        public DriversViewModel()
            : this(new MockDriversService())
        {

        }
        
        public DriversViewModel(IDriversService driversService)
        {
            _DriversService = driversService;

            Load();
        }

        private void Load()
        {
            Drivers = _DriversService.Get();
        }
    }
}
