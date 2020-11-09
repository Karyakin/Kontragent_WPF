using Kontragent.Domain.Models;
using Kontragent.Domain.Repository;
using Kontragent.Domain.RepositoryInterface;
using Kontragent.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Search
{
    public class SearchWievModelPers : BaseViewModel
    {

        private ICountryRepository _countryRepository;
        public bool _prevLiquidated;
        public bool _prevBankruptcy;
        public bool _prevStateDebt;
        public bool _prevTaxDebt;
        public bool _prevExecuteProc;
        public bool _negativDataPers;
     
        public bool _descriptionPersBool;
        public bool _forcedDeposite;
        private bool _descriptionORG;
        private bool _brokerOpinion;

        private bool _sectionHeadOpinion;
        private bool _auditorOpinion;
        private bool _headNameBool;
        private bool _updateAuditorBool;
        private bool _auditorBool;
        private bool _depositBool;
        private bool _recomendDepositBool;
        private bool _countryPersBool;
        private bool _checkDateOrgBool;
        private bool _riscLevelBool;
        private bool _descriptionOrgBool;




        public string _descriptionPers;
        private string _ownerName;
        private bool _ownerNameBool;
        private string _headName;
        private string _countyrPers;


        public SearchWievModelPers()
        {
            _countryRepository = new CountryRepository();  //создаем экземпляр класса CountryRepository, который унаследован от интрефейса ICountryRepository
            List<CountryModel> countries = _countryRepository.GetCountries();// создаем список объектов с типом CountryModel при помощи метода обязательного (Интрерфес) методом GetCountries из репы
            Countries = CountryMapper.CountryModelToCountryViewModel(countries);// при помощи статического метода CountryModelToCountryViewModel из класса CountryMapper приводим тип из Модели во Вью модель, чтобы наша вью модель могла работать с данными 

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


        private CountryViewModel _selectedCountryPers;

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

        public string CountyrPers
        {
            get => _countyrPers;
            set
            {
                _countyrPers = value;
                OnPropertyChanged(nameof(CountyrPers));
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
            get => _descriptionPers;
            set
            {
                _descriptionPers = value;
                OnPropertyChanged(nameof(DescriptionPers));
            }
        }



        public bool PrevLiquidated
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

        public bool ForcedDeposite
        {
            get => _forcedDeposite;
            set
            {
                _forcedDeposite = value;
                OnPropertyChanged(nameof(ForcedDeposite));
            }
        }

        public bool DescriptionORG
        {
            get => _descriptionORG;
            set
            {
                _descriptionORG = value;
                OnPropertyChanged(nameof(DescriptionORG));
            }
        }

        public bool BrokerOpinion
        {
            get => _brokerOpinion;
            set
            {
                _brokerOpinion = value;
                OnPropertyChanged(nameof(BrokerOpinion));
            }
        }

        public bool SectionHeadOpinion
        {
            get => _sectionHeadOpinion;
            set
            {
                _sectionHeadOpinion = value;
                OnPropertyChanged(nameof(SectionHeadOpinion));
            }
        }

        public bool AuditorOpinion
        {
            get => _auditorOpinion;
            set
            {
                _auditorOpinion = value;
                OnPropertyChanged(nameof(AuditorOpinion));
            }
        }

        public bool DescriptionPersBool
        {
            get => _descriptionPersBool;
            set
            {
                _descriptionPersBool = value;
                OnPropertyChanged(nameof(DescriptionPersBool));
            }
        }


        public bool OwnerNameBool
        {
            get => _ownerNameBool;
            set
            {
                _ownerNameBool = value;
                OnPropertyChanged(nameof(OwnerNameBool));
            }
        }
        public bool HeadNameBool
        {
            get => _headNameBool;
            set
            {
                _headNameBool = value;
                OnPropertyChanged(nameof(HeadNameBool));
            }
        }

        public bool UpdateAuditorBool
        {
            get => _updateAuditorBool;
            set
            {
                _updateAuditorBool = value;
                OnPropertyChanged(nameof(UpdateAuditorBool));
            }
        }

        public bool AuditorBool
        {
            get => _auditorBool;
            set
            {
                _auditorBool = value;
                OnPropertyChanged(nameof(AuditorBool));
            }
        }

        public bool DepositBool
        {
            get => _depositBool;
            set
            {
                _depositBool = value;
                OnPropertyChanged(nameof(DepositBool));
            }
        }


        public bool RecomendDepositBool
        {
            get => _recomendDepositBool;
            set
            {
                _recomendDepositBool = value;
                OnPropertyChanged(nameof(RecomendDepositBool));
            }
        }
        public bool СountryPersBool
        {
            get => _countryPersBool;
            set
            {
                _countryPersBool = value;
                OnPropertyChanged(nameof(СountryPersBool));
            }
        }

        public bool CheckDateOrgBool
        {
            get => _checkDateOrgBool;
            set
            {
                _checkDateOrgBool = value;
                OnPropertyChanged(nameof(CheckDateOrgBool));
            }
        }
        
        public bool RiscLevelBool
        {
            get => _riscLevelBool;
            set
            {
                _riscLevelBool = value;
                OnPropertyChanged(nameof(RiscLevelBool));
            }
        }

        public bool DescriptionOrgBool
        {
            get => _descriptionOrgBool;
            set
            {
                _descriptionOrgBool = value;
                OnPropertyChanged(nameof(DescriptionOrgBool));
            }
        }


      
    }
}
