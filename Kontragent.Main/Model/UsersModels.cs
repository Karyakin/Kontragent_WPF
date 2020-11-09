using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Model
{
   public class UsersModels
    {
        public string LoginUser { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Department { get; set; }
        public string Hint { get; set; }
        public DateTime DateCreationUser { get; set; }
    }
}
