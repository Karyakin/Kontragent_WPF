using Kontragent.Commands;
using Kontragent.Mappers;
using Kontragent.Model;
using Kontragent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.ViewModel.Autorisation
{
    public class AuthorizationViewModel : BaseViewModel
    {

        private RelayCommand _enterTheProgramComm;
        private UsersViewModel _user;
        private string _loginUser;
        private string _password;
        private string _hint;
        private WorkUserViewModel _workUser;
        private string _department;
        private WorkUserSingleton _workUserModel;

        public AuthorizationViewModel()
        {
            EnterTheProgramComm = new RelayCommand(Enter);
           // User = new UsersViewModel();
        }
      

        public static event EventHandler SuccessAuth;
      

        public RelayCommand EnterTheProgramComm
        {
            get => _enterTheProgramComm;
            set
            {
                _enterTheProgramComm = value;
                OnPropertyChanged(nameof(EnterTheProgramComm));
            }
        }

        private void Enter(object parameter)
        {
            var user = UserToAutorisationMapper.AuthorizationViewModelToUserModel(this);
            LoginUser = UserToAutorisationMapper.UserModelToAuthorizationViewModel(user).LoginUser;
            if (string.IsNullOrEmpty(user.LoginUser) && string.IsNullOrWhiteSpace(user.LoginUser))
            {
                MessageBox.Show("Укажите фамилию!", "Ошибка фамилии", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (AutorisationRepository.CheckLogin(user) == false)
            {
                MessageBox.Show("Пользователя с такой фамилией не существует!", "Ошибка фамилии", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(user.Password) && string.IsNullOrWhiteSpace(user.Password))
            {
                MessageBox.Show($"{LoginUser}, введите пароль!", "Ошибка пароля", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (AutorisationRepository.CheckLoginPassward(user) == true)
            {

                var workUser = AutorisationRepository.GetWorkUser(user.LoginUser);
                _workUserModel = WorkUserSingleton.Initialize(workUser);


                MessageBox.Show($"Господин {LoginUser}, добро пожаловать в ИС Контрагент!");
                SuccessAuth?.Invoke(this, EventArgs.Empty);
               
            }
            else
            {
                MessageBox.Show($"У госодина{LoginUser}а другой пароль!", "Ошибка пароля", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
           //  AutorisationRepository.GetUser(user);
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

        public string LoginUser
        {
            get => _loginUser;
            set
            {
                _loginUser = value;
                OnPropertyChanged(nameof(LoginUser));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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
