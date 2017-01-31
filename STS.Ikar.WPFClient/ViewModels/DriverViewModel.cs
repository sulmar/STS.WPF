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
    public class DriverViewModel : BaseViewModel
    {
        public Driver Driver { get; set; }

        public DateTime CurrentDate { get; set; }

        private IDriversService _DriversService;

        public DriverViewModel(IDriversService driversService)
        {
            this._DriversService = driversService;

            Load();
        }

        public DriverViewModel()
         : this(new MockDriversService())
        {

        }

        public void Load()
        {
            Driver = _DriversService.Get(1);
            CurrentDate = DateTime.Now;
        }
    }
}
