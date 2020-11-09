using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.Models
{
   public class RiskModel
    {
        public int OwnershipOrg { get; set; }
        public int TaxDebt { get; set; }
        public int DebtsEnforcementDocuments { get; set; }
        public int FalseBusiness { get; set; }
        public int SpecialRisc { get; set; }
        public int ExecuteProc { get; set; }
        public int BankruptcyProc { get; set; }
        public int LiquidationProc { get; set; }
        public int Resident { get; set; }
        public int BrokerClient { get; set; }
        public int Tradingexperience { get; set; }
        public int Manufacturer { get; set; }
        public int ExchengeTradingDisorders { get; set; }
        public int NegativData { get; set; }
        public int Reputation { get; set; }
        public int PrevLiquidated { get; set; }
        public int PrevBankruptcy { get; set; }
        public int PrevStateDebt { get; set; }
        public int PrevTaxDebt { get; set; }
        public int PrevExecuteProc { get; set; }
        public int RiskSectionORG { get; set; }
        public int RiskCountryORG { get; set; }
        public int PrevBrokerClient { get; set; }
        public int SecondAccred { get; set; }
        public int NegativDataPers { get; set; }
        public int AgeOrg { get; set; }
        public int ForcedDeposite { get; set; }
    }
}
