using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Autofill
{
   public class AutoFillKontragentViewModel : BaseViewModel
    {
        private AutoFillViewModelOrg _autoFillViewModelOrg;
        private AutoFillViewModelPers _autoFillViewModelPers;



        public AutoFillKontragentViewModel()
        {
            AutoFillViewModelOrg = new AutoFillViewModelOrg();
            AutoFillViewModelPers = new AutoFillViewModelPers();
        }

        public AutoFillViewModelOrg AutoFillViewModelOrg
        {
            get => _autoFillViewModelOrg;
            set
            {
                _autoFillViewModelOrg = value;
                OnPropertyChanged(nameof(AutoFillViewModelOrg));
            }
        }

        public AutoFillViewModelPers AutoFillViewModelPers
        {
            get => _autoFillViewModelPers;
            set
            {
                _autoFillViewModelPers = value;
                OnPropertyChanged(nameof(AutoFillViewModelPers));
            }
        }
    }
}
