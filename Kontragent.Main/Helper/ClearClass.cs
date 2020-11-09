using Kontragent.Model.Update;
using Kontragent.ViewModel.Search;
using Kontragent.ViewModel.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Helper
{
    public static class ClearClass
    {
        public static void Clear(UpdateViewModel kontragentModelUpdate)
        {
            kontragentModelUpdate.Person.HeadName = string.Empty;
            kontragentModelUpdate.Person.OwnerName = string.Empty;
            kontragentModelUpdate.Person.DescriptionPers = string.Empty;
            kontragentModelUpdate.Person.PrevLiquidated = false;
            kontragentModelUpdate.Person.PrevBankruptcy = false;
            kontragentModelUpdate.Person.PrevStateDebt = false;
            kontragentModelUpdate.Person.PrevTaxDebt = false;
            kontragentModelUpdate.Person.PrevExecuteProc = false;
            kontragentModelUpdate.Person.NegativDataPers = false;
            kontragentModelUpdate.Organization.UNPOrg = string.Empty;// OwnerName = string.Empty;
            kontragentModelUpdate.Organization.UNPOrg = string.Empty;
            kontragentModelUpdate.Organization.FullNameOrg = string.Empty;
            kontragentModelUpdate.Organization.ShortNameOrg = string.Empty;
            kontragentModelUpdate.Organization.AuditorOpinion = string.Empty;
            kontragentModelUpdate.Organization.SectionHeadOpinion = string.Empty;
            kontragentModelUpdate.Organization.DescriptionOrg = string.Empty;
            kontragentModelUpdate.Organization.BrokerOpinion = string.Empty;
            kontragentModelUpdate.Organization.CreateDateOrg = DateTime.Now;
            kontragentModelUpdate.Organization.TaxDebt = false;
            kontragentModelUpdate.Organization.DebtsEnforcementDocuments = false;
            kontragentModelUpdate.Organization.FalseBusiness = false;
            kontragentModelUpdate.Organization.SpecialRisc = false;
            kontragentModelUpdate.Organization.ExecuteProc = false;
            kontragentModelUpdate.Organization.BankruptcyProc = false;
            kontragentModelUpdate.Organization.LiquidationProc = false;
            kontragentModelUpdate.Organization.NegativData = false;
            kontragentModelUpdate.Organization.ExchengeTradingDisorders = false;
            kontragentModelUpdate.Organization.Reputation = false;
            kontragentModelUpdate.Organization.OwnershipOrg = false;
            kontragentModelUpdate.Organization.Manufacturer = false;
            kontragentModelUpdate.Organization.BrokerClient = false;
            kontragentModelUpdate.Organization.PrevBrokerClient = false;
            kontragentModelUpdate.Organization.ForcedDeposite = false;
            kontragentModelUpdate.Organization.SecondAccred = false;
            kontragentModelUpdate.Organization.Deposit = string.Empty;
            kontragentModelUpdate.Organization.RecomendDeposit = string.Empty;
            kontragentModelUpdate.SharedVariable = string.Empty;
            kontragentModelUpdate.Organization.RiskLevel = string.Empty;

            kontragentModelUpdate.Organization.SelectedCountry = kontragentModelUpdate.Organization.Countries.First();
            kontragentModelUpdate.Organization.SelectedSection = kontragentModelUpdate.Organization.Section.First();
            kontragentModelUpdate.Person.SelectedCountry = kontragentModelUpdate.Person.Countries.First();
        }



        public static void Clear(SearchViewModel kontragentModelUpdate)
        {
            kontragentModelUpdate.Kontragent.PersonSearc.HeadName = string.Empty;
            kontragentModelUpdate.Kontragent.PersonSearc.OwnerName = string.Empty;
            kontragentModelUpdate.Kontragent.PersonSearc.DescriptionPers = string.Empty;
            kontragentModelUpdate.Kontragent.PersonSearc.PrevLiquidated = false;
            kontragentModelUpdate.Kontragent.PersonSearc.PrevBankruptcy = false;
            kontragentModelUpdate.Kontragent.PersonSearc.PrevStateDebt = false;
            kontragentModelUpdate.Kontragent.PersonSearc.PrevTaxDebt = false;
            kontragentModelUpdate.Kontragent.PersonSearc.PrevExecuteProc = false;
            kontragentModelUpdate.Kontragent.PersonSearc.NegativDataPers = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.UNPOrg = string.Empty;// OwnerName = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.UNPOrg = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.FullNameOrg = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.ShortNameOrg = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.AuditorOpinion = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.SectionHeadOpinion = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.DescriptionOrg = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.BrokerOpinion = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.TaxDebt = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.DebtsEnforcementDocuments = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.FalseBusiness = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.SpecialRisc = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.ExecuteProc = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.BankruptcyProc = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.LiquidationProc = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.NegativData = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.ExchengeTradingDisorders = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.Reputation = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.OwnershipOrg = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.Manufacturer = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.BrokerClient = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.PrevBrokerClient = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.ForcedDeposite = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.SecondAccred = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.Deposit = string.Empty;
            kontragentModelUpdate.Kontragent.OrganizationSearc.RecomendDeposit = string.Empty;
   
            kontragentModelUpdate.Kontragent.OrganizationSearc.Tradingexperience = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.Resident = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.NotResident = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.Trader = false;
            kontragentModelUpdate.Kontragent.OrganizationSearc.FirstAccred = false;

            kontragentModelUpdate.Kontragent.PersonSearc.СountryPersBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.OwnerNameBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.UpdateAuditorBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.DepositBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.RecomendDepositBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.HeadNameBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.DescriptionOrgBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.DescriptionPersBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.RiscLevelBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.CheckDateOrgBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.AuditorBool = false;
            kontragentModelUpdate.Kontragent.PersonSearc.BrokerOpinion = false;
            kontragentModelUpdate.Kontragent.PersonSearc.SectionHeadOpinion = false;
            kontragentModelUpdate.Kontragent.PersonSearc.AuditorOpinion = false;

            kontragentModelUpdate.Kontragent.OrganizationSearc.SelectedCountry = kontragentModelUpdate.Kontragent.OrganizationSearc.Countries.First();
            kontragentModelUpdate.Kontragent.OrganizationSearc.SelectedSection = kontragentModelUpdate.Kontragent.OrganizationSearc.Section.First();
            kontragentModelUpdate.Kontragent.PersonSearc.SelectedCountryPers = kontragentModelUpdate.Kontragent.PersonSearc.Countries.First();



            kontragentModelUpdate.Kontragent.OrganizationSearc.CreatedateOrgSTART = new DateTime(1980, 01, 01);
            kontragentModelUpdate.Kontragent.OrganizationSearc.CreatedateOrgFINAL = DateTime.Now;

            kontragentModelUpdate.Kontragent.OrganizationSearc.CheckDateOrgSTART = DateTime.Today;
            kontragentModelUpdate.Kontragent.OrganizationSearc.CheckDateOrgFINAL = DateTime.Today.AddDays(1);
            
            kontragentModelUpdate.Kontragent.OrganizationSearc.RiscLevelLess = 83;
            kontragentModelUpdate.Kontragent.OrganizationSearc.RiscLevelMore = 0;
        }
    }
}
