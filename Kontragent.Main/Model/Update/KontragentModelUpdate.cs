using Kontragent.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Model.Update
{
   public class KontragentModelUpdate : BaseViewModel
    {

        public UpdateOrgModel OrgForUpdate { get; set; }


        public UpdatePersModel PersForUpdate { get; set; }

        public KontragentModelUpdate()
        {
          
        }

        public KontragentModelUpdate(UpdateOrgModel orgModelForUpdate, UpdatePersModel persModelForUpdate)
        {
            OrgForUpdate = orgModelForUpdate;
            PersForUpdate = persModelForUpdate;
        }

       
      
    }
}
