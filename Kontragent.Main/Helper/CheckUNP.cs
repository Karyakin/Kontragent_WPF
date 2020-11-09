using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.Helper
{
    public class CheckUNP
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"]?.ConnectionString;
        public bool isCheched;
        public bool UNPchecher(string UNP)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();

                SqlCommand CheckUNPComm = new SqlCommand("Check_UNP ", sqlConnection);
                CheckUNPComm.CommandType = CommandType.StoredProcedure;
                CheckUNPComm.Parameters.AddWithValue("UNP_Org", UNP);

                if (Convert.ToInt32(CheckUNPComm.ExecuteScalar()) == 1)
                {
                    isCheched = true;
                }
                else
                {
                    isCheched = false;
                }
                sqlConnection.Close();
            }
            return isCheched;
        }
    }
}
