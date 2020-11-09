using Kontragent.Mappers;
using Kontragent.Model;
using Kontragent.Repository;
using Kontragent.ViewModel.Autorisation;
using Kontragent.ViewModel.Search;
using Kontragent.ViewModel.Update;
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
    public class MainWindowViewModel : BaseViewModel
    {
      
        private NewOrganizationViewModel _newOrganization;
        private SearchViewModel _searchWievModel;
        private UpdateViewModel _update;

        public WorkUserModel WorkUser { get; private set; }

        /// <summary>
        /// Пустой конструктор делаем privat, чтобы его нельзя было вызвать, а это можно создать только с UserViewModel и при момощи :this сначала вызывает закрытый (пустой) а потом это и уже с Юзером
        /// </summary>
        public MainWindowViewModel()  
        {
            NewOrganization = new NewOrganizationViewModel();
            Search = new SearchViewModel();
            WorkUser = WorkUserSingleton.sourse.WorkUser;
            Update = new UpdateViewModel();
        }

        public UpdateViewModel Update
        {
            get => _update;
            set
            {
                _update = value;
                OnPropertyChanged(nameof(Update));
            }
        }

        public NewOrganizationViewModel NewOrganization
        {
            get => _newOrganization;
            set
            {
                _newOrganization = value;
                OnPropertyChanged(nameof(NewOrganization));
            }
        }

        public SearchViewModel Search
        {
            get => _searchWievModel;
            set
            {
                _searchWievModel = value;
                OnPropertyChanged(nameof(Search));
            }
        }

   
    }
}
