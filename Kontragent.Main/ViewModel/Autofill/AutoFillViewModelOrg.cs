using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Autofill
{
   public class AutoFillViewModelOrg : BaseViewModel
    {
        private string _shortNameOrg;
        private string _fullNameOrg;
        private DateTime _createDateOrg;
        private string _countryOrg;
        private string _nameSection;

        public string ShortNameOrg
        {
            get => _shortNameOrg;
            set
            {
                _shortNameOrg = value;
                OnPropertyChanged(nameof(ShortNameOrg));
            }
        }

        public string FullNameOrg
        {
            get => _fullNameOrg;
            set
            {
                _fullNameOrg = value;
                OnPropertyChanged(nameof(FullNameOrg));
            }
        }
        public DateTime CreateDateOrg
        {
            get => _createDateOrg;
            set
            {
                _createDateOrg = value;
                OnPropertyChanged(nameof(CreateDateOrg));
            }
        }

        public string CountryOrg
        {
            get => _countryOrg;
            set
            {
                _countryOrg = value;
                OnPropertyChanged(nameof(CountryOrg));
            }

        }


        public string NameSection
        {
            get => _nameSection;
            set
            {
                _nameSection = value;
                OnPropertyChanged(nameof(NameSection));
            }
        }

    }
}
