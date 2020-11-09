using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.RiskInterface
{
    /// <summary>
    /// Интерфейс унаследован от IRiskCheckBoxParametr со свойством  bool Value, 
    /// а сам интерфейс IRiskCheckBoxParametr унаследован от  интерфейса IRiskParametr со свойством int Risk
    /// так тянутся от общего к часному все значения.
    /// Нам это нужно для того, чтобы в калькуляторе разделять негатив и позити, т.к. в зависимости от типа принимаемого параметра калькулятор будет считать по разному
    /// </summary>
    public interface INegativeRiskCheckBoxParametr : IRiskCheckBoxParametr
    {
    }
}
