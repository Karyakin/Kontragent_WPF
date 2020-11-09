using Kontragent.Domain.Models.Person;
using Kontragent.ViewModel.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
    public static class PersonMapper
    {
        public static PersonModel PersonViewModelToPersonModel(PersonViewModel personViewModel)
        {
            var newPerson = new PersonModel
            {
                HeadName = personViewModel.HeadName,
                OwnerName = personViewModel.OwnerName,
                PrevLiquidated = personViewModel.PrevLiquidated.Value,
                PrevBankruptcy = personViewModel.PrevBankruptcy.Value,
                PrevStateDebt = personViewModel.PrevStateDebt.Value,
                PrevTaxDebt = personViewModel.PrevTaxDebt.Value,
                PrevExecuteProc = personViewModel.PrevExecuteProc.Value,
                NegativDataPers = personViewModel.NegativDataPers.Value,
                СountryPers = personViewModel.SelectedCountry.NameCountry,
                DescriptionPers = personViewModel.DescriptionPers,
                
            };
            return newPerson;
        }
    }
}
