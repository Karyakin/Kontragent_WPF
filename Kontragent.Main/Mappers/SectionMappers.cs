using Kontragent.Domain.Models;
using Kontragent.ViewModel.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
   public class SectionMappers
    {

        /// <summary>
        /// Маппер предназначен для того, чтобы полученную из базы Model, которая имеет тип Model, привести к типу ViewModel, чтобы можно было полученные данные 
        /// использовать во ViewModel
        /// </summary>
        /// <param name="SectionModelToSectionViewModel"></param>
        /// <returns></returns>
        public static List<SectionViewModel> SectionModelToSectionViewModel(List<SectionModel> sectionModels)
        {
            var sections = new List<SectionViewModel>();
            foreach (var item in sectionModels)
            {
                var section = new SectionViewModel
                {
                    NameSection = item.NameSection,
                    Risk = item.RiskSection
                };
                sections.Add(section);
            }

            return sections;
        }
    }
}
