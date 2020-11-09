using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Model
{
   public class UpdatePersModel
    {

        #region Combobox
        public string СountryPers { get; set; }
        #endregion

        #region TextBox
        public string OwnerName { get; set; }
        public string HeadName { get; set; }
        public string DescriptionPers { get; set; }
        public string SelectedCountryPers { get; set; }
        public int RiskLevel { get; set; }




        #endregion

        #region CheckBox
        public bool PrevLiquidated { get; set; }
        public bool PrevBankruptcy { get; set; }
        public bool PrevStateDebt { get; set; }
        public bool PrevTaxDebt { get; set; }

        public bool PrevExecuteProc { get; set; }
        public bool NegativDataPers { get; set; }
        #endregion

    }
}
