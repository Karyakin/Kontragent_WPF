using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Autofill
{
    public class AutoFillViewModelPers : BaseViewModel
    {
        private string _ownerName;
        private string _headName;
        private string _countryPers;

        public string OwnerName
        {
            get => _ownerName;
            set
            {
                _ownerName = value;
                OnPropertyChanged(nameof(OwnerName));
            }
        }
        public string HeadName
        {
            get => _headName;
            set
            {
                _headName = value;
                OnPropertyChanged(nameof(HeadName));
            }
        }

        public string CountryPers
        {
            get => _countryPers;
            set
            {
                _countryPers = value;
                OnPropertyChanged(nameof(CountryPers));
            }
        }

    }
}
