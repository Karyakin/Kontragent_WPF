using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Search
{
   public class KontragenViewModel : BaseViewModel
    {
        private SearchWievModelPers _searchWievModelPers;
        private SearchWievModelOrg _searchWievModelOrg;

        public KontragenViewModel(SearchWievModelOrg searchWievModelOrg, SearchWievModelPers searchWievModelPers )
        {
            OrganizationSearc = searchWievModelOrg;
            PersonSearc = searchWievModelPers;


        }

        public KontragenViewModel()
        {
            OrganizationSearc = new SearchWievModelOrg();
            PersonSearc = new SearchWievModelPers();
        }


        public SearchWievModelPers PersonSearc
        {
            get => _searchWievModelPers;
            set
            {
                _searchWievModelPers = value;
                OnPropertyChanged(nameof(PersonSearc));
            }
        }

        public SearchWievModelOrg OrganizationSearc
        {
            get => _searchWievModelOrg;
            set
            {
                _searchWievModelOrg = value;
                OnPropertyChanged(nameof(OrganizationSearc));
            }
        }

    }
}
