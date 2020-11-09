using Kontragent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel
{
    public class WorkUserViewModel : BaseViewModel
    {
        private string _loginUser; 
        private string _department;

    

        public string LoginUser
        {
            get => _loginUser;
            set
            {
                _loginUser = value;
                OnPropertyChanged(nameof(LoginUser));
            }
        }

        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

    }
}
