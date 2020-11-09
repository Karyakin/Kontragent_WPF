using Kontragent.Domain.Models.Person;
using Kontragent.ViewModel.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
    public class SearchMapperPers
    {
        public static PersonModel SearchWievModelPersToPersonModel(SearchWievModelPers searchWievModelPers)
        {
            var PersModel = new PersonModel
            {
                HeadName = searchWievModelPers.HeadName,
                OwnerName = searchWievModelPers.OwnerName,
                PrevLiquidated = searchWievModelPers.PrevLiquidated,
                PrevBankruptcy = searchWievModelPers.PrevBankruptcy,
                PrevStateDebt = searchWievModelPers.PrevStateDebt,
                PrevTaxDebt = searchWievModelPers.PrevTaxDebt,
                PrevExecuteProc = searchWievModelPers.PrevExecuteProc,
                NegativDataPers = searchWievModelPers.NegativDataPers,
                DescriptionPers = searchWievModelPers.DescriptionPers,
                СountryPers = searchWievModelPers.CountyrPers,
                SelectedCountryPers = searchWievModelPers.SelectedCountryPers?.NameCountry,
                
            };
            return PersModel;
        }

        public static SearchWievModelPers PersonModelToSearchViewModelPers(PersonModel searchWievModelPers)
        {
            var personSearchWievModel = new SearchWievModelPers
            {
                HeadName = searchWievModelPers.HeadName,
                OwnerName = searchWievModelPers.OwnerName,
                PrevLiquidated = searchWievModelPers.PrevLiquidated,
                PrevBankruptcy = searchWievModelPers.PrevBankruptcy,
                PrevStateDebt = searchWievModelPers.PrevStateDebt,
                PrevTaxDebt = searchWievModelPers.PrevTaxDebt,
                PrevExecuteProc = searchWievModelPers.PrevExecuteProc,
                NegativDataPers = searchWievModelPers.NegativDataPers,
                DescriptionPers = searchWievModelPers.DescriptionPers,
                CountyrPers = searchWievModelPers.СountryPers
            };
            return personSearchWievModel;
        }
    }
}
