using STS.Ikar.DAL;
using STS.Ikar.Interfaces;
using STS.Ikar.MockServices;
using STS.Ikar.Models;
using STS.Ikar.WPFClient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STS.Ikar.WPFClient.ViewModels
{
    public class DriverViewModel : BaseViewModel
    {
        private Driver _Driver;

        public Driver Driver
        {
            get { return _Driver; }
            set { _Driver = value;
                OnPropertyChanged();
            }
        }


        public DateTime CurrentDate { get; set; }

        private IDriversService _DriversService;

        public DriverViewModel(IDriversService driversService)
        {
            this._DriversService = driversService;

            Load();
        }

        public DriverViewModel()
         : this(new DbDriversService())
        {

        }

        public void Load()
        {
            // Driver = _DriversService.Get(5);

             Driver = new Driver { Birthday = DateTime.Today };

            CurrentDate = DateTime.Now;

        }


        public void Cancel()
        {

        }


        #region SaveCommand


        private ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand==null)
                {
                    _SaveCommand = new RelayCommand(() => SaveAsync(), () => CanSave);
                }

                return _SaveCommand;
            }
        }


        public Task<string> UpdateFirstNameAsync()
        {
            return Task.Run(() => UpdateFirstName());
        }

        public Task<string> UpdateLastNameAsync()
        {
            return Task.Run(() => UpdateLastName());
        }


        public string UpdateFirstName()
        {
            Thread.Sleep(7000);

            this.Driver.FirstName = "Ala";

            return "Zmiana imienia";
        }

        public string UpdateLastName()
        {
            Thread.Sleep(4000);

            this.Driver.LastName = "MaKota";

            return "Zmiana nazwiska";
        }

        public void Save()
        {
            var result = UpdateFirstName();

            result += UpdateLastName();
        }



        public void SaveAsync2()
        {
            UpdateFirstNameAsync()
                .ContinueWith(result=> UpdateLastNameAsync());
        }

        public async Task SaveAsync()
        {
            await _DriversService.AddAsync(Driver);
        }


        public async Task UpdateAsync()
        {
            await _DriversService.UpdateAsync(Driver);
        }

        public bool CanSave => Driver.IsValid;

        #endregion
    }
}
