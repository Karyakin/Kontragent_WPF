using Kontragent.Domain.Models.Organization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Kontragent.Domain.RepositoryInterface
{
    public interface IOracleInfoRepository
    {
        // public PersonModel OracleGetPers();



       public OrganizationModel OracleGetOrg(string UNP);

        
    }
}
