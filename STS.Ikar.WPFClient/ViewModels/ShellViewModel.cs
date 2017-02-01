using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.WPFClient.ViewModels
{

    public class ShellViewModel : BaseViewModel 
    {

        private BaseViewModel _CurrentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { _CurrentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ShellViewModel()
        {
            CurrentViewModel = new DriversViewModel();
        }


        public void Navigate()
        {
            var vm = new DriverViewModel();

            vm.Driver = new Models.Driver { FirstName = "Marcin" };

            CurrentViewModel = vm;
        }
    }
}
