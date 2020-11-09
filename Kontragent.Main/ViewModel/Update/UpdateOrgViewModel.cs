using Kontragent.Commands;
using Kontragent.Domain.Repository;
using Kontragent.Domain.RepositoryInterface;
using Kontragent.Helper;
using Kontragent.ViewModel.Person;
using Kontragent.ViewModel.Risk;
using ReactiveValidation;
using ReactiveValidation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Update
{
    public class UpdateOrgViewModel : BaseViewModel
    {
        private string _UNPOrg;
        private string _shortNameOrg;
        private string _fullNameOrg;
        private string _descriptionORG;
        private string _brokerOpinion;
        private string _sectionHeadOpinion;
        private string _auditorOpinion;
        private bool _ownershipOrg;
        private bool _taxDebt;
        private bool _debtsEnforcementDocuments;
        private bool _falseBusiness;
        private bool _specialRisc;
        private bool _executeProc;
        private bool _bankruptcyProc;
        private bool _liquidationProc;
        private bool _brokerClient;
        private bool _prevBrokerClient;
        private bool _manufacturer;
        private bool _secondAccred;
        private bool _negativData;
        private bool _reputation;
        private bool _exchengeTradingDisorders;
        private DateTime _dateEnd;
        private bool _forcedDeposite;
        private bool _resident;
        private DateTime _createdateOrg;
        public string _nameSection;

        public UpdateOrgViewModel()
        {
            Validator = GetValidator();// без инициализации это свойство NULL.
            ICountryRepository countryRepos = new CountryRepository();
            countryRepos.GetCountries();
        }

        public UpdateOrgViewModel(List<CountryViewModel> countries, List<SectionViewModel> sections) : this()
        {
            Validator = GetValidator();// без инициализации это свойство NULL.
            Countries = countries;
            Section = sections;
            DateEnd = DateTime.Now;// нельзя ввести завтрашнюю дату
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
        /// Сюда пидет та страна, которая будет выбрана из выпадающего списка
        /// </summary>
        public CountryViewModel SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                var removingCountry = _selectedCountry;
                _selectedCountry = value;
                RiskCalculator.Note(SelectedCountry, removingCountry);
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }

        public List<SectionViewModel> _section;

        /// <summary>
        /// В этом списке содердится перечень всех секций полученных из базы
        /// </summary>
        public List<SectionViewModel> Section
        {
            get => _section;
            set
            {
                _section = value;
                OnPropertyChanged(nameof(Section));
            }
        }

        private SectionViewModel _selectedSection;
        /// <summary>
        /// Сюда пидет та секция, которая будет выбрана из выпадающего списка
        /// </summary>
        public SectionViewModel SelectedSection
        {
            get => _selectedSection;
            set
            {
                var removingSection = _selectedSection;
                _selectedSection = value;
                RiskCalculator.Note(SelectedSection, removingSection);
                OnPropertyChanged(nameof(SelectedSection));
            }
        }

        #region Валидация
        /// <summary>
        /// Инициализируем свойство Validator не через конструктор, а через метод GetValidator и этот метод возвращает нашему validator значение c типом IObjectValidator
        /// </summary>
        /// <returns></returns>
        private IObjectValidator GetValidator()
        {
            //Стили для вывода посказок определены в App.xaml
            var organizationBuilder = new ValidationBuilder<UpdateOrgViewModel>();
            organizationBuilder.RuleFor(x => x.UNPOrg).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.UNPOrg).Matches(@"^[^\s][a-zA-Zа-яА-Я-0-9\s]*$").WithMessage("Пробелы в начале строки не допустимы");
            // organizationBuilder.RuleFor(x => x.CreatedateOrg).ModelIsValid();

            organizationBuilder.RuleFor(x => x.ShortNameOrg).NotEmpty().WithMessage("Поле не может быть пустым");
            organizationBuilder.RuleFor(x => x.ShortNameOrg).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.ShortNameOrg).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");

            organizationBuilder.RuleFor(x => x.FullNameOrg).NotEmpty().WithMessage("Поле не может быть пустым");
            organizationBuilder.RuleFor(x => x.FullNameOrg).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.FullNameOrg).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");

            organizationBuilder.RuleFor(x => x.DescriptionOrg).NotEmpty().WithMessage("Поле не может быть пустым");
            organizationBuilder.RuleFor(x => x.DescriptionOrg).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.DescriptionOrg).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");
            organizationBuilder.RuleFor(x => x.SelectedSection).Must(BeAValidSection).WithMessage("Укажите торговую сессию");
            organizationBuilder.RuleFor(x => x.SelectedCountry).Must(BeAValidCountry).WithMessage("Укажите страну");

            organizationBuilder.RuleFor(x => x.DescriptionOrg).Must(BeAValidDescriptionOrg).WithMessage("Укажите цель аккредитации(регистрации)");

            return organizationBuilder.Build(this/*методу нужна ЭТА ViewModel*/);// после созданных правил тут мы создаем саму инициализацию. Билдер сбилдся.
        }

        private bool BeAValidDescriptionOrg(string organizationViewModel)
        {
            return organizationViewModel != null && organizationViewModel != "Регистрируется в качестве клиента брокера ООО \"\" с целью " && organizationViewModel != "Аккредитуется с целью ";
        }

        private bool BeAValidSection(SectionViewModel section)
        {
            return section != null && section.NameSection != "(не выбрано)";
        }

        private bool BeAValidCountry(CountryViewModel country)
        {
            return country != null && country.NameCountry != "(не выбрано)";
        }
        #endregion

        #region Cвойства организации





        public string RiskLevel
        {
            get => _riskLevel;
            set
            {
                _riskLevel = value;
                OnPropertyChanged(nameof(RiskLevel));
            }
        }


        public string RecomendDeposit
        {
            get => _recomendDeposit;
            set
            {
                _recomendDeposit = value;
                OnPropertyChanged(nameof(RecomendDeposit));
            }
        }
        public string Deposit
        {
            get => _deposit;
            set
            {
                _deposit = value;
                OnPropertyChanged(nameof(Deposit));
            }
        }

        public string UNPOrg
        {
            get => _UNPOrg;
            set
            {
                _UNPOrg = value;
                OnPropertyChanged(nameof(UNPOrg));
            }
        }


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

        public string DescriptionOrg
        {
            get => _descriptionORG;// return _descriptionORG
            set
            {
                _descriptionORG = value;
                OnPropertyChanged(nameof(DescriptionOrg));
            }
        }

        public bool OwnershipOrg
        {
            get => _ownershipOrg;
            set
            {
                _ownershipOrg = value;
                OnPropertyChanged(nameof(OwnershipOrg));
            }
        }



        public bool TaxDebt
        {
            get => _taxDebt;
            set
            {
                _taxDebt = value;
                OnPropertyChanged(nameof(TaxDebt));
            }
        }

        public bool DebtsEnforcementDocuments
        {
            get => _debtsEnforcementDocuments;
            set
            {
                _debtsEnforcementDocuments = value;
                OnPropertyChanged(nameof(DebtsEnforcementDocuments));
            }
        }

        public bool FalseBusiness
        {
            get => _falseBusiness;
            set
            {
                _falseBusiness = value;
                OnPropertyChanged(nameof(FalseBusiness));
            }
        }

        public bool SpecialRisc
        {
            get => _specialRisc;
            set
            {
                _specialRisc = value;
                OnPropertyChanged(nameof(SpecialRisc));
            }
        }

        public bool ExecuteProc
        {
            get => _executeProc;
            set
            {
                _executeProc = value;
                OnPropertyChanged(nameof(ExecuteProc));
            }
        }

        public bool BankruptcyProc
        {
            get => _bankruptcyProc;
            set
            {
                _bankruptcyProc = value;
                OnPropertyChanged(nameof(BankruptcyProc));
            }
        }
        public bool LiquidationProc
        {
            get => _liquidationProc;
            set
            {
                _liquidationProc = value;
                OnPropertyChanged(nameof(LiquidationProc));
            }
        }

        public bool BrokerClient
        {
            get => _brokerClient;


            set
            {
                _brokerClient = value;
                OnPropertyChanged(nameof(BrokerClient));
            }
        }
        public bool PrevBrokerClient
        {
            get => _prevBrokerClient;
            set
            {
                _prevBrokerClient = value;
                OnPropertyChanged(nameof(PrevBrokerClient));
            }
        }
        public bool Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged(nameof(Manufacturer));
            }
        }

        public bool SecondAccred
        {
            get => _secondAccred;
            set
            {
                _secondAccred = value;
                OnPropertyChanged(nameof(SecondAccred));

            }
        }
        /// <summary>
        /// => - return. FirstAccred становится противоположностью SecondAccred
        /// </summary>
        public bool FirstAccred => !SecondAccred;

        public bool ExchengeTradingDisorders
        {
            get => _exchengeTradingDisorders;
            set
            {
                _exchengeTradingDisorders = value;
                OnPropertyChanged(nameof(ExchengeTradingDisorders));
            }
        }

        public bool NegativData
        {
            get => _negativData;
            set
            {
                _negativData = value;
                OnPropertyChanged(nameof(NegativData));
            }
        }

        public bool Reputation
        {
            get => _reputation;
            set
            {
                _reputation = value;
                OnPropertyChanged(nameof(Reputation));
            }
        }

        public bool ForcedDeposite
        {
            get => _forcedDeposite;
            set
            {
                _forcedDeposite = value;
                OnPropertyChanged(nameof(ForcedDeposite));
            }
        }

        public string BrokerOpinion
        {
            get => _brokerOpinion;
            set
            {
                _brokerOpinion = value;
                OnPropertyChanged(nameof(BrokerOpinion));
            }
        }
        public bool Resident => SelectedCountry?.NameCountry == "Беларусь" ? _resident = true : _resident = false; //System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."

        public string AuditorOpinion
        {
            get => _auditorOpinion;
            set
            {
                _auditorOpinion = value;
                OnPropertyChanged(nameof(AuditorOpinion));
            }
        }

        private string _age;
        private string _recomendDeposit;
        private string _deposit;
        private string _riskLevel;

        /// <summary>
        /// Строка для отображения количества лет, месяцев и дней
        /// </summary>
        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public DateTime CreateDateOrg
        {
            get => _createdateOrg;
            set
            {
                _createdateOrg = value;
                OnPropertyChanged(nameof(CreateDateOrg));
            }
        }

        /// <summary>
        /// Свойство для даты, котору нельзя вностить в календарь. Для запрета завтрашней даты.
        /// </summary>
        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }

        #endregion

        public string SectionHeadOpinion
        {
            //условие ? истина : лдожь
            get => _sectionHeadOpinion;
            set
            {
                _sectionHeadOpinion = value;
                OnPropertyChanged(nameof(SectionHeadOpinion));
            }
        }
    }
}
