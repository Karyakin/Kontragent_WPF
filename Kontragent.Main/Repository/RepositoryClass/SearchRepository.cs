using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Models.Person;
using Kontragent.Repository.RepositoryInterface;
using Kontragent.View.CustomControl;
using Kontragent.ViewModel.Search;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Repository.RepositoryClass
{
    public class SearchRepository : ISearchRepository
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;

        public List<KontragentModel> GeneralSearch(OrganizationModel organization, PersonModel persone)
        {
            /* var orgModel = new List<OrganizationModel>();
             var persModel = new List<PersonModel>();*/

            OrganizationModel searchOrg = null;
            PersonModel searchPer = null;

            List<KontragentModel> kontragent = new List<KontragentModel>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand generalSelectComm = new SqlCommand("General_SELECT", sqlConnection);
                generalSelectComm.CommandType = CommandType.StoredProcedure;
                generalSelectComm.Parameters.AddWithValue("Create_date_Org_START", organization.CreatedateOrgSTART);
                generalSelectComm.Parameters.AddWithValue("Create_date_Org_FINAL", organization.CreatedateOrgFINAL);
                generalSelectComm.Parameters.AddWithValue("Check_Date_Org_START", organization.CheckDateOrgSTART);
                generalSelectComm.Parameters.AddWithValue("Check_Date_Org_FINAL", organization.CheckDateOrgFINAL);

                generalSelectComm.Parameters.AddWithValue("UNP_Org", organization.UNPOrg);
                generalSelectComm.Parameters.AddWithValue("Short_Name_Org", organization.ShortNameOrg);
                generalSelectComm.Parameters.AddWithValue("Full_Name_Org", organization.FullNameOrg);

                generalSelectComm.Parameters.AddWithValue("Login_User", organization.LoginUser);

                if (organization.SelectedCountry == "(не выбрано)")
                {
                    generalSelectComm.Parameters.AddWithValue("Name_Country", null);
                }
                else
                {
                    generalSelectComm.Parameters.AddWithValue("Name_Country", organization.SelectedCountry);
                }

                if (organization.SelectedSection == "(не выбрано)")
                {
                    generalSelectComm.Parameters.AddWithValue("Name_Section", null);
                }
                else
                {
                    generalSelectComm.Parameters.AddWithValue("Name_Section", organization.SelectedSection);
                }

                var ownershipOrg = organization.OwnershipOrg ? true : (bool?)null;// если true - то true, если false - то null
                generalSelectComm.Parameters.AddWithValue("Ownership_Org", ownershipOrg);

                if (organization.Reputation == true) { generalSelectComm.Parameters.AddWithValue("Reputation", organization.Reputation); }
                else { generalSelectComm.Parameters.AddWithValue("Reputation", null); }

                if (organization.Tradingexperience == true) { generalSelectComm.Parameters.AddWithValue("Trading_experience", organization.Tradingexperience); }
                else { generalSelectComm.Parameters.AddWithValue("Trading_experience", null); }

                if (organization.Manufacturer == true) { generalSelectComm.Parameters.AddWithValue("Manufacturer", organization.Manufacturer); }
                else { generalSelectComm.Parameters.AddWithValue("Manufacturer", null); }

                if (organization.SpecialRisc == true)
                { generalSelectComm.Parameters.AddWithValue("Special_Risc", organization.SpecialRisc); }
                else
                { generalSelectComm.Parameters.AddWithValue("Special_Risc", null); }

                if (organization.FalseBusiness == true)
                { generalSelectComm.Parameters.AddWithValue("False_Business", organization.FalseBusiness); }
                else
                { generalSelectComm.Parameters.AddWithValue("False_Business", null); }

                if (organization.BankruptcyProc == true)
                { generalSelectComm.Parameters.AddWithValue("Bankruptcy_Proc", organization.BankruptcyProc); }
                else
                { generalSelectComm.Parameters.AddWithValue("Bankruptcy_Proc", null); }

                if (organization.LiquidationProc == true) { generalSelectComm.Parameters.AddWithValue("Liquidation_Proc", organization.LiquidationProc); }
                else
                { generalSelectComm.Parameters.AddWithValue("Liquidation_Proc", null); }

                if (organization.TaxDebt == true)
                { generalSelectComm.Parameters.AddWithValue("Tax_Debt", organization.TaxDebt); }
                else
                { generalSelectComm.Parameters.AddWithValue("Tax_Debt", null); }

                if (organization.DebtsEnforcementDocuments == true)
                { generalSelectComm.Parameters.AddWithValue("Debts_Enforcement_Documents", organization.DebtsEnforcementDocuments); }
                else
                { generalSelectComm.Parameters.AddWithValue("Debts_Enforcement_Documents", null); }

                if (organization.ExecuteProc == true)
                { generalSelectComm.Parameters.AddWithValue("Execute_Proc", organization.ExecuteProc); }
                else
                { generalSelectComm.Parameters.AddWithValue("Execute_Proc", null); }

                if (organization.ExchengeTradingDisorders == true)
                { generalSelectComm.Parameters.AddWithValue("Exchenge_Trading_Disorders", organization.ExchengeTradingDisorders); }
                else
                { generalSelectComm.Parameters.AddWithValue("Exchenge_Trading_Disorders", null); }

                if (organization.NegativData == true)
                { generalSelectComm.Parameters.AddWithValue("Negativ_Data", organization.NegativData); }
                else
                { generalSelectComm.Parameters.AddWithValue("Negativ_Data", null); }

                if (organization.Resident == true && organization.NotResident == false)
                {
                    generalSelectComm.Parameters.AddWithValue("Resident", organization.Resident);
                }
                else if (organization.Resident == false && organization.NotResident == true)
                {
                    generalSelectComm.Parameters.AddWithValue("Resident", false);
                }
                else if (organization.Resident == false && organization.NotResident == false)
                {
                    generalSelectComm.Parameters.AddWithValue("Resident", null);
                }
                generalSelectComm.Parameters.AddWithValue("Risc_Level_Less", organization.RiscLevelLess);
                generalSelectComm.Parameters.AddWithValue("Risc_Level_More", organization.RiscLevelMore);

                if (organization.BrokerClient == true) { generalSelectComm.Parameters.AddWithValue("Broker_Client", organization.BrokerClient); }
                else { generalSelectComm.Parameters.AddWithValue("Broker_Client", null); }

                if (organization.PrevBrokerClient == true) { generalSelectComm.Parameters.AddWithValue("Prev_Broker_Client", organization.PrevBrokerClient); }
                else { generalSelectComm.Parameters.AddWithValue("Prev_Broker_Client", null); }

                if (organization.FirstAccred == true) { generalSelectComm.Parameters.AddWithValue("First_Accred", organization.FirstAccred); }
                else { generalSelectComm.Parameters.AddWithValue("First_Accred", null); }

                if (organization.SecondAccred == true) { generalSelectComm.Parameters.AddWithValue("Second_Accred", organization.SecondAccred); }
                else { generalSelectComm.Parameters.AddWithValue("Second_Accred", null); }

                if (organization.Trader == true) { generalSelectComm.Parameters.AddWithValue("Trader", organization.Trader); }
                else { generalSelectComm.Parameters.AddWithValue("Trader", null); }

                //Pers______________________
                if (persone.SelectedCountryPers == "(не выбрано)")
                {
                    generalSelectComm.Parameters.AddWithValue("Country_Pers", null);
                }
                else
                {
                    generalSelectComm.Parameters.AddWithValue("Country_Pers", persone.SelectedCountryPers);
                }

               
                generalSelectComm.Parameters.AddWithValue("Owner_Name", persone.OwnerName);
                generalSelectComm.Parameters.AddWithValue("Head_Name", persone.HeadName);

                if (persone.PrevTaxDebt == true) { generalSelectComm.Parameters.AddWithValue("Prev_Tax_Debt", persone.PrevTaxDebt); }
                else { generalSelectComm.Parameters.AddWithValue("Prev_Tax_Debt", null); }

                if (persone.PrevLiquidated == true) { generalSelectComm.Parameters.AddWithValue("Prev_Liquidated", persone.PrevLiquidated); }
                else { generalSelectComm.Parameters.AddWithValue("Prev_Liquidated", null); }

                if (persone.PrevBankruptcy == true) { generalSelectComm.Parameters.AddWithValue("Prev_Bankruptcy", persone.PrevBankruptcy); }
                else { generalSelectComm.Parameters.AddWithValue("Prev_Bankruptcy", null); }

                if (persone.PrevExecuteProc == true) { generalSelectComm.Parameters.AddWithValue("Prev_Execute_Proc", persone.PrevExecuteProc); }
                else { generalSelectComm.Parameters.AddWithValue("Prev_Execute_Proc", null); }

                if (persone.PrevStateDebt == true) { generalSelectComm.Parameters.AddWithValue("Prev_State_Debt", persone.PrevStateDebt); }
                else { generalSelectComm.Parameters.AddWithValue("Prev_State_Debt", null); }

                if (persone.NegativDataPers == true) { generalSelectComm.Parameters.AddWithValue("Negativ_Data_Pers", persone.NegativDataPers); }
                else { generalSelectComm.Parameters.AddWithValue("Negativ_Data_Pers", null); }

                if (organization.ForcedDeposite == true) { generalSelectComm.Parameters.AddWithValue("Forced_Deposite", organization.ForcedDeposite); }
                else { generalSelectComm.Parameters.AddWithValue("Forced_Deposite", null); }

                SqlDataReader sqlDataReader = generalSelectComm.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    //Обязательные
                    searchOrg = new OrganizationModel();
                    searchPer = new PersonModel();
                    searchOrg.UNPOrg = Convert.ToString(sqlDataReader["UNP_Org"]);//
                    searchOrg.ShortNameOrg = Convert.ToString(sqlDataReader["Short_Name_Org"]);//
                    searchOrg.FullNameOrg = Convert.ToString(sqlDataReader["Full_Name_Org"]);//
                    searchOrg.CountyrOrg = Convert.ToString(sqlDataReader["Name_Country"]);
                    searchOrg.NameSection = Convert.ToString(sqlDataReader["Name_Section"]);
                    searchOrg.CreatedateOrg = Convert.ToDateTime(sqlDataReader["Create_date_Org"]);
                    //_________________________________________

                    //Описания/мнени
                    searchOrg.DescriptionOrg = Convert.ToString(sqlDataReader["Description_Org"]);
                    searchOrg.AuditorOpinion = Convert.ToString(sqlDataReader["Auditor_Opinion"]);
                    searchOrg.BrokerOpinion = Convert.ToString(sqlDataReader["Broker_Opinion"]);
                    searchOrg.SectionHeadOpinion = Convert.ToString(sqlDataReader["Section_Head_Opinion"]);
                    //_________________________________________
                    searchOrg.CheckDateOrg = Convert.ToDateTime(sqlDataReader["Check_Date_Org"]);
                    searchOrg.Auditor = Convert.ToString(sqlDataReader["Проверяющий"]);
                    searchOrg.RiscLevel = Convert.ToInt32(sqlDataReader["Степень риска"]);
                    searchOrg.UpdateAuditor = Convert.ToString(sqlDataReader["Автор изменений"]);
                    searchOrg.Deposit = Convert.ToString(sqlDataReader["Вид задатка"]);
                    searchOrg.RecomendDeposit = Convert.ToString(sqlDataReader["Рекомендуемый вид задатка"]);

                //   searchOrg.LoginUser = Convert.ToString(sqlDataReader["Проверяющий"]);

                    searchPer.OwnerName = Convert.ToString(sqlDataReader["Owner_Name"]);
                    searchPer.HeadName = Convert.ToString(sqlDataReader["Head_Name"]);
                    searchPer.СountryPers = Convert.ToString(sqlDataReader["Country_Pers"]);
                    searchPer.DescriptionPers = Convert.ToString(sqlDataReader["Description_Pers"]);

                    kontragent.Add(new KontragentModel(searchOrg, searchPer));
                }
                sqlDataReader.Close();
                sqlConnection.Close();
            }
            return kontragent;

        }




    }
}
