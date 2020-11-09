using Kontragent.ViewModel.Autofill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Repository.RepositoryInterface
{
   public interface IAutofilInterface
    {
        public AutoFillKontragentViewModel AutoFilKontra(string UNP); 
       
    }
}
