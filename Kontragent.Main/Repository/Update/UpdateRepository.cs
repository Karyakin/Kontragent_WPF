using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Models.Person;
using Kontragent.Helper;
using Kontragent.Model;
using Kontragent.Model.Update;
using Kontragent.ViewModel.Update;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.Repository.Update
{
    public class UpdateRepository
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
        public KontragentModelUpdate FindOrgForUpdate(UpdateOrgModel orgModelForUpdate)
        {

            UpdateOrgModel searchOrg = new UpdateOrgModel();
            UpdatePersModel searchPer = new UpdatePersModel();
            KontragentModelUpdate kontragent = new KontragentModelUpdate();


            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand SelectForUpdatecomm = new SqlCommand("Select_For_Apdate", sqlConnection);
                SelectForUpdatecomm.CommandType = CommandType.StoredProcedure;

                SelectForUpdatecomm.Parameters.AddWithValue("UNP_Org", orgModelForUpdate.SharedVariable);
                SelectForUpdatecomm.Parameters.AddWithValue("Short_Name_Org", orgModelForUpdate.ShortNameOrg);
                SelectForUpdatecomm.Parameters.AddWithValue("Full_Name_Org", orgModelForUpdate.FullNameOrg);

                SqlDataReader sqlDataReader = SelectForUpdatecomm.ExecuteReader();
                if (sqlDataReader.HasRows != true)
                {
                    SelectForUpdatecomm.Cancel();
                    sqlDataReader.Close();
                    SelectForUpdatecomm = new SqlCommand("Select_For_Apdate", sqlConnection);
                    SelectForUpdatecomm.CommandType = CommandType.StoredProcedure;

                    SelectForUpdatecomm.Parameters.AddWithValue("UNP_Org", orgModelForUpdate.UNPOrg);
                    SelectForUpdatecomm.Parameters.AddWithValue("Short_Name_Org", orgModelForUpdate.SharedVariable);
                    SelectForUpdatecomm.Parameters.AddWithValue("Full_Name_Org", orgModelForUpdate.FullNameOrg);
                    sqlDataReader = SelectForUpdatecomm.ExecuteReader();
                }

                if (sqlDataReader.HasRows != true)
                {
                    SelectForUpdatecomm.Cancel();
                    sqlDataReader.Close();
                    SelectForUpdatecomm = new SqlCommand("Select_For_Apdate", sqlConnection);
                    SelectForUpdatecomm.CommandType = CommandType.StoredProcedure;

                    SelectForUpdatecomm.Parameters.AddWithValue("UNP_Org", orgModelForUpdate.UNPOrg);
                    SelectForUpdatecomm.Parameters.AddWithValue("Short_Name_Org", orgModelForUpdate.ShortNameOrg);
                    SelectForUpdatecomm.Parameters.AddWithValue("Full_Name_Org", orgModelForUpdate.SharedVariable);
                    sqlDataReader = SelectForUpdatecomm.ExecuteReader();
                }

                if (sqlDataReader.HasRows != true)
                {
                    if (kontragent.OrgForUpdate == null || kontragent.PersForUpdate == null)
                        MessageBox.Show("Организация не найдена в базе данных", "Ошибка организации ", MessageBoxButton.OK, MessageBoxImage.Error);

                    searchOrg = new UpdateOrgModel();
                    searchPer = new UpdatePersModel();

                    KontragentModelUpdate kontr = new KontragentModelUpdate();
                    kontr.OrgForUpdate = searchOrg;
                    kontr.PersForUpdate = searchPer;
                    return kontr;
                }

                int count = 0;
                while (sqlDataReader.Read())
                {
                    count += 1;

                    searchOrg.UNPOrg = Convert.ToString(sqlDataReader["UNP_Org"]);
                    searchOrg.ShortNameOrg = Convert.ToString(sqlDataReader["Short_Name_Org"]);
                    searchOrg.FullNameOrg = Convert.ToString(sqlDataReader["Full_Name_Org"]);
                    searchOrg.CreateDateOrg = Convert.ToDateTime(sqlDataReader["Create_date_Org"]);
                    searchOrg.CountyrOrg = Convert.ToString(sqlDataReader["Name_Country"]);
                    searchOrg.NameSection = Convert.ToString(sqlDataReader["Name_Section"]);

                    searchOrg.DescriptionOrg = Convert.ToString(sqlDataReader["Description_Org"]);
                    searchOrg.BrokerOpinion = Convert.ToString(sqlDataReader["Broker_Opinion"]);
                    searchOrg.SectionHeadOpinion = Convert.ToString(sqlDataReader["Section_Head_Opinion"]);
                    searchOrg.AuditorOpinion = Convert.ToString(sqlDataReader["Auditor_Opinion"]);

                    searchOrg.OwnershipOrg = Convert.ToBoolean(sqlDataReader["Ownership_Org"]);
                    searchOrg.TaxDebt = Convert.ToBoolean(sqlDataReader["Tax_Debt"]);
                    searchOrg.DebtsEnforcementDocuments = Convert.ToBoolean(sqlDataReader["Debts_Enforcement_Documents"]);
                    searchOrg.FalseBusiness = Convert.ToBoolean(sqlDataReader["False_Business"]);
                    searchOrg.SpecialRisc = Convert.ToBoolean(sqlDataReader["Special_Risc"]);
                    searchOrg.ExecuteProc = Convert.ToBoolean(sqlDataReader["Execute_Proc"]);
                    searchOrg.BankruptcyProc = Convert.ToBoolean(sqlDataReader["Bankruptcy_Proc"]);
                    searchOrg.LiquidationProc = Convert.ToBoolean(sqlDataReader["Liquidation_Proc"]);
                    searchOrg.Resident = Convert.ToBoolean(sqlDataReader["Resident"]);
                    searchOrg.BrokerClient = Convert.ToBoolean(sqlDataReader["Broker_Client"]);
                    searchOrg.PrevBrokerClient = Convert.ToBoolean(sqlDataReader["Prev_Broker_Client"]);
                    searchOrg.Tradingexperience = Convert.ToBoolean(sqlDataReader["Trading_experience"]);
                    searchOrg.Trader = Convert.ToBoolean(sqlDataReader["Trader"]);
                    searchOrg.Manufacturer = Convert.ToBoolean(sqlDataReader["Manufacturer"]);
                    searchOrg.RecomendDeposit = Convert.ToString(sqlDataReader["Рекомендуемый вид задатка"]);
                    searchOrg.Deposit = Convert.ToString(sqlDataReader["Вид задатка"]);

                    searchOrg.FirstAccred = Convert.ToBoolean(sqlDataReader["First_Accred"]);
                    searchOrg.SecondAccred = Convert.ToBoolean(sqlDataReader["Second_Accred"]);

                    searchOrg.ExchengeTradingDisorders = Convert.ToBoolean(sqlDataReader["Exchenge_Trading_Disorders"]);
                    searchOrg.NegativData = Convert.ToBoolean(sqlDataReader["Negativ_Data"]);
                    searchPer.NegativDataPers = Convert.ToBoolean(sqlDataReader["Negativ_Data_Pers"]);
                    searchOrg.Reputation = Convert.ToBoolean(sqlDataReader["Reputation"]);
                    searchOrg.RiscLevel = Convert.ToInt32(sqlDataReader["Степень риска"]);
                    searchOrg.ForcedDeposite = Convert.ToBoolean(sqlDataReader["Forced_Deposite"]);

                    searchPer.СountryPers = Convert.ToString(sqlDataReader["Country_Pers"]);
                    searchPer.OwnerName = Convert.ToString(sqlDataReader["Owner_Name"]);
                    searchPer.HeadName = Convert.ToString(sqlDataReader["Head_Name"]);
                    searchPer.DescriptionPers = Convert.ToString(sqlDataReader["Description_Pers"]);
                    searchPer.PrevLiquidated = Convert.ToBoolean(sqlDataReader["Prev_Liquidated"]);
                    searchPer.PrevBankruptcy = Convert.ToBoolean(sqlDataReader["Prev_Bankruptcy"]);
                    searchPer.PrevStateDebt = Convert.ToBoolean(sqlDataReader["Prev_State_Debt"]);
                    searchPer.PrevTaxDebt = Convert.ToBoolean(sqlDataReader["Prev_Tax_Debt"]);
                    searchPer.PrevExecuteProc = Convert.ToBoolean(sqlDataReader["Prev_Execute_Proc"]);
                    searchPer.NegativDataPers = Convert.ToBoolean(sqlDataReader["Prev_Execute_Proc"]);

                    kontragent = new KontragentModelUpdate(searchOrg, searchPer);

                    if (count > 1)
                    {
                        MessageBox.Show($"По заданному параметру \"{orgModelForUpdate.SharedVariable}\" найдено более одной организации!\nДля избежания некорректного форматирования данных нпишите УНП или название организации более подробно.", "Ошибка организации ", MessageBoxButton.OK, MessageBoxImage.Error);
                        return new KontragentModelUpdate();
                    }
                }
                sqlDataReader.Close();
                sqlConnection.Close();
            }
            return kontragent ?? new KontragentModelUpdate();
        }

        public void DeleteOrg(UpdateViewModel kontragentModelUpdate)
        {
            // kontragentModelUpdate = new KontragentModelUpdate();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand DelOrgComm = new SqlCommand("Delete_ORG_Cascade", sqlConnection);
                DelOrgComm.CommandType = CommandType.StoredProcedure;

                if (string.IsNullOrEmpty(kontragentModelUpdate?.Organization.UNPOrg) || string.IsNullOrWhiteSpace(kontragentModelUpdate?.Organization.UNPOrg) ||
                    string.IsNullOrEmpty(kontragentModelUpdate?.Organization.FullNameOrg) || string.IsNullOrWhiteSpace(kontragentModelUpdate?.Organization.FullNameOrg) ||
                    string.IsNullOrEmpty(kontragentModelUpdate?.Organization.ShortNameOrg) || string.IsNullOrWhiteSpace(kontragentModelUpdate?.Organization.ShortNameOrg))
                {
                    MessageBox.Show($"Пока удалять нечего. Выберите организацию для удаления!", "Ошибка Удаления", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                else
                {
                    DelOrgComm.Parameters.AddWithValue("UNP_Org", kontragentModelUpdate.Organization?.UNPOrg);
                    DelOrgComm.Parameters.AddWithValue("Short_Name_Org", kontragentModelUpdate.Organization?.ShortNameOrg);
                    DelOrgComm.Parameters.AddWithValue("Full_Name_Org", kontragentModelUpdate.Organization?.FullNameOrg);

                    if (MessageBox.Show("Удалить организацию?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        DelOrgComm.ExecuteNonQuery();
                        MessageBox.Show($"Огранизация {kontragentModelUpdate.Organization?.ShortNameOrg} удалена!!! ");
                    }
                }
            }
        }


        public void UpdOrg(UpdateViewModel updateViewModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand UpdateCascadeCommand = new SqlCommand("Update_Cascade", sqlConnection); //Проца на заполнение таблицы Организации и Собственников
                UpdateCascadeCommand.CommandType = CommandType.StoredProcedure;

                UpdateCascadeCommand.Parameters.AddWithValue("UNP_Org", updateViewModel.Organization.UNPOrg);
                UpdateCascadeCommand.Parameters.AddWithValue("UNP_Org_New", updateViewModel.Organization.UNPOrg);

                UpdateCascadeCommand.Parameters.AddWithValue("Short_Name_Org", updateViewModel.Organization.ShortNameOrg);
                UpdateCascadeCommand.Parameters.AddWithValue("Short_Name_Org_New", updateViewModel.Organization.ShortNameOrg);

                UpdateCascadeCommand.Parameters.AddWithValue("Full_Name_Org", updateViewModel.Organization.FullNameOrg);
                UpdateCascadeCommand.Parameters.AddWithValue("Full_Name_Org_New", updateViewModel.Organization.FullNameOrg);

                UpdateCascadeCommand.Parameters.AddWithValue("Create_date_Org", updateViewModel.Organization.CreateDateOrg);


                try
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Country", updateViewModel.Organization.SelectedCountry.NameCountry);
                }
                catch (Exception)
                {

                    UpdateCascadeCommand.Parameters.AddWithValue("Country", "(не выбрано)");
                }

                try
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Name_Section", updateViewModel.Organization.SelectedSection.NameSection);
                }
                catch (Exception)
                {

                    UpdateCascadeCommand.Parameters.AddWithValue("Name_Section", "(не выбрано)");
                }  

               

                //Параметры для чекбоксов организации
                UpdateCascadeCommand.Parameters.AddWithValue("Ownership_Org", updateViewModel.Organization.OwnershipOrg);
                UpdateCascadeCommand.Parameters.AddWithValue("Tax_Debt", updateViewModel.Organization.TaxDebt);
                UpdateCascadeCommand.Parameters.AddWithValue("Debts_Enforcement_Documents", updateViewModel.Organization.DebtsEnforcementDocuments);
                UpdateCascadeCommand.Parameters.AddWithValue("False_Business", updateViewModel.Organization.FalseBusiness);
                UpdateCascadeCommand.Parameters.AddWithValue("Special_Risc", updateViewModel.Organization.SpecialRisc);
                UpdateCascadeCommand.Parameters.AddWithValue("Execute_Proc", updateViewModel.Organization.ExecuteProc);
                UpdateCascadeCommand.Parameters.AddWithValue("Bankruptcy_Proc", updateViewModel.Organization.BankruptcyProc);
                UpdateCascadeCommand.Parameters.AddWithValue("Liquidation_Proc", updateViewModel.Organization.LiquidationProc);
                UpdateCascadeCommand.Parameters.AddWithValue("Resident", updateViewModel.Organization.Resident);

                UpdateCascadeCommand.Parameters.AddWithValue("Broker_Client", updateViewModel.Organization.BrokerClient);
                if (updateViewModel.Organization.BrokerClient == true)
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Trader", false);
                }
                else
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Trader", true);
                }
              
                UpdateCascadeCommand.Parameters.AddWithValue("Second_Accred", updateViewModel.Organization.SecondAccred);
                if (updateViewModel.Organization.SecondAccred == true)
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("First_Accred", false);
                }
                else
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("First_Accred", true);
                }

                if (updateViewModel.Organization.SecondAccred == true)
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Trading_experience", true);
                }
                else
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Trading_experience", false);
                }
                UpdateCascadeCommand.Parameters.AddWithValue("Prev_Broker_Client", updateViewModel.Organization.PrevBrokerClient);
                UpdateCascadeCommand.Parameters.AddWithValue("Manufacturer", updateViewModel.Organization.Manufacturer);
                UpdateCascadeCommand.Parameters.AddWithValue("Exchenge_Trading_Disorders", updateViewModel.Organization.ExchengeTradingDisorders);
                UpdateCascadeCommand.Parameters.AddWithValue("Negativ_Data", updateViewModel.Organization.NegativData);
                UpdateCascadeCommand.Parameters.AddWithValue("Reputation", updateViewModel.Organization.Reputation);
                UpdateCascadeCommand.Parameters.AddWithValue("Forced_Deposite", updateViewModel.Organization.ForcedDeposite);

                //Описание организации и мнения
                UpdateCascadeCommand.Parameters.AddWithValue("Description_Org", updateViewModel.Organization.DescriptionOrg);
                UpdateCascadeCommand.Parameters.AddWithValue("Section_Head_Opinion", string.IsNullOrEmpty(
                    updateViewModel.Organization.SectionHeadOpinion) || string.IsNullOrWhiteSpace(updateViewModel.Organization.SectionHeadOpinion)
                    ? "нет"
                    : updateViewModel.Organization.SectionHeadOpinion);

                UpdateCascadeCommand.Parameters.AddWithValue("Auditor_Opinion", string.IsNullOrEmpty(
                 updateViewModel.Organization.AuditorOpinion) || string.IsNullOrWhiteSpace(updateViewModel.Organization.AuditorOpinion)
                 ? "нет"
                 : updateViewModel.Organization.AuditorOpinion);

                UpdateCascadeCommand.Parameters.AddWithValue("Broker_Opinion", string.IsNullOrEmpty(
                updateViewModel.Organization.BrokerOpinion) || string.IsNullOrWhiteSpace(updateViewModel.Organization.BrokerOpinion)
                ? "нет"
                : updateViewModel.Organization.BrokerOpinion);

                //Описание руководителей и их залетов
                UpdateCascadeCommand.Parameters.AddWithValue("Description_Pers", string.IsNullOrEmpty(
              updateViewModel.Person.DescriptionPers) || string.IsNullOrWhiteSpace(updateViewModel.Person.DescriptionPers)
              ? "нет"
              : updateViewModel.Person.DescriptionPers);
                UpdateCascadeCommand.Parameters.AddWithValue("Negativ_Data_Pers", updateViewModel.Person.NegativDataPers);

                try
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Country_Pers", updateViewModel.Person.SelectedCountry.NameCountry);

                }
                catch (Exception)
                {
                    UpdateCascadeCommand.Parameters.AddWithValue("Country_Pers", "(не выбрано)");
                }


                UpdateCascadeCommand.Parameters.AddWithValue("Owner_Name", updateViewModel.Person.OwnerName);
                UpdateCascadeCommand.Parameters.AddWithValue("Head_Name", updateViewModel.Person.HeadName);
                UpdateCascadeCommand.Parameters.AddWithValue("Prev_Liquidated", updateViewModel.Person.PrevLiquidated);
                UpdateCascadeCommand.Parameters.AddWithValue("Prev_Bankruptcy", updateViewModel.Person.PrevBankruptcy);
                UpdateCascadeCommand.Parameters.AddWithValue("Prev_State_Debt", updateViewModel.Person.PrevStateDebt);
                UpdateCascadeCommand.Parameters.AddWithValue("Prev_Tax_Debt", updateViewModel.Person.PrevTaxDebt);
                UpdateCascadeCommand.Parameters.AddWithValue("Prev_Execute_Proc", updateViewModel.Person.PrevExecuteProc);
                UpdateCascadeCommand.Parameters.AddWithValue("Login_User", WorkUserSingleton.sourse.WorkUser.LoginUser);

                try
                {
                    if (MessageBox.Show("Изменить данные?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        UpdateCascadeCommand.ExecuteNonQuery();
                        MessageBox.Show($"Данные изменены успешно");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Обязательные параметры заданы не корректно! Изменение данных невозможно.");
                    return;
                }
                sqlConnection.Close();
            }
        }
    }
}

