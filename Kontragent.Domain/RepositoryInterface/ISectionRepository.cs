using Kontragent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain
{
   public interface ISectionRepository
    {
        public List<SectionModel> GetSections();
    }
}
