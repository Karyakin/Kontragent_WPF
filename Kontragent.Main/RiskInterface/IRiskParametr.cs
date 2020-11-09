using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.RiskInterface
{
    public interface IRiskParametr
    {
        /// <summary>
        /// Это свойство из интерфейса IRiskParametr, содержит численное значение(степень риска)
        /// </summary>
        int Risk { get; set; }
    }
}
