using Kontragent.Model;
using Kontragent.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Repository
{
    public static class AutorisationRepository
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
        public static bool CheckLogin(UsersModels organizationModel)
        {
            object checkLog;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand checkLogin = new SqlCommand("check_login", sqlConnection);
                checkLogin.Parameters.AddWithValue("Login_User", organizationModel.LoginUser);
                checkLogin.CommandType = CommandType.StoredProcedure;
                checkLog = checkLogin.ExecuteScalar();
                sqlConnection.Close();
            }
            return Convert.ToBoolean(checkLog);
        }


        public static bool CheckLoginPassward(UsersModels organizationModel)
        {
            object checkPass;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();

                SqlCommand checkLogPass = new SqlCommand("check_log_pass", sqlConnection);
                checkLogPass.Parameters.AddWithValue("Login_User", organizationModel.LoginUser);
                checkLogPass.Parameters.AddWithValue("Password_User", organizationModel.Password);
                checkLogPass.CommandType = CommandType.StoredProcedure;
                checkPass = checkLogPass.ExecuteScalar();
                Convert.ToBoolean(checkLogPass.CommandType = CommandType.StoredProcedure);
                sqlConnection.Close();
            }
            return Convert.ToBoolean(checkPass);
        }


        public static UsersModels GetUser(string loginUser)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                UsersModels user = new UsersModels();
                sqlConnection.Open();
                SqlCommand getUser = new SqlCommand("get_User", sqlConnection);
                getUser.Parameters.AddWithValue("Login_User", loginUser);

                getUser.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = getUser.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    user.LoginUser = Convert.ToString(sqlDataReader["Login_User"]);
                    user.Department = Convert.ToString(sqlDataReader["Department"]);
                    user.Hint = Convert.ToString(sqlDataReader["Hint"]);
                }
                sqlConnection.Close();
                return user ?? new UsersModels();
            }


        }

        public static WorkUserModel GetWorkUser(string loginUser)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                WorkUserModel user = null;
                sqlConnection.Open();
                SqlCommand getUser = new SqlCommand("get_User", sqlConnection);
                getUser.Parameters.AddWithValue("Login_User", loginUser);

                getUser.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = getUser.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    string login = Convert.ToString(sqlDataReader["Login_User"]);
                    string department = Convert.ToString(sqlDataReader["Department"]);

                    user = new WorkUserModel(login, department);

                }
                sqlConnection.Close();
                return user;
            }
        }

    }
}

