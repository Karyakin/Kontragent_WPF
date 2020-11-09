using Kontragent.Domain.Models.Person;
using Kontragent.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.Repository
{
   public  class PersonRepository : IPersonRepository
    {
        public PersonModel AddPersons()
        {
            var pers = new PersonModel();
            return pers;
        }

    }
}
