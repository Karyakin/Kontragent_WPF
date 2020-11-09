using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Models.Person;
using Kontragent.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.Domain.Repository
{
    public class NewOrganizationRepository : INewOrganizationRepository
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"]?.ConnectionString;

        public void AddNewOrganizationToDB(OrganizationModel organizationModel, PersonModel personModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand command_ADD_Organization_Pers = new SqlCommand("ADD_Organization_Pers", sqlConnection); //Проца на заполнение таблицы Организации и Собственников
                command_ADD_Organization_Pers.CommandType = CommandType.StoredProcedure;

                command_ADD_Organization_Pers.Parameters.AddWithValue("UNP_Org", organizationModel.UNPOrg);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Short_Name_Org", organizationModel.ShortNameOrg);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Full_Name_Org", organizationModel.FullNameOrg);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Create_date_Org", organizationModel.CreatedateOrg);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Country", organizationModel.CountyrOrg);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Name_Section", organizationModel.NameSection);

                //Параметры для чекбоксов организации
                command_ADD_Organization_Pers.Parameters.AddWithValue("Ownership_Org", organizationModel.OwnershipOrg);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Tax_Debt", organizationModel.TaxDebt);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Debts_Enforcement_Documents", organizationModel.DebtsEnforcementDocuments);
                command_ADD_Organization_Pers.Parameters.AddWithValue("False_Business", organizationModel.FalseBusiness);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Special_Risc", organizationModel.SpecialRisc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Execute_Proc", organizationModel.ExecuteProc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Bankruptcy_Proc", organizationModel.BankruptcyProc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Liquidation_Proc", organizationModel.LiquidationProc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Resident", organizationModel.Resident);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Broker_Client", organizationModel.BrokerClient);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Broker_Client", organizationModel.PrevBrokerClient);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Trading_experience", organizationModel.Tradingexperience);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Trader", organizationModel.Trader);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Manufacturer", organizationModel.Manufacturer);
                command_ADD_Organization_Pers.Parameters.AddWithValue("First_Accred", organizationModel.FirstAccred);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Second_Accred", organizationModel.SecondAccred);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Exchenge_Trading_Disorders", organizationModel.ExchengeTradingDisorders);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Negativ_Data", organizationModel.NegativData);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Reputation", organizationModel.Reputation);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Forced_Deposite", organizationModel.ForcedDeposite);

                //Описание организации и мнения
                command_ADD_Organization_Pers.Parameters.AddWithValue("Description_Org", organizationModel.DescriptionOrg);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Section_Head_Opinion", string.IsNullOrEmpty(
                    organizationModel.SectionHeadOpinion) || string.IsNullOrWhiteSpace(organizationModel.SectionHeadOpinion)
                    ? "нет"
                    : organizationModel.SectionHeadOpinion);

                command_ADD_Organization_Pers.Parameters.AddWithValue("Auditor_Opinion", string.IsNullOrEmpty(
                 organizationModel.AuditorOpinion) || string.IsNullOrWhiteSpace(organizationModel.AuditorOpinion)
                 ? "нет"
                 : organizationModel.AuditorOpinion);

                command_ADD_Organization_Pers.Parameters.AddWithValue("Broker_Opinion", string.IsNullOrEmpty(
                organizationModel.BrokerOpinion) || string.IsNullOrWhiteSpace(organizationModel.BrokerOpinion)
                ? "нет"
                : organizationModel.BrokerOpinion);

                //Описание руководителей и их залетов
                command_ADD_Organization_Pers.Parameters.AddWithValue("Description_Pers", string.IsNullOrEmpty(
              personModel.DescriptionPers) || string.IsNullOrWhiteSpace(personModel.DescriptionPers)
              ? "нет"
              : personModel.DescriptionPers);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Negativ_Data_Pers", personModel.NegativDataPers);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Country_Pers", personModel.СountryPers);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Owner_Name", personModel.OwnerName);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Head_Name", personModel.HeadName);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Liquidated", personModel.PrevLiquidated);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Bankruptcy", personModel.PrevBankruptcy);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_State_Debt", personModel.PrevStateDebt);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Tax_Debt", personModel.PrevTaxDebt);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Execute_Proc", personModel.PrevExecuteProc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Login_User", organizationModel.Auditor);

                try
                {
                    command_ADD_Organization_Pers.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Обязательные параметры пришли не корректно! Добавление в базу данных невозможно.");
                    return;

                }
                sqlConnection.Close();
               // MessageBox.Show("Данные сохранены в базу данных!");
                
            }
        }
    }
}
