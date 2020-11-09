using Kontragent.Commands;
using Kontragent.Domain;
using Kontragent.Domain.Models;
using Kontragent.Domain.Repository;
using Kontragent.Domain.RepositoryInterface;
using Kontragent.Helper;
using Kontragent.Mappers;
using Kontragent.Repository.RepositoryClass;
using Kontragent.Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Search
{
    public class SearchViewModel : BaseViewModel
    { 
        private RelayCommand _searchCommand;
        private ISearchRepository _searchRepository;
        private ObservableCollection<KontragentDataGridItemViewModel> _items;
        private ObservableCollection<SearchWievModelOrg> _itemsOrg;
        private KontragenViewModel _kontragenViewModel;
        private RelayCommand _clearCommand;
        private RelayCommand _dataGridClear;

        public SearchViewModel()
        {
            Items = new ObservableCollection<KontragentDataGridItemViewModel>();
            Kontragent = new KontragenViewModel();
            _searchRepository = new SearchRepository();
            SearchCommand = new RelayCommand(Search, CanSearch);
            ClearCommand = new RelayCommand(Clear);
            DataGridClear = new RelayCommand(ClearDataGrid);
        }
       

        public void ClearDataGrid(object obj)
        {
            Items = null;

        }
        public void Clear(object obj)
        {
            ClearClass.Clear(this);
            Items = null;
        }
        private void Search(object parameter)
        {
            _searchRepository = new SearchRepository();
            var organizationModel = SearchMapperOrg.SearchWievModelOrgToOrganizationModel(Kontragent.OrganizationSearc); // из виью модели делаем модель
            var personModel = SearchMapperPers.SearchWievModelPersToPersonModel(Kontragent.PersonSearc); // из виью модели делаем модель
            var kontragentModels  = _searchRepository.GeneralSearch(organizationModel, personModel);
          
            Items = DataGriViewMOdelMapper.KontragModelToKontraDataGriViewMOdelMapper(kontragentModels);
        }
        private bool CanSearch(object parameter)
        {
            return true;
        }

        public RelayCommand DataGridClear
        {
            get => _dataGridClear;
            set
            {
                _dataGridClear = value;
                OnPropertyChanged(nameof(DataGridClear));
            }
        }

        public RelayCommand ClearCommand
        {
            get => _clearCommand;
            set
            {
                _clearCommand = value;
                OnPropertyChanged(nameof(ClearCommand));
            }
        }

        public RelayCommand SearchCommand
        {
            get => _searchCommand;
            set
            {
                _searchCommand = value;
                OnPropertyChanged(nameof(SearchCommand));
            }
        }
       
        public ObservableCollection<KontragentDataGridItemViewModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public ObservableCollection<SearchWievModelOrg> ItemsOrg
        {
            get => _itemsOrg;
            set
            {
                _itemsOrg = value;
                OnPropertyChanged(nameof(ItemsOrg));
            }
        }

        public KontragenViewModel Kontragent
        {
            get => _kontragenViewModel;
            set
            {
                _kontragenViewModel = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }
}
