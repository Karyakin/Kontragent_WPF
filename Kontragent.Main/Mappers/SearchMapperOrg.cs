using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Models.Person;
using Kontragent.ViewModel.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
    public class SearchMapperOrg
    {
        public static OrganizationModel SearchWievModelOrgToOrganizationModel(SearchWievModelOrg searc)
        {
            var Organization = new OrganizationModel
            {

                CreatedateOrgSTART = searc.CreatedateOrgSTART,
                CreatedateOrgFINAL = searc.CreatedateOrgFINAL,

                CheckDateOrgSTART = searc.CheckDateOrgSTART,
                CheckDateOrgFINAL = searc.CheckDateOrgFINAL,
                /*//условие ? истина : лдожь
               string.IsNullOrEmpty(_descriptionPers) || string.IsNullOrWhiteSpace(_descriptionPers) ? "нет" : _descriptionPers;*/
                SelectedCountry = searc.SelectedCountry?.NameCountry,
                NameSection = searc.NameSection,
                SelectedSection = searc.SelectedSection?.NameSection,
                CountyrOrg = searc.CountyrOrg,
                UNPOrg = searc.UNPOrg,
                ShortNameOrg = searc.ShortNameOrg,
                FullNameOrg = searc.FullNameOrg,
                DescriptionOrg = searc.DescriptionOrg,
                OwnershipOrg = searc.OwnershipOrg,
                TaxDebt = searc.TaxDebt,
                DebtsEnforcementDocuments = searc.DebtsEnforcementDocuments,
                FalseBusiness = searc.FalseBusiness,
                SpecialRisc = searc.SpecialRisc,
                ExecuteProc = searc.ExecuteProc,
                BankruptcyProc = searc.BankruptcyProc,
                LiquidationProc = searc.LiquidationProc,
                BrokerClient = searc.BrokerClient,
                PrevBrokerClient = searc.PrevBrokerClient,
                Tradingexperience = searc.Tradingexperience,
                Manufacturer = searc.Manufacturer,
                //TradingDisorders = searc.TradingDisorders,
                NegativData = searc.NegativData,
                Reputation = searc.Reputation,
                BrokerOpinion = searc.BrokerOpinion,
                SectionHeadOpinion = searc.SectionHeadOpinion,
                AuditorOpinion = searc.AuditorOpinion,
                ForcedDeposite = searc.ForcedDeposite,
                ExchengeTradingDisorders = searc.ExchengeTradingDisorders,
                Trader = searc.Trader,
                Resident = searc.Resident,
                NotResident = searc.NotResident,
                SecondAccred = searc.SecondAccred,
                FirstAccred = searc.FirstAccred,
                CreatedateOrg = searc.CreatedateOrg,
                CheckDateOrg = searc.CheckDateOrg,
                Auditor = searc.Auditor,
                UpdateAuditor = searc.UpdateAuditor,
                RiscLevelLess = searc.RiscLevelLess,
                RiscLevelMore = searc.RiscLevelMore,
                
            };
            return Organization; 
        }


        public static SearchWievModelOrg OrganizationModelToSearchViewModelOrg(OrganizationModel searc)
        {
            var SearchWievModelOrg = new SearchWievModelOrg
            {

                CreatedateOrgSTART = searc.CreatedateOrgSTART,
                CreatedateOrgFINAL = searc.CreatedateOrgFINAL,
                /*// условие ? истина : лдожь
                string.IsNullOrEmpty(_descriptionPers) || string.IsNullOrWhiteSpace(_descriptionPers) ? "нет" : _descriptionPers;

 */

                // SelectedCountry = searc.SelectedCountry,

                CountyrOrg = searc.CountyrOrg,
                NameSection = searc.NameSection,


                UNPOrg = searc.UNPOrg,
                ShortNameOrg = searc.ShortNameOrg,
                FullNameOrg = searc.FullNameOrg,
                DescriptionOrg = searc.DescriptionOrg,
                OwnershipOrg = searc.OwnershipOrg,
                TaxDebt = searc.TaxDebt,
                DebtsEnforcementDocuments = searc.DebtsEnforcementDocuments,
                FalseBusiness = searc.FalseBusiness,
                SpecialRisc = searc.SpecialRisc,
                ExecuteProc = searc.ExecuteProc,
                BankruptcyProc = searc.BankruptcyProc,
                LiquidationProc = searc.LiquidationProc,
                BrokerClient = searc.BrokerClient,
                PrevBrokerClient = searc.PrevBrokerClient,
                Tradingexperience = searc.Tradingexperience,
                Manufacturer = searc.Manufacturer,
                //TradingDisorders = searc.TradingDisorders,
                NegativData = searc.NegativData,
                Reputation = searc.Reputation,
                BrokerOpinion = searc.BrokerOpinion,
                SectionHeadOpinion = searc.SectionHeadOpinion,
                AuditorOpinion = searc.AuditorOpinion,
                ForcedDeposite = searc.ForcedDeposite,
                ExchengeTradingDisorders = searc.ExchengeTradingDisorders,
                Trader = searc.Trader,
                Resident = searc.Resident,
                NotResident = searc.NotResident,
                SecondAccred = searc.SecondAccred,
                FirstAccred = searc.FirstAccred,
                CreatedateOrg = searc.CreatedateOrg,
                CheckDateOrg = searc.CheckDateOrg,
                Auditor = searc.Auditor,
                UpdateAuditor = searc.UpdateAuditor,
                RiscLevel = searc.RiscLevel,
                RiscLevelMore = searc.RiscLevelMore,
                RiscLevelLess = searc.RiscLevelLess,
                Deposit = searc.Deposit,
                RecomendDeposit = searc.RecomendDeposit
            };
            return SearchWievModelOrg;
        }


    }
}
