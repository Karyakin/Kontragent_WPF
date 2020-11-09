using Kontragent.Commands;
using Kontragent.Domain;
using Kontragent.Domain.Models;
using Kontragent.Domain.Repository;
using Kontragent.Domain.RepositoryInterface;
using Kontragent.Helper;
using Kontragent.Mappers;
using Kontragent.ViewModel.Organization;
using Kontragent.ViewModel.Person;
using Kontragent.ViewModel.Risk;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Kontragent.ViewModel.Autorisation;
using Kontragent.ViewModel.Autofill;
using Kontragent.Repository.RepositoryInterface;
using Kontragent.Repository.AutoFilRepository;

namespace Kontragent.ViewModel
{
    public class NewOrganizationViewModel : BaseViewModel
    {
        private PersonViewModel _person;
        private OrganizationViewModel _organization;
        private RelayCommand _saveCommand;
        private ICountryRepository _countryRepository;
        private ISectionRepository _sectionRepository;
        private INewOrganizationRepository _newOrgrepo;// чтобы не создавать экземпляр класса каждый раз
        private IRiskListRepository _riskListRepository;
        private IAutofilInterface _oracleInfoRepository;

        private RelayCommand _clearCommand;
        private AutoFillViewModel _AF;
        private WorkUserViewModel _workUser;
        private UsersViewModel _user;

        GetCountrySectionViewModel GetCountrySectionViewModel = new GetCountrySectionViewModel();
        private int _risk;
        private RelayCommand _autoFill;

        public NewOrganizationViewModel()
        {

            _newOrgrepo = new NewOrganizationRepository();

            _countryRepository = new CountryRepository();  //создаем экземпляр класса CountryRepository, который унаследован от интрефейса ICountryRepository
            List<CountryModel> countries = _countryRepository.GetCountries();// создаем список объектов с типом CountryModel при помощи метода обязательного (Интрерфес) методом GetCountries из репы
            var countryVM = CountryMapper.CountryModelToCountryViewModel(countries);// при помощи статического метода CountryModelToCountryViewModel из класса CountryMapper приводим тип из Модели во Вью модель, чтобы наша вью модель могла работать с данными 

            _sectionRepository = new SectionRepository();
            List<SectionModel> sections = _sectionRepository.GetSections();
            var sectionVM = SectionMappers.SectionModelToSectionViewModel(sections);
            _riskListRepository = new RiskRepository();

            var risks = _riskListRepository.GetRisks();
            //ValueChanged - обработчик событий. В калькуляторе у нас есть событие, которое вызывается при смене значения в калькуляторе(при добавлении и удаоении значений)
            /// мы подписываемся на изменение ValueChanged       
            RiskCalculator.ValueChanged += RiskCalculatorValueChanged;

            Person1 = new PersonViewModel(countryVM)
            {
                PrevLiquidated = new NegativeRiskCheckBoxViewModel(risks.PrevLiquidated),
                PrevBankruptcy = new NegativeRiskCheckBoxViewModel(risks.PrevBankruptcy),
                PrevExecuteProc = new NegativeRiskCheckBoxViewModel(risks.PrevExecuteProc),
                PrevStateDebt = new NegativeRiskCheckBoxViewModel(risks.PrevStateDebt),
                PrevTaxDebt = new NegativeRiskCheckBoxViewModel(risks.PrevTaxDebt),
                NegativDataPers = new NegativeRiskCheckBoxViewModel(risks.NegativData)
            };

            Organization = new OrganizationViewModel(countryVM, sectionVM)
            {
                BrokerClient = new PositiveRiskCheckBoxViewModel(risks.BrokerClient),
                PrevBrokerClient = new PositiveRiskCheckBoxViewModel(risks.PrevBrokerClient),
                Manufacturer = new PositiveRiskCheckBoxViewModel(risks.Manufacturer),
                Reputation = new PositiveRiskCheckBoxViewModel(risks.Reputation),
                OwnershipOrg = new PositiveRiskCheckBoxViewModel(risks.OwnershipOrg),

                TaxDebt = new NegativeRiskCheckBoxViewModel(risks.TaxDebt),
                DebtsEnforcementDocuments = new NegativeRiskCheckBoxViewModel(risks.DebtsEnforcementDocuments),
                FalseBusiness = new NegativeRiskCheckBoxViewModel(risks.FalseBusiness),
                SpecialRisc = new NegativeRiskCheckBoxViewModel(risks.SpecialRisc),
                ExecuteProc = new NegativeRiskCheckBoxViewModel(risks.ExecuteProc),
                BankruptcyProc = new NegativeRiskCheckBoxViewModel(risks.BankruptcyProc),
                LiquidationProc = new NegativeRiskCheckBoxViewModel(risks.LiquidationProc),
                NegativData = new NegativeRiskCheckBoxViewModel(risks.NegativData),
                ExchengeTradingDisorders = new NegativeRiskCheckBoxViewModel(risks.ExchengeTradingDisorders),
            };

            SaveCommand = new RelayCommand(Save, CanSave);
            ClearCommand = new RelayCommand(Clear);
            Risk = RiskCalculator.Value;
            AutoFill = new RelayCommand(FillOracleDataOrgPers);
            AutoFillViewModel = new AutoFillViewModel();

            Countries = countryVM;

        }
        public void FillOracleDataOrgPers(object parameter)// ?????? Сам метод возвращает ViewModel. Как лучше? Возвращать Model и потом мапить во ViewModel или можно так
        {
            _oracleInfoRepository = new AutoFillRepo();
            var org = _oracleInfoRepository.AutoFilKontra(Organization.UNPOrg);
            Organization.FullNameOrg = org.AutoFillViewModelOrg.FullNameOrg;
            Organization.ShortNameOrg = org.AutoFillViewModelOrg.ShortNameOrg;
            Organization.CreatedateOrg.Value = org.AutoFillViewModelOrg.CreateDateOrg;
            Person1.HeadName = org.AutoFillViewModelPers.HeadName;
            Person1.OwnerName = org.AutoFillViewModelPers.OwnerName;
            Organization.SelectedCountry = Countries.FirstOrDefault(x=>x.NameCountry == org.AutoFillViewModelOrg.CountryOrg);
            Person1.SelectedCountry = Countries.FirstOrDefault(x =>x.NameCountry == org.AutoFillViewModelPers.CountryPers);
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
        public UsersViewModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
       

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

        public AutoFillViewModel AutoFillViewModel
        {
            get => _AF;
            set
            {
                _AF = value;
                OnPropertyChanged(nameof(AutoFillViewModel));
            }
        }

        /// <summary>
        /// обарботчик события на изменение значения риска в калькуляторе. Когда мы изменяем значение в калькуляторе, то в сам Risk мы заносим измененное значение
        /// </summary>
        /// <param name="RiskCalculatorValueChanged"></param>
        private void RiskCalculatorValueChanged(object sender, EventArgs e)
        {
            Risk = RiskCalculator.Value +1;
        }

        public int Risk
        {
            get => _risk;
            set
            {
                _risk = value;
                OnPropertyChanged(nameof(Risk));
            }
        }

        public PersonViewModel Person1
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person1));
            }
        }

        public OrganizationViewModel Organization
        {
            get => _organization;
            set
            {
                _organization = value;
                OnPropertyChanged(nameof(Organization));
            }
        }

        public RelayCommand SaveCommand
        {
            get => _saveCommand;
            set
            {
                _saveCommand = value;
                OnPropertyChanged(nameof(SaveCommand));
            }
        }


        public RelayCommand ClearCommand
        {
            get => _clearCommand;
            set
            {
                _clearCommand = value;
                OnPropertyChanged(nameof(ClearCommand));
            }
        }

        private void Save(object parameter)
        {
            var check = new CheckUNP();
            if (check.UNPchecher(Organization.UNPOrg) == true)
            {
                MessageBox.Show("Организация с таким УНП уже существует!", "Упс...", MessageBoxButton.OK, MessageBoxImage.Error);
                //MaterialMessageBox.ShowError( @" Это сообщение об ошибке "); 

                return;
            }
           

            if (MessageBox.Show("Сохранить организацию?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                _newOrgrepo.AddNewOrganizationToDB(OrganizationMapper.OrganizationViewModelToOrganizationModel(Organization), PersonMapper.PersonViewModelToPersonModel(Person1));
                MessageBox.Show("Данные сохранены в базу данных!");
                Clear(this);
            }
        }

        private void Clear(object parameter)
        {
            Organization.CLear();
            Person1.Clear();
        }

        //<summary>
        //? знак после Organization для того, чтобы не словить исключение на NULL если онт туда придет.Он проверчет является ли Org нулом,
        //то Validator.IsValid не отрабатывается(не отрабатывается)
        //?? - если конструкция перед этими ?? равна NULL?, то мы в if не зайдем, а сразу перейдем к последнему  return false
        //</summary>
        private bool CanSave(object parameter)
        {
            if ((Organization?.Validator.IsValid ?? false) && (Person1?.Validator.IsValid ?? false))
                return true;
            return false;
        }


    }
}
