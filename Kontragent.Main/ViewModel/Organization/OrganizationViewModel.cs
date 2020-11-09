using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReactiveValidation;
using ReactiveValidation.Extensions;
using Kontragent.Domain;
using Kontragent.ViewModel.Person;
using Kontragent.Domain.Repository;
using Kontragent.Domain.RepositoryInterface;
using Kontragent.ViewModel.Risk;
using Kontragent.Helper;
using Kontragent.Commands;
using Kontragent.Domain.Models;
using Kontragent.Mappers;
using Kontragent.ViewModel.Autorisation;
using Kontragent.Model;
using Kontragent.Repository;

namespace Kontragent.ViewModel.Organization
{
    public class OrganizationViewModel : BaseViewModel
    {

        private string _UNPOrg;
        private string _shortNameOrg;
        private string _fullNameOrg;
        private string _descriptionORG;

        private string _brokerOpinion;
        private string _sectionHeadOpinion;
        private string _auditorOpinion;

        private PositiveRiskCheckBoxViewModel _ownershipOrg;
        private NegativeRiskCheckBoxViewModel _taxDebt;
        private NegativeRiskCheckBoxViewModel _debtsEnforcementDocuments;
        private NegativeRiskCheckBoxViewModel _falseBusiness;
        private NegativeRiskCheckBoxViewModel _specialRisc;
        private NegativeRiskCheckBoxViewModel _executeProc;
        private NegativeRiskCheckBoxViewModel _bankruptcyProc;
        private NegativeRiskCheckBoxViewModel _liquidationProc;
        private PositiveRiskCheckBoxViewModel _brokerClient;
        private PositiveRiskCheckBoxViewModel _prevBrokerClient;
        //  private bool _tradingexperience;
        private PositiveRiskCheckBoxViewModel _manufacturer;
        private bool _secondAccred;
        private NegativeRiskCheckBoxViewModel _negativData;
        private PositiveRiskCheckBoxViewModel _reputation;
        private NegativeRiskCheckBoxViewModel _exchengeTradingDisorders;

        private DateTime _dateEnd;
        //  private string _auditor;

        private bool _forcedDeposite;
        //   private bool _trader;
        private bool _resident;
        private RiskCreatedDateViewModel _createdateOrg;
        public string _nameSection;

        private RelayCommand _autoFill;
        private IOracleInfoRepository _oracleInfoRepository;
        private IRiskListRepository _riskListRepository;
        //  private OrganizationViewModel _oracleData;
        public UsersModels userModel;



        public OrganizationViewModel()
        {
            _riskListRepository = new RiskRepository();
            Validator = GetValidator();// без инициализации это свойство NULL.
            ICountryRepository countryRepos = new CountryRepository();
            countryRepos.GetCountries();
        }

        public OrganizationViewModel(List<CountryViewModel> countries, List<SectionViewModel> sections) : this()
        {
            Validator = GetValidator();// без инициализации это свойство NULL.
            Countries = countries;
            Section = sections;

            CreatedateOrg = new RiskCreatedDateViewModel(_riskListRepository.GetAgeOrgRisk());
            DateEnd = DateTime.Now;// нельзя ввести завтрашнюю дату
            AutoFill = new RelayCommand(FillOracleData);
            
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
            var organizationBuilder = new ValidationBuilder<OrganizationViewModel>();
            organizationBuilder.RuleFor(x => x.UNPOrg).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.UNPOrg).Matches(@"^[^\s][a-zA-Zа-яА-Я-0-9\s]*$").WithMessage("Пробелы в начале строки не допустимы");
            organizationBuilder.RuleFor(x => x.CreatedateOrg).ModelIsValid();

            organizationBuilder.RuleFor(x => x.ShortNameOrg).NotEmpty().WithMessage("Поле не может быть пустым");
            organizationBuilder.RuleFor(x => x.ShortNameOrg).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.ShortNameOrg).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");

            organizationBuilder.RuleFor(x => x.FullNameOrg).NotEmpty().WithMessage("Поле не может быть пустым");
            organizationBuilder.RuleFor(x => x.FullNameOrg).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.FullNameOrg).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");

            organizationBuilder.RuleFor(x => x.DescriptionORG).NotEmpty().WithMessage("Поле не может быть пустым");
            organizationBuilder.RuleFor(x => x.DescriptionORG).MinLength(2).WithMessage("Поле должно содержать минимум два символа");
            organizationBuilder.RuleFor(x => x.DescriptionORG).Matches(@"[A-Za-zА-Яа-яЁё].").WithMessage("Поле должно минимум две буквы");
            organizationBuilder.RuleFor(x => x.SelectedSection).Must(BeAValidSection).WithMessage("Укажите торговую сессию");
            organizationBuilder.RuleFor(x => x.SelectedCountry).Must(BeAValidCountry).WithMessage("Укажите страну");
            
            organizationBuilder.RuleFor(x => x.DescriptionORG).Must(BeAValidDescriptionOrg).WithMessage("Укажите цель аккредитации(регистрации)");

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
        public string UNPOrg
        {
            get => _UNPOrg;
            set
            {
                _UNPOrg = value;
                OnPropertyChanged(nameof(UNPOrg));
            }
        }


        /*  public string Auditor
          {
              get => _auditor;
              set
              {
                  _auditor = WorkUser?.LoginUser;
                  OnPropertyChanged(nameof(Auditor));
              }
          }*/

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

        public string DescriptionORG
        {
            get => _descriptionORG;// return _descriptionORG
            set
            {
                _descriptionORG = value;
                OnPropertyChanged(nameof(DescriptionORG));
            }
        }

        public PositiveRiskCheckBoxViewModel OwnershipOrg
        {
            get => _ownershipOrg;
            set
            {
                _ownershipOrg = value;
                OnPropertyChanged(nameof(OwnershipOrg));
            }
        }

        public NegativeRiskCheckBoxViewModel TaxDebt
        {
            get => _taxDebt;
            set
            {
                _taxDebt = value;
                OnPropertyChanged(nameof(TaxDebt));
            }
        }

        public NegativeRiskCheckBoxViewModel DebtsEnforcementDocuments
        {
            get => _debtsEnforcementDocuments;
            set
            {
                _debtsEnforcementDocuments = value;
                OnPropertyChanged(nameof(DebtsEnforcementDocuments));
            }
        }

        public NegativeRiskCheckBoxViewModel FalseBusiness
        {
            get => _falseBusiness;
            set
            {
                _falseBusiness = value;
                OnPropertyChanged(nameof(FalseBusiness));
            }
        }

        public NegativeRiskCheckBoxViewModel SpecialRisc
        {
            get => _specialRisc;
            set
            {
                _specialRisc = value;
                OnPropertyChanged(nameof(SpecialRisc));
            }
        }

        public NegativeRiskCheckBoxViewModel ExecuteProc
        {
            get => _executeProc;
            set
            {
                _executeProc = value;
                OnPropertyChanged(nameof(ExecuteProc));
            }
        }

        public NegativeRiskCheckBoxViewModel BankruptcyProc
        {
            get => _bankruptcyProc;
            set
            {
                _bankruptcyProc = value;
                OnPropertyChanged(nameof(BankruptcyProc));
            }
        }

        public NegativeRiskCheckBoxViewModel LiquidationProc
        {
            get => _liquidationProc;
            set
            {
                _liquidationProc = value;
                OnPropertyChanged(nameof(LiquidationProc));
            }
        }

        public PositiveRiskCheckBoxViewModel BrokerClient
        {
            get
            {
                if (_brokerClient.Value == true)
                    DescriptionORG = "Регистрируется в качестве клиента брокера ООО \"\" с целью ";
                
                if (_brokerClient.Value == false)

                    DescriptionORG = "Аккредитуется с целью ";

                return _brokerClient;
            }

            set
            {
                _brokerClient = value;
                OnPropertyChanged(nameof(BrokerClient));
            }
        }

        public PositiveRiskCheckBoxViewModel PrevBrokerClient
        {
            get => _prevBrokerClient;
            set
            {
                _prevBrokerClient = value;
                OnPropertyChanged(nameof(PrevBrokerClient));
            }
        }
        public bool Tradingexperience => SecondAccred;

        public PositiveRiskCheckBoxViewModel Manufacturer
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

        public NegativeRiskCheckBoxViewModel ExchengeTradingDisorders
        {
            get => _exchengeTradingDisorders;
            set
            {
                _exchengeTradingDisorders = value;
                OnPropertyChanged(nameof(ExchengeTradingDisorders));
            }
        }

        public NegativeRiskCheckBoxViewModel NegativData
        {
            get => _negativData;
            set
            {
                _negativData = value;
                OnPropertyChanged(nameof(NegativData));
            }
        }

        public PositiveRiskCheckBoxViewModel Reputation
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

        public bool Trader => !BrokerClient.Value;

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

        public RiskCreatedDateViewModel CreatedateOrg
        {
            get => _createdateOrg;
            set
            {
                if (CreatedateOrg != null)
                {
                    CreatedateOrg.PropertyChanged -= CreatedateOrg_PropertyChanged;
                }
                var removingDate = _createdateOrg;
                _createdateOrg = value;
                RiskCalculator.Note(value);

                OnPropertyChanged(nameof(CreatedateOrg));
                CreatedateOrg.PropertyChanged += CreatedateOrg_PropertyChanged;
            }
        }

        private void CreatedateOrg_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatedateOrg.Value))
            {
                Age = DateCalculator.DateCalculation(CreatedateOrg.Value);
                RiskCalculator.Note(CreatedateOrg);
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

        /// <summary>
        /// Свойство для автоматического заполнения данных формы из OracleDB
        /// </summary>
        public RelayCommand AutoFill
        {
            get => _autoFill;
            set
            {
                _autoFill = value;
                OnPropertyChanged(nameof(AutoFill));
            }
        }

        private void FillOracleData(object parameter)// ?????? Сам метод возвращает ViewModel. Как лучше? Возвращать Model и потом мапить во ViewModel или можно так
        {
            _oracleInfoRepository = new OracleInfoRepository();
            var _oracleData = _oracleInfoRepository.OracleGetOrg(UNPOrg);
            FullNameOrg = _oracleData.FullNameOrg;
            ShortNameOrg = _oracleData.ShortNameOrg;
            CreatedateOrg.Value = _oracleData.CreatedateOrg;
            SelectedCountry = Countries.FirstOrDefault(x => x.NameCountry == _oracleData.SelectedCountry);


        }

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

        internal void CLear()
        {
            UNPOrg = string.Empty;
            FullNameOrg = string.Empty;
            ShortNameOrg = string.Empty;

            AuditorOpinion = string.Empty;
            SectionHeadOpinion = string.Empty;
            DescriptionORG = string.Empty;
            BrokerOpinion = string.Empty;
            CreatedateOrg.Value = DateTime.Now;

            SelectedCountry = Countries.FirstOrDefault();
            SelectedSection = Section.FirstOrDefault();

            if (TaxDebt.Value == true) { TaxDebt.Value = false; }
            if (DebtsEnforcementDocuments.Value == true) { DebtsEnforcementDocuments.Value = false; };
            if (FalseBusiness.Value == true) { FalseBusiness.Value = false; }
            if (SpecialRisc.Value == true) { SpecialRisc.Value = false; }
            if (ExecuteProc.Value == true) { ExecuteProc.Value = false; }
            if (BankruptcyProc.Value == true) { BankruptcyProc.Value = false; }
            if (LiquidationProc.Value == true) { LiquidationProc.Value = false; }
            if (NegativData.Value == true) { NegativData.Value = false; }
            if (ExchengeTradingDisorders.Value == true) { ExchengeTradingDisorders.Value = false; }
            if (Reputation.Value == true) { Reputation.Value = false; }
            if (OwnershipOrg.Value == true) { OwnershipOrg.Value = false; }
            if (Manufacturer.Value == true) { Manufacturer.Value = false; }
            if (BrokerClient.Value == true) { BrokerClient.Value = false; }
            if (PrevBrokerClient.Value == true) { PrevBrokerClient.Value = false; }
            ForcedDeposite = false;
            SecondAccred = false;
            DescriptionORG = "Аккредитуется с целью ";
        }
    }
}
