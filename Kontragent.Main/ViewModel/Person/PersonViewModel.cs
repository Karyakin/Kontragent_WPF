using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using Kontragent.Helper;
using Kontragent.ViewModel.Risk;
using ReactiveValidation;
using ReactiveValidation.Extensions;


namespace Kontragent.ViewModel.Person
{
    /// <summary>
    /// Данный класс унаследован от класса BaseViewModel, от которого будут унаследованы все классы вью модели. 
    /// Это нужно для того, чтобы не городить код, который будет содержатья во всех viewModel
    /// Например на 25 строке свойство Validator, которое тянется из класса ValidatableObject(этот класс
    /// предоставляется в скачанном NunGet пакете Reactiv Validator) который унаслекдовал BaseViewModel
    /// 
    /// </summary>
    public class PersonViewModel : BaseViewModel
    {

        private string _ownerName;
        private string _headName;
        public NegativeRiskCheckBoxViewModel _prevLiquidated;
        public NegativeRiskCheckBoxViewModel _prevBankruptcy;
        public NegativeRiskCheckBoxViewModel _prevStateDebt;
        public NegativeRiskCheckBoxViewModel _prevTaxDebt;
        public NegativeRiskCheckBoxViewModel _prevExecuteProc;
        public NegativeRiskCheckBoxViewModel _negativDataPers;
        public string _descriptionPers;


        public PersonViewModel()
        {
            Validator = GetValidator();
        }

        private IObjectValidator GetValidator()
        {
            var personBuilder = new ValidationBuilder<PersonViewModel>();
            personBuilder.RuleFor(x => x.OwnerName).NotEmpty().WithMessage("Поле не может быть пустым");
            personBuilder.RuleFor(x => x.OwnerName).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            personBuilder.RuleFor(x => x.OwnerName).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");

            personBuilder.RuleFor(x => x.HeadName).NotEmpty().WithMessage("Поле не может быть пустым");
            personBuilder.RuleFor(x => x.HeadName).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            personBuilder.RuleFor(x => x.HeadName).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");



            personBuilder.RuleFor(x => x.SelectedCountry).Must(BeAValidCountry).WithMessage("Укажите страну");
            return personBuilder.Build(this);
        }
        private bool BeAValidCountry(CountryViewModel country)
        {
            return country != null && country.NameCountry != "(не выбрано)";
        }

        /// <summary>
        /// Этот конструктор для приема списка стран и последующей передачи его NewOrganizationViewModel
        /// При загруске еонструктора в него будем передавать объект класса Country
        /// </summary>
        /// <param name="countries"></param>
        public PersonViewModel(List<CountryViewModel> countries) : this()
        {
            Validator = GetValidator();
            Countries = countries;
        }

        public List<CountryViewModel> _countries;
        public List<CountryViewModel> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged(nameof(Countries));
            }
        }

        private CountryViewModel _selectedCountry;
        /// <summary>
        /// В это свойство попадает та страна, которая выпадет из выпадающего списка.
        /// </summary>
        public CountryViewModel SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                var removingCountry = _selectedCountry;
                _selectedCountry = value;
                RiskCalculator.Note(SelectedCountry, removingCountry);
                if (value != null)
                {
                    OnPropertyChanged(nameof(SelectedCountry));
                }
            }
        }

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

        public string DescriptionPers
        {
            //условие ? истина : лдожь
            get =>  _descriptionPers;
            set
            {
                _descriptionPers = value;
                OnPropertyChanged(nameof(DescriptionPers));
            }
        }

        public NegativeRiskCheckBoxViewModel PrevLiquidated
        {
            get => _prevLiquidated;
            set
            {
                _prevLiquidated = value;
                OnPropertyChanged(nameof(PrevLiquidated));
            }
        }
        public NegativeRiskCheckBoxViewModel PrevBankruptcy
        {
            get => _prevBankruptcy;
            set
            {
                _prevBankruptcy = value;
                OnPropertyChanged(nameof(PrevBankruptcy));
            }
        }
        public NegativeRiskCheckBoxViewModel PrevStateDebt
        {
            get => _prevStateDebt;
            set
            {
                _prevStateDebt = value;
                OnPropertyChanged(nameof(PrevStateDebt));
            }
        }
        public NegativeRiskCheckBoxViewModel PrevTaxDebt
        {
            get => _prevTaxDebt;
            set
            {
                _prevTaxDebt = value;
                OnPropertyChanged(nameof(PrevTaxDebt));
            }
        }
        public NegativeRiskCheckBoxViewModel PrevExecuteProc
        {
            get => _prevExecuteProc;
            set
            {
                _prevExecuteProc = value;
                OnPropertyChanged(nameof(PrevExecuteProc));
            }
        }
        public NegativeRiskCheckBoxViewModel NegativDataPers
        {
            get => _negativDataPers;
            set
            {
                _negativDataPers = value;
                OnPropertyChanged(nameof(NegativDataPers));
            }
        }


        internal void Clear()
        {
            OwnerName = string.Empty;
            HeadName = string.Empty;
            DescriptionPers = string.Empty;
            SelectedCountry = Countries.FirstOrDefault();

            if (PrevLiquidated.Value == true) { PrevLiquidated.Value = false; }
            if (PrevBankruptcy.Value == true) { PrevBankruptcy.Value = false; }
            if (PrevStateDebt.Value == true) { PrevStateDebt.Value = false; }
            if (PrevTaxDebt.Value == true) { PrevTaxDebt.Value = false; }
            if (PrevExecuteProc.Value == true) { PrevExecuteProc.Value = false; }
            if (NegativDataPers.Value == true) { NegativDataPers.Value = false; }



        }

    }
}
