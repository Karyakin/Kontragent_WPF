using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.RiskInterface
{
   public interface IRiskCreatedDateParametr : IRiskParametr
    {
        DateTime Value { get;  set; }

    }
}
