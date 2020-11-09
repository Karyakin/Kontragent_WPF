using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Models.Person;
using Kontragent.View.CustomControl;
using Kontragent.ViewModel.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Repository.RepositoryInterface
{
   public interface ISearchRepository
    {
        public List<KontragentModel> GeneralSearch(OrganizationModel organization, PersonModel person);
       
    }
}
