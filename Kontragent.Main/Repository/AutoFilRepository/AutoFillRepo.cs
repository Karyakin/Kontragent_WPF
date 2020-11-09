using Kontragent.Helper;
using Kontragent.Repository.RepositoryInterface;
using Kontragent.ViewModel;
using Kontragent.ViewModel.Autofill;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.Repository.AutoFilRepository
{
    class AutoFillRepo : IAutofilInterface
    {
        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
        private static string ConnectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;

        AutoFillViewModelOrg autofilOrg = null;
        AutoFillViewModelPers autoFilPers = null;


        [Obsolete]
        public AutoFillKontragentViewModel AutoFilKontra(string UNP)
        {
            if (UNP == null)
            {
                MessageBox.Show("Заполните УПН!", "Ошибка УНП", MessageBoxButton.OK, MessageBoxImage.Error);
                return new AutoFillKontragentViewModel();
            }
            var orgFromOracle = new AutoFillKontragentViewModel();
            AutoFillKontragentViewModel oracleOrg = null;
            using (OracleConnection oracleConnection = new OracleConnection(ConnectionStringOracle))
            {
                oracleConnection.Open();

                //-----------------------------------------------------------------------
                string oracleCheckUNP = "SELECT COUNT(*) FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP =" + $"'{UNP}'";
                OracleCommand oracleCheckUNPComm = new OracleCommand(oracleCheckUNP, oracleConnection);
                if ((Convert.ToInt32((oracleCheckUNPComm.ExecuteOracleScalar()).ToString()) != 1))
                {
                    MessageBox.Show("Организации с таким УПН не существует в базе МНС!", "Ошибка УНП", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new AutoFillKontragentViewModel();
                }
                //=======================================================================

                //-----------------------------------------------------------------------
                string oracleFullNameOrgComm = "SELECT mns_subject.FULL_NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{UNP}";
                OracleCommand oracleFullNameOrg = new OracleCommand(oracleFullNameOrgComm, oracleConnection);// Поллное название организации
                string fullNameOrg = oracleFullNameOrg.ExecuteOracleScalar().ToString();
                //=======================================================================

                //-----------------------------------------------------------------------
                string oracleSortNameOrgComm = "SELECT mns_subject.NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{UNP}";
                OracleCommand oracleSortNameOrg = new OracleCommand(oracleSortNameOrgComm, oracleConnection); // Краткое название организации
                string shortNameOrg = oracleSortNameOrg.ExecuteOracleScalar().ToString();
                //======================================================================

                //----------------------------------------------------------------------
                string oracleDateRegistrationComm = "SELECT mns_subject.REG_DATE FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ UNP}";
                OracleCommand oracleDateRegistration = new OracleCommand(oracleDateRegistrationComm, oracleConnection);// Дата регистрации
                string createDateOrg = oracleDateRegistration.ExecuteOracleScalar().ToString();
                //=====================================================================

                //----------------------------------------------------------------------
                string sqlHeadName = "SELECT mns_subject.FIO_CHIEF FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{UNP}";
                OracleCommand comHeadName = new OracleCommand(sqlHeadName, oracleConnection);// руководитель
                string headName = comHeadName.ExecuteOracleScalar().ToString();
                //=====================================================================

                //---------------------------------------------------------------------
                string sqlOwneerName = "SELECT mns_constitutor.FULL_NAME FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP =" + $"{ UNP}";
                OracleCommand OwneerNameComm = new OracleCommand(sqlOwneerName, oracleConnection);
                OracleDataReader reader = OwneerNameComm.ExecuteReader();
                string ownerName = null;
                while (reader.Read())
                {
                    ownerName = $"{ownerName}" + $"{ Convert.ToString(reader.GetString(0))}; ";
                }
                //---------------------------------------------------------------------
                string sqlResident = "SELECT mns_constitutor.RESIDENT FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP = " + $"{UNP}";
                OracleCommand comResident = new OracleCommand(sqlResident, oracleConnection);
                string countryPers = null;
                string countryOrg = null;

                int rez = 0;
                try
                {
                    rez = Convert.ToInt32(comResident.ExecuteOracleScalar().ToString());
                }
                catch (Exception)
                {
                    countryOrg = "Беларусь";
                    //MessageBox.Show("В базе данных не содержится признака резидентства. Скорее всего организация очень старая или данные были внесены не корректно. Заполняем ручками из регистратора:)", "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (rez != 0)
                {
                    countryOrg = "Беларусь";
                }
                //=======================================================================

                try
                {
                    string ConnStrCountryID = "SELECT mns_constitutor.NCOUNTRY_ID FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP = " + $"{UNP}";
                    OracleCommand com_ORA_NCOUNTRY_ID = new OracleCommand(ConnStrCountryID, oracleConnection);
                    string countryID = com_ORA_NCOUNTRY_ID.ExecuteOracleScalar().ToString();

                    using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
                    {
                        sqlConnection.Open();
                        SqlCommand Country_Select = new SqlCommand("Country_Select", sqlConnection);// получение старны
                        Country_Select.CommandType = CommandType.StoredProcedure;
                        Country_Select.Parameters.AddWithValue("Country_Code", countryID);
                        countryPers = Country_Select.ExecuteScalar().ToString();
                        if (countryPers == null)
                        {
                            countryPers = "Беларусь";
                        }
                        sqlConnection.Close();
                    }
                }
                catch (Exception)
                {
                    countryPers = "Беларусь";
                }
                finally 
                {
                    if (countryPers== null)
                    {
                        countryPers = "(не выбрано)";
                    }
                }
                //-----------------------------------------------------------------------

                //=======================================================================
                var orgModel = new AutoFillKontragentViewModel();
                orgModel.AutoFillViewModelOrg.CreateDateOrg = Convert.ToDateTime(createDateOrg); // Это не правильно делать через приведение к стрингу и назад, но инече я получаю System.InvalidCastException: "Не удалось привести тип объекта "System.Data.OracleClient.OracleDateTime" к типу "System.IConvertible"."
                orgModel.AutoFillViewModelPers.HeadName = headName;
                orgModel.AutoFillViewModelOrg.CountryOrg = countryOrg;
                orgModel.AutoFillViewModelPers.CountryPers = countryPers;

                if (string.IsNullOrEmpty(ownerName) || string.IsNullOrWhiteSpace(ownerName) || ownerName == "null" || ownerName == "Null")
                {
                    orgModel.AutoFillViewModelPers.OwnerName = headName;
                    orgModel.AutoFillViewModelOrg.FullNameOrg = $"Индивидивидуальный предприниматель {fullNameOrg}";
                    orgModel.AutoFillViewModelOrg.ShortNameOrg = $"ИП {shortNameOrg}";
                }
                else
                {
                    orgModel.AutoFillViewModelPers.OwnerName = ownerName;
                    orgModel.AutoFillViewModelOrg.FullNameOrg = fullNameOrg;
                    orgModel.AutoFillViewModelOrg.ShortNameOrg = shortNameOrg;
                }
                var check = new CheckUNP();
                if (check.UNPchecher(UNP) == true)
                {
                    MessageBox.Show("Организация с таким УНП уже внесена в базу", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                oracleConnection.Close();
                oracleOrg = orgModel;
            }
            return oracleOrg ?? new AutoFillKontragentViewModel();// если риск NULL возвращаем пустую модель(чтобы не свалилось в случае чего)
        }



    }
}

