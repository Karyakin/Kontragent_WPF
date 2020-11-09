using Kontragent.Domain.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.Models.Organization
{
    public class KontragentModel
    {
        public OrganizationModel Organization { get; set; }
        public PersonModel  Person { get; set; }

        public KontragentModel()
        {

        }

        public KontragentModel(OrganizationModel organization, PersonModel person)
        {
            Organization = organization;
            Person = person;
        }

    }
}
