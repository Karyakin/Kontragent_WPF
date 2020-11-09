using Kontragent.Commands;
using Kontragent.Domain;
using Kontragent.Domain.Models;
using Kontragent.Domain.Repository;
using Kontragent.Domain.RepositoryInterface;
using Kontragent.Helper;
using Kontragent.Mappers;
using Kontragent.Model;
using Kontragent.Model.Update;
using Kontragent.Repository.Update;
using Kontragent.ViewModel.Person;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kontragent.ViewModel.Update
{
    public class UpdateViewModel : BaseViewModel
    {
        private string _UNPOrg;
        private string _shortNameOrg;
        private string _fullNameOrg;
      
        private ICountryRepository _countryRepository;
        private ISectionRepository _sectionRepository;

        private SectionViewModel _selectedSection;
        private string _sharedVariable;
        public List<SectionViewModel> _section;

        private RelayCommand _delOrg;
        private RelayCommand _clean;
        private CountryViewModel _selectedCountry;
        private RelayCommand _updataOrg;
        private RelayCommand _selectOrg;
        UpdateOrgModel updateModel;
        UpdateRepository upsateRepo;

        private UpdatePersViewModel _person;
        private UpdateOrgViewModel _organization;
        KontragentModelUpdate kontragentModelUpdate;

        public UpdateViewModel()
        {
            UpdataOrg = new RelayCommand(UpdateOrganization);
            Clean = new RelayCommand(Clear);
            SelectOrg = new RelayCommand(SelectForUpdate);
            DelOrg = new RelayCommand(DeleteOrg);

            updateModel = new UpdateOrgModel();
            upsateRepo = new UpdateRepository();

            _countryRepository = new CountryRepository();  //создаем экземпляр класса CountryRepository, который унаследован от интрефейса ICountryRepository
            List<CountryModel> countries = _countryRepository.GetCountries();// создаем список объектов с типом CountryModel при помощи метода обязательного (Интрерфес) методом GetCountries из репы
            var countryVM = CountryMapper.CountryModelToCountryViewModel(countries);// при помощи статического метода CountryModelToCountryViewModel из класса CountryMapper приводим тип из Модели во Вью модель, чтобы наша вью модель могла работать с данными 

            _sectionRepository = new SectionRepository();
            List<SectionModel> sections = _sectionRepository.GetSections();
            var sectionVM = SectionMappers.SectionModelToSectionViewModel(sections);

            Countries = countryVM;
            Section = sectionVM;

            Person = new UpdatePersViewModel(countryVM)
            {
            };

            Organization = new UpdateOrgViewModel(countryVM, sectionVM)
            {
                CreateDateOrg = new DateTime()
            };
        }



        public void UpdateOrganization(object obj)
        {
            upsateRepo.UpdOrg(this);
            ClearClass.Clear(this);
        }

        public void Clear(object obj)
        {
            ClearClass.Clear(this);
        }
        private void SelectForUpdate(object obj)
        {
            updateModel = UpdateMapper.OrganizationViewModelToOrganizationModel(this);
            kontragentModelUpdate = upsateRepo.FindOrgForUpdate(updateModel);
            Organization.UNPOrg = kontragentModelUpdate.OrgForUpdate?.UNPOrg;
            Organization.FullNameOrg = kontragentModelUpdate.OrgForUpdate?.FullNameOrg;
            Organization.ShortNameOrg = kontragentModelUpdate.OrgForUpdate?.ShortNameOrg;
            Organization.BrokerOpinion = kontragentModelUpdate.OrgForUpdate?.BrokerOpinion;
            Organization.AuditorOpinion = kontragentModelUpdate.OrgForUpdate?.AuditorOpinion;
            Organization.SectionHeadOpinion = kontragentModelUpdate.OrgForUpdate?.SectionHeadOpinion;
            Organization.DescriptionOrg = kontragentModelUpdate.OrgForUpdate?.DescriptionOrg;
            Organization.CreateDateOrg = kontragentModelUpdate.OrgForUpdate.CreateDateOrg;
            Organization.SelectedCountry = Countries.FirstOrDefault(x => x.NameCountry == kontragentModelUpdate.OrgForUpdate.CountyrOrg);
            Organization.SelectedSection = Section.FirstOrDefault(x => x.NameSection == kontragentModelUpdate.OrgForUpdate.NameSection);
            Organization.OwnershipOrg = kontragentModelUpdate.OrgForUpdate.OwnershipOrg;
            Organization.TaxDebt = kontragentModelUpdate.OrgForUpdate.TaxDebt;
            Organization.DebtsEnforcementDocuments = kontragentModelUpdate.OrgForUpdate.DebtsEnforcementDocuments;
            Organization.FalseBusiness = kontragentModelUpdate.OrgForUpdate.FalseBusiness;
            Organization.SpecialRisc = kontragentModelUpdate.OrgForUpdate.SpecialRisc;
            Organization.ExecuteProc = kontragentModelUpdate.OrgForUpdate.ExecuteProc;
            Organization.BankruptcyProc = kontragentModelUpdate.OrgForUpdate.BankruptcyProc;
            Organization.LiquidationProc = kontragentModelUpdate.OrgForUpdate.LiquidationProc;
            Organization.BrokerClient = kontragentModelUpdate.OrgForUpdate.BrokerClient;
            Organization.PrevBrokerClient = kontragentModelUpdate.OrgForUpdate.PrevBrokerClient;
            Organization.Manufacturer = kontragentModelUpdate.OrgForUpdate.Manufacturer;
            Organization.NegativData = kontragentModelUpdate.OrgForUpdate.NegativData;
            Organization.Reputation = kontragentModelUpdate.OrgForUpdate.Reputation;
            Organization.ExchengeTradingDisorders = kontragentModelUpdate.OrgForUpdate.ExchengeTradingDisorders;
            Organization.SecondAccred = kontragentModelUpdate.OrgForUpdate.SecondAccred;
            Organization.ForcedDeposite = kontragentModelUpdate.OrgForUpdate.ForcedDeposite;
            Organization.Deposit = kontragentModelUpdate.OrgForUpdate.Deposit;
            Organization.RecomendDeposit = kontragentModelUpdate.OrgForUpdate.RecomendDeposit;
            Person.DescriptionPers = kontragentModelUpdate.PersForUpdate?.DescriptionPers;
            Person.HeadName = kontragentModelUpdate.PersForUpdate?.HeadName;
            Person.OwnerName = kontragentModelUpdate.PersForUpdate?.OwnerName;
            Person.SelectedCountry = Countries.FirstOrDefault(x => x.NameCountry == kontragentModelUpdate.PersForUpdate.СountryPers);
            Person.PrevLiquidated = kontragentModelUpdate.PersForUpdate.PrevBankruptcy;
            Person.PrevBankruptcy = kontragentModelUpdate.PersForUpdate.PrevBankruptcy;
            Person.PrevStateDebt = kontragentModelUpdate.PersForUpdate.PrevStateDebt;
            Person.PrevTaxDebt = kontragentModelUpdate.PersForUpdate.PrevTaxDebt;
            Person.PrevExecuteProc = kontragentModelUpdate.PersForUpdate.PrevExecuteProc;
            Person.NegativDataPers = kontragentModelUpdate.PersForUpdate.NegativDataPers;

            Organization.RiskLevel = kontragentModelUpdate.OrgForUpdate.RiscLevel.ToString();

        }

        public RelayCommand SelectOrg
        {
            get => _selectOrg;
            set
            {
                _selectOrg = value;
                OnPropertyChanged(nameof(SelectOrg));
            }
        }
        public RelayCommand Clean
        {
            get => _clean;
            set
            {
                _clean = value;
                OnPropertyChanged(nameof(Clean));
            }
        }
        public RelayCommand UpdataOrg
        {
            get => _updataOrg;
            set
            {
                _updataOrg = value;
                OnPropertyChanged(nameof(UpdataOrg));
            }
        }
        public RelayCommand DelOrg
        {
            get => _delOrg;
            set
            {
                _delOrg = value;
                OnPropertyChanged(nameof(DelOrg));
            }
        }

        private void DeleteOrg(object obj)
        {
            upsateRepo.DeleteOrg(this);
            ClearClass.Clear(this);

        }

        public UpdatePersViewModel Person
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
            }
        }

        public UpdateOrgViewModel Organization
        {
            get => _organization;
            set
            {
                _organization = value;
                OnPropertyChanged(nameof(Organization));
            }
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
                OnPropertyChanged(nameof(SelectedSection));
            }
        }

        public string SharedVariable
        {
            get => _sharedVariable;
            set
            {
                _sharedVariable = value;
                OnPropertyChanged(nameof(SharedVariable));
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
    }
}
