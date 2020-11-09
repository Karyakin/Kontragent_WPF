using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.RepositoryInterface
{
   public interface INewOrganizationRepository
    {
        public void AddNewOrganizationToDB(OrganizationModel organizationModel, PersonModel personModel);
        
    }
}
