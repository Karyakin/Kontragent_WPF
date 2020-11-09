using Kontragent.Domain.Models;
using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Repository;
using Kontragent.Model;
using Kontragent.ViewModel;
using Kontragent.ViewModel.Organization;
using Kontragent.ViewModel.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
    public static class OrganizationMapper
    {
        public static OrganizationModel OrganizationViewModelToOrganizationModel(OrganizationViewModel organizationViewModel)
        {
            var newOrganization = new OrganizationModel
            {
                CountyrOrg = organizationViewModel?.SelectedCountry.NameCountry,
                NameSection = organizationViewModel?.SelectedSection.NameSection,
                UNPOrg = organizationViewModel.UNPOrg,
                ShortNameOrg = organizationViewModel.ShortNameOrg,
                FullNameOrg = organizationViewModel.FullNameOrg,
                DescriptionOrg = organizationViewModel.DescriptionORG,
                OwnershipOrg = organizationViewModel.OwnershipOrg.Value,
                TaxDebt = organizationViewModel.TaxDebt.Value,
                DebtsEnforcementDocuments = organizationViewModel.DebtsEnforcementDocuments.Value,
                FalseBusiness = organizationViewModel.FalseBusiness.Value,
                SpecialRisc = organizationViewModel.SpecialRisc.Value,
                ExecuteProc = organizationViewModel.ExecuteProc.Value,
                BankruptcyProc = organizationViewModel.BankruptcyProc.Value,
                LiquidationProc = organizationViewModel.LiquidationProc.Value,
                BrokerClient = organizationViewModel.BrokerClient.Value,
                PrevBrokerClient = organizationViewModel.PrevBrokerClient.Value,
                Tradingexperience = organizationViewModel.Tradingexperience,
                Manufacturer = organizationViewModel.Manufacturer.Value,
               // TradingDisorders = organizationViewModel.TradingDisorders.Value,
                NegativData = organizationViewModel.NegativData.Value,
                Reputation = organizationViewModel.Reputation.Value,
                BrokerOpinion = organizationViewModel.BrokerOpinion,
                SectionHeadOpinion = organizationViewModel.SectionHeadOpinion,
                AuditorOpinion = organizationViewModel.AuditorOpinion,
                ForcedDeposite = organizationViewModel.ForcedDeposite,
                ExchengeTradingDisorders = organizationViewModel.ExchengeTradingDisorders.Value,
                Trader = organizationViewModel.Trader,
                Resident = organizationViewModel.Resident,
                SecondAccred = organizationViewModel.SecondAccred,
                FirstAccred = organizationViewModel.FirstAccred,
                CreatedateOrg = organizationViewModel.CreatedateOrg.Value,
                Auditor = WorkUserSingleton.sourse.WorkUser.LoginUser
                                              
            };
            return newOrganization;
        }

     

    }
}
