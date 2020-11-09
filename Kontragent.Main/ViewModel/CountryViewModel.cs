using Kontragent.RiskInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel
{
    public class CountryViewModel : BaseViewModel, IRiskParametr
    {
        private string _nameCountry;
        public string NameCountry
        {
            get { return _nameCountry; }
            set
            {
                _nameCountry = value;
                OnPropertyChanged(nameof(NameCountry));
            }
        }

        private int _risk;
        public int Risk
        {
            get { return _risk; }
            set
            {
                _risk = value;
                OnPropertyChanged(nameof(Risk));
            }
        }


    }
}
