using Kontragent.Domain.Models;
using Kontragent.Domain.Models.Organization;
using Kontragent.Domain.Models.Person;
using Kontragent.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.Domain.Repository
{
    public class OracleInfoRepository : IOracleInfoRepository
    {
         
        private static string ConnectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
        
       
       

        [Obsolete]
        public OrganizationModel OracleGetOrg(string UNP)
        {
            if (UNP == null)
            {
                MessageBox.Show("Заполните УПН!", "Ошибка УНП", MessageBoxButton.OK, MessageBoxImage.Error);
                return new OrganizationModel();
            }
          

            var orgFromOracle = new OrganizationModel();
            OrganizationModel oracleOrg = null;
            using (OracleConnection oracleConnection = new OracleConnection(ConnectionStringOracle))
            {
                oracleConnection.Open();

                string oracleCheckUNP = "SELECT COUNT(*) FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP =" + $"'{UNP}'";
                OracleCommand oracleCheckUNPComm = new OracleCommand(oracleCheckUNP, oracleConnection);
                if ((Convert.ToInt32((oracleCheckUNPComm.ExecuteOracleScalar()).ToString()) != 1))
                {
                    MessageBox.Show("Организации с таким УПН не существует в базе МНС!", "Ошибка УНП", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new OrganizationModel();
                }

                string oracleFullNameOrgComm = "SELECT mns_subject.FULL_NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{UNP}";
                OracleCommand oracleFullNameOrg = new OracleCommand(oracleFullNameOrgComm, oracleConnection);// Поллное название организации

                string oracleSortNameOrgComm = "SELECT mns_subject.NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{UNP}";
                OracleCommand oracleSortNameOrg = new OracleCommand(oracleSortNameOrgComm, oracleConnection); // Краткое название организации

                string oracleDateRegistrationComm = "SELECT mns_subject.REG_DATE FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ UNP}";
                OracleCommand oracleDateRegistration = new OracleCommand(oracleDateRegistrationComm, oracleConnection);// Дата регистрации

                string checkUNPComm = "SELECT COUNT(*) FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP =" + $"'{UNP}'";
                OracleCommand CheckUNP = new OracleCommand(checkUNPComm, oracleConnection);// проверка на наличие организации с таким УНП
                string createDateOrg = oracleDateRegistration.ExecuteOracleScalar().ToString();


                string sqlORARESIDENT = "SELECT mns_constitutor.RESIDENT FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP = " + $"{ UNP}";
                OracleCommand comORARESIDENT = new OracleCommand(sqlORARESIDENT, oracleConnection);
                int rez = Convert.ToInt32(comORARESIDENT.ExecuteOracleScalar().ToString());

                var rezident = "";

                if (rez == 1)
                {
                    rezident = "Беларусь";
                }

                //string sqlNCOUNTRYID = "SELECT mns_constitutor.NCOUNTRY_ID FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP = " + $"{ UNP}";






                var orgModel = new OrganizationModel
                {


                    CreatedateOrg = Convert.ToDateTime(createDateOrg), // Это не правильно делать через приведение к стрингу и назад, но инече я получаю System.InvalidCastException: "Не удалось привести тип объекта "System.Data.OracleClient.OracleDateTime" к типу "System.IConvertible"."
                    FullNameOrg = oracleFullNameOrg.ExecuteOracleScalar().ToString(),
                    ShortNameOrg = oracleSortNameOrg.ExecuteOracleScalar().ToString(),
                    CountyrOrg = rezident,
                    
                };
                oracleConnection.Close();
                oracleOrg = orgModel;
            }
            return oracleOrg ?? new OrganizationModel();// если риск NULL возвращаем пустую модель(чтобы не свалилось в случае чего)
        }



        /* string oracleFullNameOrgComm = "SELECT mns_subject.FULL_NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{UNP}";
         OracleCommand OracleFullNameOrg = new OracleCommand(oracleFullNameOrgComm, oracleConnection);// Поллное название организации
         OracleFullNameOrg.ExecuteOracleScalar();

         string checkUNPComm = "SELECT COUNT(*) FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP =" + $"'{UNP}'";
                OracleCommand CheckUNP = new OracleCommand(checkUNPComm, oracleConnection);// проверка на наличие организации с таким УНП
                CheckUNP.ExecuteOracleScalar();


         string oracleSortNameOrgComm = "SELECT mns_subject.NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ORA_UNP}";
         OracleCommand OracleSortNameOrg = new OracleCommand(oracleSortNameOrgComm, oracleConnection); // Краткое название организации
         OracleSortNameOrg.ExecuteOracleScalar();

         string oracleNameHeadComm = "SELECT mns_subject.FIO_CHIEF FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
         OracleCommand oracleNameHead = new OracleCommand(oracleNameHeadComm, oracleConnection);//ФИО Руководителя
         oracleNameHead.ExecuteOracleScalar();

         string oracleOwnerNameComm = "SELECT mns_constitutor.FULL_NAME FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP =" + $"{ ORA_UNP}";
         OracleCommand oracleOwnerName = new OracleCommand(oracleOwnerNameComm, oracleConnection);// ФИО учредитель
         OracleDataReader oracleOwnerNameReader = oracleOwnerName.ExecuteReader();
         //ORG.ORA_FULL_NAME_PERS = null;
         while (oracleOwnerNameReader.Read())
         {
             ORG.ORA_FULL_NAME_PERS = $"{ORG.ORA_FULL_NAME_PERS}" + $"{ Convert.ToString(oracleOwnerNameReader.GetString(0))}; ";
         }


         string oracleResidentOrgComm = "SELECT mns_constitutor.RESIDENT FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
         OracleCommand oracleResidentOrg = new OracleCommand(oracleResidentOrgComm, oracleConnection);// Получаем резиденство
         oracleResidentOrg.ExecuteOracleScalar(); // наверное это можно убрать, т.к. мы будем получасьт название страны и оно ляжет в комбобокс


         string oracleDateRegistrationComm = "SELECT mns_subject.REG_DATE FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
         OracleCommand oracleDateRegistration = new OracleCommand(oracleDateRegistrationComm, ORA_con);// Дата регистрации
         oracleDateRegistration.ExecuteOracleScalar();
*/


        /*
                        OracleConnection All_Check_Risk = new OracleConnection("All_Check_Risk", sqlConnection);
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
                            };
                        }
                        sqlConnection.Close();*//*
    }
    return oraclePers ?? new PersonModel();// если риск NULL возвращаем пустую модель(чтобы не свалилось в случае чего)
}*/


    }
}
