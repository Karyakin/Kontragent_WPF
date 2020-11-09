using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kontragent.ViewModel
{
    /// <summary>
    /// Данный класс предназначен для получения данных  из справочных таблиц Country и Section и последующей загрузки 
    /// в выподающие списки для заполнения Новой организации
    /// </summary>
    public class GetCountrySectionViewModel : BaseViewModel
    {

      public  GetCountrySectionViewModel()
        {
          //  GetCountrySection();


        }


        private static string connectionStringSQL = ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
        List<string> countryList = new List<string>();
        List<string> sectionList = new List<string>();


        private string _selectedCountry;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
                // MessageBox.Show($"SelectedCountry - {SelectedCountry.ToString()}");
            }
        }

        public void GetCountrySection()
        {
            string getCountryCommandString = "SELECT Name_Country, Risk_Country FROM Country";
            string getSectionCommandString = "SELECT Name_Section, Risk_Section FROM Section";
            using (SqlConnection sqlConnection = new SqlConnection(connectionStringSQL))
            {
                sqlConnection.Open();
                SqlCommand GetCountryCommand = new SqlCommand(getCountryCommandString, sqlConnection);
                SqlCommand GetSectionCommand = new SqlCommand(getSectionCommandString, sqlConnection);

                SqlDataReader dataReaderCounrtru = GetCountryCommand.ExecuteReader();
                while (dataReaderCounrtru.Read())
                {
                    countryList.Add(dataReaderCounrtru.GetString(0));
                }
                dataReaderCounrtru.Close();

                SqlDataReader dataReaderSection = GetSectionCommand.ExecuteReader();
                while (dataReaderSection.Read())
                {
                    sectionList.Add(dataReaderSection.GetString(0));
                }
                dataReaderSection.Close();
                sqlConnection.Close();
            }
            // var countryDataSource = new BindingSource();
        }

        private string _countyrOrg;
        public string CountyrOrg
        {
            get => _countyrOrg;
            set
            {
                _countyrOrg = value;
                OnPropertyChanged(nameof(CountyrOrg));
            }
        }

        /// <summary>
        /// Это свойство для того, что будет отображатся в списке
        /// </summary>
        private List<String> _itemsSourceCountry;
        public List<String> ItemsSourceCountry
        {
            get => countryList;
            set
            {
                _itemsSourceCountry = value;
                OnPropertyChanged(nameof(ItemsSourceCountry));
            }
        }
    }
}

