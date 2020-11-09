using Kontragent.ViewModel.Risk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Model
{
   public class UpdateOrgModel  
    {
        public DateTime CreateDateOrg;///Правил
        public string SharedVariable { get; set; }
        # region Combobox
        public string CountyrOrg { get; set; }
        public string SelectedCountry { get; set; }

        public string NameSection { get; set; }
        public string SelectedSection { get; set; }
        #endregion

        #region TextBox
        public string UNPOrg { get; set; }
        public string ShortNameOrg { get; set; }
        public string FullNameOrg { get; set; }
        public string DescriptionOrg { get; set; }

        public string BrokerOpinion { get; set; }
        public string SectionHeadOpinion { get; set; }
        public string AuditorOpinion { get; set; }
        public string LoginUser { get; set; }

        #endregion

        #region CheckBox
        public bool OwnershipOrg { get; set; }
        public bool TaxDebt { get; set; }
        public bool DebtsEnforcementDocuments { get; set; }
        public bool FalseBusiness { get; set; }
        public bool SpecialRisc { get; set; }
        public bool ExecuteProc { get; set; }
        public bool BankruptcyProc { get; set; }
        public bool LiquidationProc { get; set; }
        public bool Resident { get; set; }// на view не бутет отобраджатся. Признак будет получатся из комбобокса стран автоматически.
        public bool NotResident { get; set; }// на view не бутет отобраджатся. Признак будет получатся из комбобокса стран автоматически.
        public bool BrokerClient { get; set; }
        public bool PrevBrokerClient { get; set; }
        public bool Tradingexperience { get; set; }
        public bool Trader { get; set; }//по умолчанию трейдер, если становится клиентом брокера по галочке меняется
        public bool Manufacturer { get; set; }
        public bool FirstAccred { get; set; } // по умолчанию у всех первичная организация до нажатия на повторная аккредитация
        public bool SecondAccred { get; set; }
        public bool TradingDisorders { get; set; }
        public bool NegativData { get; set; }
        public bool Reputation { get; set; }
        public bool ExchengeTradingDisorders { get; set; }
        public bool ForcedDeposite { get; set; }


        public string Auditor { get; set; }
        public string UpdateAuditor { get; set; }
        public int RiscLevel { get; set; }
        public int RiscLevelLess { get; set; }
        public int RiscLevelMore { get; set; }
        public string Deposit { get; set; }
        public string RecomendDeposit { get; set; }


        public DateTime CheckDateOrg { get; set; }


        public DateTime CreatedateOrgSTART { get; set; }
        public DateTime CreatedateOrgFINAL { get; set; }

        public DateTime CheckDateOrgSTART { get; set; }
        public DateTime CheckDateOrgFINAL { get; set; }

        #endregion
    }
}
