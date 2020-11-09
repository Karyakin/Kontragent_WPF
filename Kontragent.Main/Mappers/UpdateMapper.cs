using Kontragent.Model;
using Kontragent.Model.Update;
using Kontragent.ViewModel.Risk;
using Kontragent.ViewModel.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
   public class UpdateMapper
    {
        public static UpdateOrgModel OrganizationViewModelToOrganizationModel(UpdateViewModel updateViewModel)
        {
            var orgForUppdates = new UpdateOrgModel
            {
                UNPOrg = updateViewModel.UNPOrg,
                ShortNameOrg = updateViewModel.ShortNameOrg,
                FullNameOrg = updateViewModel.FullNameOrg,
                SharedVariable = updateViewModel.SharedVariable,
                //OwnershipOrg = updateViewModel.OwnershipOrg
               
            };
            return orgForUppdates;
        }

        public static UpdateOrgModel DateTimeToRiscDateTime(UpdateViewModel updateViewModel)
        {
            var orgForUppdates = new UpdateOrgModel
            {
                UNPOrg = updateViewModel.UNPOrg,
                ShortNameOrg = updateViewModel.ShortNameOrg,
                FullNameOrg = updateViewModel.FullNameOrg,
                SharedVariable = updateViewModel.SharedVariable,
                //OwnershipOrg = updateViewModel.OwnershipOrg.Value

            };
            return orgForUppdates;
        }


        public static UpdateOrgViewModel UpdOrgModelToUpdOrgViewModel(UpdateOrgModel updateOrgModel )
        {
            
            var orgForUppdates = new UpdateOrgViewModel
            {
               //SelectedCountry = updateOrgModel.SelectedCountry?.NameCountry,
                //NameSection = updateOrgModel.NameSection,
              // SelectedSection = updateOrgModel.SelectedSection?.NameSection,
                //CountyrOrg = updateOrgModel.CountyrOrg,
                UNPOrg = updateOrgModel.UNPOrg,
                ShortNameOrg = updateOrgModel.ShortNameOrg,
                FullNameOrg = updateOrgModel.FullNameOrg,
                DescriptionOrg = updateOrgModel.DescriptionOrg,
                BrokerOpinion = updateOrgModel.BrokerOpinion,
                SectionHeadOpinion = updateOrgModel.SectionHeadOpinion,
                AuditorOpinion = updateOrgModel.AuditorOpinion,
                ForcedDeposite = updateOrgModel.ForcedDeposite,
                OwnershipOrg = updateOrgModel.OwnershipOrg
               
            };

            //orgForUppdates.ExchengeTradingDisorders.Value = new UpdateOrgViewModel().OwnershipOrg.Value;
           /* orgForUppdates.OwnershipOrg.Value = updateOrgModel.OwnershipOrg;
            orgForUppdates.TaxDebt.Value = updateOrgModel.TaxDebt;
            orgForUppdates.DebtsEnforcementDocuments.Value = updateOrgModel.DebtsEnforcementDocuments;
            orgForUppdates.FalseBusiness.Value = updateOrgModel.FalseBusiness;
            orgForUppdates.SpecialRisc.Value = updateOrgModel.SpecialRisc;
            orgForUppdates.ExecuteProc.Value = updateOrgModel.ExecuteProc;
            orgForUppdates.BankruptcyProc.Value = updateOrgModel.BankruptcyProc;
            orgForUppdates.LiquidationProc.Value = updateOrgModel.LiquidationProc;
           // orgForUppdates.BrokerClient.Value = updateOrgModel.BrokerClient;
            orgForUppdates.PrevBrokerClient.Value = updateOrgModel.PrevBrokerClient;

            orgForUppdates.Manufacturer.Value = updateOrgModel.Manufacturer;

            orgForUppdates.NegativData.Value = updateOrgModel.NegativData;
            orgForUppdates.Reputation.Value = updateOrgModel.Reputation;
*/


            return orgForUppdates;
        }
        public static UpdateOrgViewModel UpdKontraToUpdOrgViewModel(KontragentModelUpdate updateOrgModel)
        {

            var orgForUppdates = new UpdateOrgViewModel
            {
                UNPOrg = updateOrgModel.OrgForUpdate.UNPOrg,
                ShortNameOrg = updateOrgModel.OrgForUpdate.ShortNameOrg,
                FullNameOrg = updateOrgModel.OrgForUpdate.FullNameOrg,
                DescriptionOrg = updateOrgModel.OrgForUpdate.DescriptionOrg,
                BrokerOpinion = updateOrgModel.OrgForUpdate.BrokerOpinion,
                SectionHeadOpinion = updateOrgModel.OrgForUpdate.SectionHeadOpinion,
                AuditorOpinion = updateOrgModel.OrgForUpdate.AuditorOpinion,
                ForcedDeposite = updateOrgModel.OrgForUpdate.ForcedDeposite,
            };

           // orgForUppdates.ExchengeTradingDisorders.Value = updateOrgModel.OrgForUpdate.ExchengeTradingDisorders;..
          /*  orgForUppdates.OwnershipOrg.Value = updateOrgModel.OrgForUpdate.OwnershipOrg;
            orgForUppdates.TaxDebt.Value = updateOrgModel.OrgForUpdate.TaxDebt;
            orgForUppdates.DebtsEnforcementDocuments.Value = updateOrgModel.OrgForUpdate.DebtsEnforcementDocuments;
            orgForUppdates.FalseBusiness.Value = updateOrgModel.OrgForUpdate.FalseBusiness;
            orgForUppdates.SpecialRisc.Value = updateOrgModel.OrgForUpdate.SpecialRisc;
            orgForUppdates.ExecuteProc.Value = updateOrgModel.OrgForUpdate.ExecuteProc;
            orgForUppdates.BankruptcyProc.Value = updateOrgModel.OrgForUpdate.BankruptcyProc;
            orgForUppdates.LiquidationProc.Value = updateOrgModel.OrgForUpdate.LiquidationProc;
            orgForUppdates.BrokerClient.Value = updateOrgModel.OrgForUpdate.BrokerClient;
            orgForUppdates.PrevBrokerClient.Value = updateOrgModel.OrgForUpdate.PrevBrokerClient;

            orgForUppdates.Manufacturer.Value = updateOrgModel.OrgForUpdate.Manufacturer;

            orgForUppdates.NegativData.Value = updateOrgModel.OrgForUpdate.NegativData;
            orgForUppdates.Reputation.Value = updateOrgModel.OrgForUpdate.Reputation;*/



            return orgForUppdates;
        }


        /* Trader = updateOrgModel.Trader,
         Resident = updateOrgModel.Resident,
         NotResident = updateOrgModel.NotResident,
         SecondAccred = updateOrgModel.SecondAccred,
         FirstAccred = updateOrgModel.FirstAccred,

         CheckDateOrg = updateOrgModel.CheckDateOrg,
         Auditor = updateOrgModel.Auditor,
         UpdateAuditor = updateOrgModel.UpdateAuditor,
         RiscLevelLess = updateOrgModel.RiscLevelLess,
         RiscLevelMore = updateOrgModel.RiscLevelMore,*/

    }
}
