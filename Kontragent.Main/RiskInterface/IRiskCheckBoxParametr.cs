using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.RiskInterface
{
   public interface IRiskCheckBoxParametr : IRiskParametr
    {
        /// <summary>
        /// Это свойство из интерфейса IRiskCheckBoxParametr, содержит булевское значение(для определения нажат или нет)
        /// </summary>
        bool Value { get; set; }
    }
}
