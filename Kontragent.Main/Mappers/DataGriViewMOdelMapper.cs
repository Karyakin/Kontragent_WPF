using Kontragent.Domain.Models.Organization;
using Kontragent.ViewModel.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
    public class DataGriViewMOdelMapper
    {
        public static ObservableCollection<KontragentDataGridItemViewModel> KontragModelToKontraDataGriViewMOdelMapper(List<KontragentModel> kontragentModel)
        {
            var dataGrigItems = new ObservableCollection<KontragentDataGridItemViewModel>();

            foreach (var item in kontragentModel)
            {
                var dataGrigItem = new KontragentDataGridItemViewModel
                {
                    UNPOrg = item.Organization.UNPOrg,
                    CountyrOrg = item.Organization.CountyrOrg,
                    NameSection = item.Organization.NameSection,
                    ShortNameOrg = item.Organization.ShortNameOrg,
                    FullNameOrg = item.Organization.FullNameOrg,
                    DescriptionOrg = item.Organization.DescriptionOrg,
                    BrokerOpinion = item.Organization.BrokerOpinion,
                    SectionHeadOpinion = item.Organization.SectionHeadOpinion,
                    AuditorOpinion = item.Organization.AuditorOpinion,
                    CreatedateOrg = item.Organization.CreatedateOrg,
                    CheckDateOrg = item.Organization.CheckDateOrg,
                    Auditor = item.Organization.Auditor,
                    UpdateAuditor = item.Organization.UpdateAuditor,
                    Deposit = item.Organization.Deposit,
                    RecomendDeposit = item.Organization.RecomendDeposit,
                    RiscLevel = item.Organization.RiscLevel,

                    HeadName = item.Person.HeadName,
                    OwnerName = item.Person.OwnerName,
                    DescriptionPers = item.Person.DescriptionPers,
                    CountyrPers = item.Person.СountryPers,
                };
                dataGrigItems.Add(dataGrigItem);
            }
            return dataGrigItems;
        }


    }
}
