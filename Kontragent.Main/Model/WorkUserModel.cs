using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Model
{
    public class WorkUserModel
    {
        public string LoginUser { get; private set; }
        public string Department { get; private set; }

        public WorkUserModel(string loginUser, string department)
        {
            LoginUser = loginUser;
            Department = department;
        }
    }
}
