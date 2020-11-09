using Kontragent.Domain.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.RepositoryInterface
{
    public interface IPersonRepository
    {
        public PersonModel AddPersons();
    }
}
