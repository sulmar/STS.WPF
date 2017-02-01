using STS.Ikar.DAL;
using STS.Ikar.Interfaces;
using STS.Ikar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.WPFClient.ViewModels
{
    public class CMRViewModel : BaseViewModel
    {

        private CMR _CMR;

        public CMR CMR
        {
            get { return _CMR; }
            set { _CMR = value;
                OnPropertyChanged();
            }
        }

        private ICMRsService _CMRsService;

        public CMRViewModel(ICMRsService cmrsService)
        {
            this._CMRsService = cmrsService;
        }

        public CMRViewModel()
         : this(new DbCMRsService())
        {

        }

        public async Task Load()
        {
            CMR = await _CMRsService.GetAsync(1);
        }
    }
}
