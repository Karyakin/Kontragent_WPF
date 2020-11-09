using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Search
{
   public class KontragentDataGridItemViewModel : BaseViewModel
    {
        private string _UNPOrg;
        private string _shortNameOrg;
        private string _fullNameOrg;
        private string _countyrOrg;
        private DateTime _createdateOrg;
        private string _descriptionOrg;
        private string _auditorOpinion;
        private string _brokerOpinion;
        private string _sectionHeadOpinion;
        private string _nameSection;
        private string _auditor;
        private string _updateAuditor;
        private string _deposit;
        private string _recomendDeposit;
        private int _riscLevel;
        private DateTime _checkDateOrg;

        private string _ownerName;
        private string _headName;
        private string _countyrPers;
        public string _descriptionPers;

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
                OnPropertyChanged(nameof(CreatedateOrgShort));
            }
        }

        public string CreatedateOrgShort => CreatedateOrg.Date.ToShortDateString();

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






    }


}
