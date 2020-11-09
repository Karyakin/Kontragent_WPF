using Kontragent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.Repository
{
   public class SectionRepository : ISectionRepository
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
        public List<SectionModel> GetSections()
        {
            string getSectionCommandString = "SELECT  Name_Section, Risk_Section FROM Section";
            var sections = new List<SectionModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand GetSectionCommand = new SqlCommand(getSectionCommandString, sqlConnection);
                SqlDataReader dataReaderSection = GetSectionCommand.ExecuteReader();

                while (dataReaderSection.Read())
                {
                    var section = new SectionModel
                    {
                        NameSection = dataReaderSection["Name_Section"] as string,
                        RiskSection = Convert.ToInt32(dataReaderSection["Risk_Section"])
                    };
                    sections.Add(section);
                }
                dataReaderSection.Close();
                sqlConnection.Close();
            }
            return sections;
        }
    }
}
