using Kontragent.ViewModel;
using Kontragent.Domain.Models;
using System.Collections.Generic;

namespace Kontragent.Mappers
{
   public static class CountryMapper
    {
        /// <summary>
        /// Маппер предназначен для того, чтобы полученную из базы Model, которая имеет тип Model, привести к типу ViewModel, чтобы можно было полученные данные 
        /// использовать во ViewModel
        /// </summary>
        /// <param name="CountryModelToCountryViewModel"></param>
        /// <returns></returns>
        public static List<CountryViewModel> CountryModelToCountryViewModel(List<CountryModel> countryModel) 
        {
            var countries = new List<CountryViewModel>();
            foreach (var item in countryModel)
            {
                var country = new CountryViewModel
                {
                    NameCountry = item.NameCountry,
                    Risk = item.RiskCountry
                };
                countries.Add(country);
            }

            return countries;
        }

        public static CountryViewModel CountryModelToCountryViewModelToAutoFil(string countryModel)// можно удалить
        {

            var country = new CountryViewModel
            {
                NameCountry = countryModel
            };
            return country;
        }
    }
}
