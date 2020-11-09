using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Helper
{
    public static class DateCalculator
    {
        public static string DateCalculation(DateTime createdateOrg)
        {
            DateTime dateNow = DateTime.Now;

            var ageYear = (dateNow - createdateOrg).TotalDays / 365;

            var ageMouns = 0;
            if (dateNow.Month < createdateOrg.Month)
            {
                ageMouns = dateNow.Month;
            }
            else
            {
                ageMouns = dateNow.Month - createdateOrg.Month;
            }

            var ageDay = 0;
            if (dateNow.Day < createdateOrg.Day)
            {
                ageDay = dateNow.Day;
            }
            else
            {
                ageDay = dateNow.Day - createdateOrg.Day;
            }
            string age = $"Года: {(int)ageYear}   Месяца: {ageMouns}   Дни: {ageDay}";

            return age;
        }
        
    }
}
