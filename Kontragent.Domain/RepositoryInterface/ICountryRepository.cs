using Kontragent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.RepositoryInterface
{
   public interface ICountryRepository
    {
       public List<CountryModel> GetCountries();

    }
}
