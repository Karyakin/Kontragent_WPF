using Kontragent.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.ViewModel.Autofill
{
   public class AutoFillViewModel : BaseViewModel
    {

        private AutoFillKontragentViewModel _autoFillKontragentViewModel;

        public AutoFillViewModel()
        {
            AutoFillKontragentViewModel = new AutoFillKontragentViewModel();
        }


        public AutoFillKontragentViewModel AutoFillKontragentViewModel 
        {
            get => _autoFillKontragentViewModel;
            set
            {
                _autoFillKontragentViewModel = value;
                OnPropertyChanged(nameof(AutoFillKontragentViewModel));
            }
        }
    }
}
