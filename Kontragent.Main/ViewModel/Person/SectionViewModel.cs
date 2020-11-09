using Kontragent.RiskInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Person
{
   public class SectionViewModel : BaseViewModel, IRiskParametr
    {

        private string _nameSection;
        public string NameSection
        {
            get { return _nameSection; }
            set
            {
                _nameSection = value;
                OnPropertyChanged(nameof(NameSection));
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
