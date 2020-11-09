using Kontragent.Personalization.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Personalization.Repositoty
{
 /*   public static class AutorizationRepozitory
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"]?.ConnectionString;

        public static bool CheckLogin(UsersModels organizationModel)
        {
            bool checkLog;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand checkLogin = new SqlCommand("check_login", sqlConnection);
                checkLogin.Parameters.AddWithValue("Login_User", organizationModel.LoginUser);
                checkLog = Convert.ToBoolean(checkLogin.CommandType = CommandType.StoredProcedure);
                sqlConnection.Close();
            }
            
            return checkLog;
        }

        public static bool CheckLoginPassward(UsersModels organizationModel)
        {
            bool checkPass;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();

                SqlCommand checkLogPass = new SqlCommand("check_log_pass", sqlConnection);
                // SqlCommand checkLogin = new SqlCommand("check_login", sqlConnection);

                checkLogPass.Parameters.AddWithValue("Login_User", organizationModel.LoginUser);
                checkLogPass.Parameters.AddWithValue("Password_User", organizationModel.PasswordUser);

                checkLogPass.CommandType = CommandType.StoredProcedure;
                checkPass = Convert.ToBoolean(checkLogPass.CommandType = CommandType.StoredProcedure);
                sqlConnection.Close();
            }
            return checkPass;

        }
    }*/
}
