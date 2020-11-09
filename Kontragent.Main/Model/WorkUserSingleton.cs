using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Model
{
   public sealed class WorkUserSingleton
    {
      /*  LoginUser { get; set; }
        public string Department { get; set; }
*/

        public WorkUserModel WorkUser { get; private set; }

        public static WorkUserSingleton sourse = null;
        //private string _name;

        protected WorkUserSingleton(WorkUserModel workUser)
        {
            WorkUser = workUser;
        }


        public static WorkUserSingleton Initialize(WorkUserModel workUser)
        {
            if (sourse == null)
                sourse = new WorkUserSingleton(workUser);
            return sourse;
        }

    }
}
