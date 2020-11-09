using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Autorisation
{
  public  class UsersViewModel : BaseViewModel 
    {

        private string _loginUser;
        private string _passwordUser;
        private string _department;
        private string _hint;
        private DateTime _dateCreationUser;
        private string _repeatedPassword;

        
        public string LoginUser
        {
            get => _loginUser;
            set
            {
                _loginUser = value;
                OnPropertyChanged(nameof(LoginUser));
            }
        }

        public string PasswordUser
        {
            get => _passwordUser;
            set
            {
                _passwordUser = value;
                OnPropertyChanged(nameof(PasswordUser));
            }
        }
        public string RepeatedPassword
        {
            get => _repeatedPassword;
            set
            {
                _repeatedPassword = value;
                OnPropertyChanged(nameof(RepeatedPassword));
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

        public string Hint
        {
            get => _hint;
            set
            {
                _hint = value;
                OnPropertyChanged(nameof(Hint));
            }
        }

        public DateTime DateCreationUser
        {
            get => _dateCreationUser;
            set
            {
                _dateCreationUser = value;
                OnPropertyChanged(nameof(DateCreationUser));
            }
        }
    }
}
