using Kontragent.Commands;
using Kontragent.ViewModel;
using Kontragent.ViewModel.Autorisation;
using ReactiveValidation;
using ReactiveValidation.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.Personalization.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
        private string _loginUser;
        private string _password;
        private string _department;
        private string _hint;
        private DateTime _dateCreationUser;
        private string _repeatedPassword;
        private RelayCommand _addNewUser;


        public RegistrationViewModel()
        {
            Validator = GetValidator();// без инициализации это свойство NULL. 
            AddNewUser = new RelayCommand(Add, CanAdd);
        }

        private void Add(object parameter)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {

                SqlCommand AddNewUserComm = new SqlCommand("ADD_User", sqlConnection);
                SqlCommand CheckloginComm = new SqlCommand("check_login", sqlConnection);
                AddNewUserComm.CommandType = CommandType.StoredProcedure;
                CheckloginComm.CommandType = CommandType.StoredProcedure;
                CheckloginComm.Parameters.AddWithValue("Login_User", LoginUser);

                sqlConnection.Open();
                if (Convert.ToInt32(CheckloginComm.ExecuteScalar()) == 1)
                {
                    MessageBox.Show("Пользователя с такой фамилией уже зарегистрирован!", "Ошибка фамилии", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    AddNewUserComm.Parameters.AddWithValue("@Login_User", LoginUser);
                    AddNewUserComm.Parameters.AddWithValue("@Department", Department);
                    AddNewUserComm.Parameters.AddWithValue("@Password_User", Password);

                    if (Hint == null)
                    {
                        AddNewUserComm.Parameters.AddWithValue("@Hint", "");
                    }
                    else
                    {
                        AddNewUserComm.Parameters.AddWithValue("@Hint", Hint);
                    }
                    AddNewUserComm.ExecuteNonQuery();
                    MessageBox.Show($"{LoginUser}, добро пожаловать в систему Контрагент!");
                    Clear();
                }
                sqlConnection.Close();
            }
        }

        private bool CanAdd(object parameter)
        {
            if ((this?.Validator.IsValid ?? false) && (this?.Validator.IsValid ?? false))
                return true;
            return false;
        }

        private IObjectValidator GetValidator()
        {
            var RegistratuonBuilder = new ValidationBuilder<RegistrationViewModel>();

            RegistratuonBuilder.RuleFor(x => x.LoginUser).Matches(@"^[^\s][a-zA-Zа-яА-Я-0-9\s]*$").WithMessage("Пробелы в начале строки не допустимы");
            RegistratuonBuilder.RuleFor(x => x.LoginUser).NotEmpty().WithMessage("Поле не может быть пустым");
            RegistratuonBuilder.RuleFor(x => x.LoginUser).MinLength(3).WithMessage("Минимум пять символов!");

            RegistratuonBuilder.RuleFor(x => x.Department).Matches(@"^[^\s][a-zA-Zа-яА-Я-0-9\s]*$").WithMessage("Пробелы в начале строки не допустимы");
            RegistratuonBuilder.RuleFor(x => x.Department).NotEmpty().WithMessage("Поле не может быть пустым");
            RegistratuonBuilder.RuleFor(x => x.Department).MinLength(2).WithMessage("Минимум пять символов!");

            RegistratuonBuilder.RuleFor(x => x.Password).Matches(@"^[^\s][a-zA-Zа-яА-Я-0-9\s]*$").WithMessage("Пробелы в начале строки не допустимы");
            RegistratuonBuilder.RuleFor(x => x.Password).NotEmpty().WithMessage("Поле не может быть пустым");
            RegistratuonBuilder.RuleFor(x => x.Password).MinLength(5).WithMessage("Минимум пять символов!");

            RegistratuonBuilder.RuleFor(x => x.RepeatedPassword).Matches(@"^[^\s][a-zA-Zа-яА-Я-0-9\s]*$").WithMessage("Пробелы в начале строки не допустимы");
            RegistratuonBuilder.RuleFor(x => x.RepeatedPassword).NotEmpty().WithMessage("Поле не может быть пустым");
            RegistratuonBuilder.RuleFor(x => x.RepeatedPassword).MinLength(5).WithMessage("Минимум пять символов!");
            RegistratuonBuilder.RuleFor(x => x.RepeatedPassword).Must(BeAValidRepeatedPassword).WithMessage("Пароли не совпадают!");

            return RegistratuonBuilder.Build(this);
        }

        private bool BeAValidRepeatedPassword(string registr)
        {
            return registr != null && RepeatedPassword == Password;
        }

        public void Clear()
        {
            LoginUser = string.Empty;
            Password = string.Empty;
            RepeatedPassword = string.Empty;
            Department = string.Empty;
            Hint = string.Empty;
        }

        public RelayCommand AddNewUser
        {
            get => _addNewUser;
            set
            {
                _addNewUser = value;
                OnPropertyChanged(nameof(AddNewUser));
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

