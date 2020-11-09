using Kontragent.Domain.Models.Organization;
using Kontragent.ViewModel.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Repository.RepositoryInterface
{
    public interface IUpdateRepositoryInterface
    {

        public KontragentModel SelectForUpdate(string organizationModel);
    }
}
