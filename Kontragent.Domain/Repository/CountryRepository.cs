using Kontragent.Domain.Models;
using Kontragent.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kontragent.Domain.Repository
{
   public class CountryRepository : ICountryRepository
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;

        public List<CountryModel> GetCountries()
        {
            string getCountryCommandString = "SELECT  Name_Country, Risk_Country FROM Country";
            var countries = new List<CountryModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand GetCountryCommand = new SqlCommand(getCountryCommandString, sqlConnection);

                SqlDataReader dataReaderCounrtry = GetCountryCommand.ExecuteReader();

                while (dataReaderCounrtry.Read())
                {

                    var counrty = new CountryModel
                    {
                        NameCountry = dataReaderCounrtry["Name_Country"] as string,
                        RiskCountry = (int)dataReaderCounrtry["Risk_Country"]
                    };
                    countries.Add(counrty);


                }
                dataReaderCounrtry.Close();
                sqlConnection.Close();
            }

            return countries;
        }
    }
}
