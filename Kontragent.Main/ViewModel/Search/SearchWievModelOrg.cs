using Kontragent.Commands;
using Kontragent.Domain;
using Kontragent.Domain.Models;
using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Repository;
using Kontragent.Domain.RepositoryInterface;
using Kontragent.Mappers;
using Kontragent.Model;
using Kontragent.Repository.RepositoryClass;
using Kontragent.Repository.RepositoryInterface;
using Kontragent.ViewModel.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Kontragent.ViewModel.Search
{
    public class SearchWievModelOrg : BaseViewModel
    {
        private ICountryRepository _countryRepository;
        private ISectionRepository _sectionRepository;


        private string _UNPOrg;
        private string _shortNameOrg;
        private string _fullNameOrg;
        private string _countyrOrg;
        private DateTime _createdateOrg;
        private string _descriptionOrg;

        private string _auditorOpinion;
        private string _brokerOpinion;
        private string _sectionHeadOpinion;
       
       /* private string _ownerName;
        private string _headName;*/
        private string _nameSection;
        private string _auditor;
        private string _updateAuditor;
        private string _deposit;
        private string _recomendDeposit;
        private int _riscLevel;


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
        private bool _tradingexperience;
        private bool _manufacturer;
        private bool _firstAccred;
        private bool _secondAccred;
        private bool _negativData;
        private bool _reputation;
        private bool _exchengeTradingDisorders;

        private bool _forcedDeposite;
        private bool _trader;
        private bool _resident;
        private bool _notResident;

        private DateTime _createdateOrgSTART;
        private DateTime _createdateOrgFINAL;
        private DateTime _checkDateOrgSTART;
        private DateTime _checkDateOrgFINAL;

        private DateTime _checkDateOrg;


        private int _riscLevelMore;
        private int _riscLevelLess;

        private RelayCommand _searchCommand;
        private ISearchRepository _searchRepository;


        public SearchWievModelOrg()
        {
            _searchRepository = new SearchRepository();

            _countryRepository = new CountryRepository();  //создаем экземпляр класса CountryRepository, который унаследован от интрефейса ICountryRepository
            List<CountryModel> countries = _countryRepository.GetCountries();// создаем список объектов с типом CountryModel при помощи метода обязательного (Интрерфес) методом GetCountries из репы
            Countries = CountryMapper.CountryModelToCountryViewModel(countries);// при помощи статического метода CountryModelToCountryViewModel из класса CountryMapper приводим тип из Модели во Вью модель, чтобы наша вью модель могла работать с данными 

            _sectionRepository = new SectionRepository();
            List<SectionModel> sections = _sectionRepository.GetSections();
            Section = SectionMappers.SectionModelToSectionViewModel(sections);

            CreatedateOrgSTART = new DateTime(1980, 01, 01);
            CreatedateOrgFINAL = DateTime.Now;

            CheckDateOrgSTART = DateTime.Today;
            CheckDateOrgFINAL = DateTime.Today.AddDays(1);

            CheckDateOrg = DateTime.Now;

            RiscLevelLess = 83;
            RiscLevelMore = 0;

          /*  SearchCommand = new RelayCommand(Search, CanSearch);*/


        }

        public ISearchRepository SearchRepository
        {
            get => _searchRepository;
            set
            {
                _searchRepository = value;
                OnPropertyChanged(nameof(SearchRepository));
            }
        }


        #region Описания
        public string DescriptionOrg
        {
            get => _descriptionOrg;
            set
            {
                _descriptionOrg = value;
                OnPropertyChanged(nameof(DescriptionOrg));
            }
        }

        public string AuditorOpinion
        {
            get => _auditorOpinion;
            set
            {
                _auditorOpinion = value;
                OnPropertyChanged(nameof(AuditorOpinion));
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

        public string SectionHeadOpinion
        {
            get => _sectionHeadOpinion;
            set
            {
                _sectionHeadOpinion = value;
                OnPropertyChanged(nameof(SectionHeadOpinion));
            }
        }

        #endregion

        #region Combobox

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
                _selectedCountry = value;
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
                _selectedSection = value;
                OnPropertyChanged(nameof(SelectedSection));
            }
        }

        #endregion

        #region Параметры для организации


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

        public bool Resident
        {
            get => _resident;
            set
            {
                _resident = value;
                OnPropertyChanged(nameof(Resident));
            }
        }

        public bool NotResident
        {
            get => _notResident;
            set
            {
                _notResident = value;
                OnPropertyChanged(nameof(NotResident));
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

        public bool FirstAccred
        {
            get => _firstAccred;
            set
            {
                _firstAccred = value;
                OnPropertyChanged(nameof(FirstAccred));

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

        public bool Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged(nameof(Manufacturer));
            }
        }

        public bool Trader
        {
            get => _trader;
            set
            {
                _trader = value;
                OnPropertyChanged(nameof(Trader));
            }
        }

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

        public bool Tradingexperience
        {
            get => _tradingexperience;
            set
            {
                _tradingexperience = value;
                OnPropertyChanged(nameof(Tradingexperience));
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

        public int RiscLevelMore
        {
            get => _riscLevelMore;
            set
            {
                _riscLevelMore = value;
                OnPropertyChanged(nameof(RiscLevelMore));
            }
        }

        public int RiscLevelLess
        {
            get => _riscLevelLess;
            set
            {
                _riscLevelLess = value;
                OnPropertyChanged(nameof(RiscLevelLess));
            }
        }

        public DateTime CreatedateOrgSTART
        {
            get => _createdateOrgSTART;
            set
            {
                _createdateOrgSTART = value;
                OnPropertyChanged(nameof(CreatedateOrgSTART));

            }
        }

        public DateTime CreatedateOrgFINAL
        {
            get => _createdateOrgFINAL
;
            set
            {
                _createdateOrgFINAL = value;
                OnPropertyChanged(nameof(CreatedateOrgFINAL));
            }
        }

        public DateTime CheckDateOrgSTART
        {
            get => _checkDateOrgSTART
;
            set
            {
                _checkDateOrgSTART = value;
                OnPropertyChanged(nameof(CheckDateOrgSTART));
            }
        }

        public DateTime CheckDateOrgFINAL
        {
            get => _checkDateOrgFINAL
;
            set
            {
                _checkDateOrgFINAL = value;
                OnPropertyChanged(nameof(CheckDateOrgFINAL));
            }
        }

        public string CountyrOrg
        {
            get => _countyrOrg;
            set
            {
                _countyrOrg = value;
                OnPropertyChanged(nameof(CountyrOrg));
            }
        }

        public string NameSection
        {
            get => _nameSection;
            set
            {
                _nameSection = value;
                OnPropertyChanged(nameof(NameSection));
            }
        }

        public DateTime CreatedateOrg
        {
            get => _createdateOrg;
            set
            {
                _createdateOrg = value;
                OnPropertyChanged(nameof(CreatedateOrg));
            }
        }

        public DateTime CheckDateOrg
        {
            get => _checkDateOrg;
            set
            {
                _checkDateOrg = value;
                OnPropertyChanged(nameof(CheckDateOrg));
            }
        }


        public string Auditor
        {
            get => _auditor;
            set
            {
                _auditor = value;
                OnPropertyChanged(nameof(Auditor));
            }
        }

        public string UpdateAuditor
        {
            get => _updateAuditor;
            set
            {
                _updateAuditor = value;
                OnPropertyChanged(nameof(UpdateAuditor));
            }
        }

        public int RiscLevel
        {
            get => _riscLevel;
            set
            {
                _riscLevel = value;
                OnPropertyChanged(nameof(RiscLevel));
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

        public string RecomendDeposit
        {
            get => _recomendDeposit;
            set
            {
                _recomendDeposit = value;
                OnPropertyChanged(nameof(RecomendDeposit));
            }
        }

        

     

        #endregion

        #region мусор


        /*   public string CountyrPers
           {
               get => _countyrPers;
               set
               {
                   _countyrPers = value;
                   OnPropertyChanged(nameof(CountyrPers));
               }
           }
   */

        /*   public string OwnerName
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
      }*/


        /*  public string DescriptionPers
          {
              get => _descriptionPers;
              set
              {
                  _descriptionPers = value;
                  OnPropertyChanged(nameof(DescriptionPers));
              }
          }
  */

        /*   public RelayCommand SearchCommand
  {
      get => _searchCommand;
      set
      {
          _searchCommand = value;
          OnPropertyChanged(nameof(SearchCommand));
      }
  }*/

        /*  private ObservableCollection<SearchWievModelOrg> _items;
          public ObservableCollection<SearchWievModelOrg> Items
          {
              get => _items;
              set
              {
                  _items = value;
                  OnPropertyChanged(nameof(Items));
              }
          }*/

        /*  private void Search(object parameter)
          {
              var organization = SearchMapper.SearchWievModelOrgToOrganizationModel(this); // из виью модели делаем модель
              Items = new ObservableCollection<SearchWievModelOrg>(_searchRepository.GeneralSearch(organization));
          }

          private bool CanSearch(object parameter)
          {
              *//* if ((Organization?.Validator.IsValid ?? false) && (Person1?.Validator.IsValid ?? false))
                   return true;
               return false;*//*
              return true;
          }*/

        /*  private CountryViewModel _selectedCountryPers;
          /// <summary>
          /// Сюда пидет та страна, которая будет выбрана из выпадающего списка
          /// </summary>
          public CountryViewModel SelectedCountryPers
          {
              get => _selectedCountryPers;
              set
              {
                  _selectedCountryPers = value;
                  OnPropertyChanged(nameof(SelectedCountryPers));
              }
          }
  */

        /*   public bool PrevLiquidated
           {
               get => _prevLiquidated;
               set
               {
                   _prevLiquidated = value;
                   OnPropertyChanged(nameof(PrevLiquidated));
               }
           }
           public bool PrevBankruptcy
           {
               get => _prevBankruptcy;
               set
               {
                   _prevBankruptcy = value;
                   OnPropertyChanged(nameof(PrevBankruptcy));
               }
           }
           public bool PrevStateDebt
           {
               get => _prevStateDebt;
               set
               {
                   _prevStateDebt = value;
                   OnPropertyChanged(nameof(PrevStateDebt));
               }
           }
           public bool PrevTaxDebt
           {
               get => _prevTaxDebt;
               set
               {
                   _prevTaxDebt = value;
                   OnPropertyChanged(nameof(PrevTaxDebt));
               }
           }
           public bool PrevExecuteProc
           {
               get => _prevExecuteProc;
               set
               {
                   _prevExecuteProc = value;
                   OnPropertyChanged(nameof(PrevExecuteProc));
               }
           }
           public bool NegativDataPers
           {
               get => _negativDataPers;
               set
               {
                   _negativDataPers = value;
                   OnPropertyChanged(nameof(NegativDataPers));
               }
           }

   */



        #endregion


    }


}
