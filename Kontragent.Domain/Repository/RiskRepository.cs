using Kontragent.Domain.Models;
using Kontragent.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Domain.Repository
{
    public class RiskRepository : IRiskListRepository
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
        public RiskModel GetRisks()
        {
            RiskModel risk = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand All_Check_Risk = new SqlCommand("All_Check_Risk", sqlConnection);
                All_Check_Risk.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = All_Check_Risk.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    risk = new RiskModel
                    {
                        OwnershipOrg = Convert.ToInt32(sqlDataReader["Ownership_Org"]),
                        TaxDebt = Convert.ToInt32(sqlDataReader["Tax_Debt"]),
                        DebtsEnforcementDocuments = Convert.ToInt32(sqlDataReader["Debts_Enforcement_Documents"]),
                        FalseBusiness = Convert.ToInt32(sqlDataReader["False_Business"]),
                        SpecialRisc = Convert.ToInt32(sqlDataReader["Special_Risc"]),
                        ExecuteProc = Convert.ToInt32(sqlDataReader["Execute_Proc"]),
                        BankruptcyProc = Convert.ToInt32(sqlDataReader["Bankruptcy_Proc"]),
                        LiquidationProc = Convert.ToInt32(sqlDataReader["Liquidation_Proc"]),
                        Resident = Convert.ToInt32(sqlDataReader["Resident"]),
                        BrokerClient = Convert.ToInt32(sqlDataReader["Broker_Client"]),
                        Tradingexperience = Convert.ToInt32(sqlDataReader["Trading_experience"]),
                        Manufacturer = Convert.ToInt32(sqlDataReader["Manufacturer"]),
                        ExchengeTradingDisorders = Convert.ToInt32(sqlDataReader["Exchenge_Trading_Disorders"]),
                        NegativData = Convert.ToInt32(sqlDataReader["Negativ_Data"]),
                        Reputation = Convert.ToInt32(sqlDataReader["Reputation"]),
                        PrevLiquidated = Convert.ToInt32(sqlDataReader["Prev_Liquidated"]),
                        PrevBankruptcy = Convert.ToInt32(sqlDataReader["Prev_Bankruptcy"]),
                        PrevStateDebt = Convert.ToInt32(sqlDataReader["Prev_State_Debt"]),
                        PrevTaxDebt = Convert.ToInt32(sqlDataReader["Prev_Tax_Debt"]),
                        PrevExecuteProc = Convert.ToInt32(sqlDataReader["Prev_Execute_Proc"]),
                         AgeOrg = Convert.ToInt32(sqlDataReader["Age_Org_Risk"]),
                       
                    };
                }
                sqlConnection.Close();
            }
            return risk ?? new RiskModel();// если риск NULL возвращаем пустую модель(чтобы не свалилось в случае чего)
        }


        public int GetAgeOrgRisk()
        {
            int risk = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand All_Check_Risk = new SqlCommand("Select Age_Org_Risk FROM Risk", sqlConnection);

                SqlDataReader sqlDataReader = All_Check_Risk.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    risk = Convert.ToInt32(sqlDataReader["Age_Org_Risk"]);
                   /* {
                        AgeOrg = Convert.ToInt32(sqlDataReader["Age_Org_Risk"]),
                    };*/
                }
                sqlConnection.Close();
            }
            return risk;// если риск NULL возвращаем пустую модель(чтобы не свалилось в случае чего)
        }
    }
}
