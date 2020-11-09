using Kontragent.Model;
using Kontragent.ViewModel;
using Kontragent.ViewModel.Autorisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.Mappers
{
   public static class UserToAutorisationMapper
    {
        public static UsersModels AuthorizationViewModelToUserModel(AuthorizationViewModel authorizationViewModel)
        {
            var checUsers = new UsersModels
            {
                LoginUser = authorizationViewModel.LoginUser,
                Password = authorizationViewModel.Password,
                Hint = authorizationViewModel.Hint
            };
            return checUsers;
        }


        public static AuthorizationViewModel UserModelToAuthorizationViewModel(UsersModels usersModels)
        {
            var checUsers = new AuthorizationViewModel
            {
                LoginUser = usersModels.LoginUser,
                Password = usersModels.Password,
                Hint = usersModels.Hint
            };
            return checUsers;
        }

        public static UsersModels UserViewModelToUserwModel(UsersViewModel usersViewModels)
        {
            var checUsers = new UsersModels
            {
                LoginUser = usersViewModels.LoginUser,
                Department = usersViewModels.Department,
            };
            return checUsers;
        }

        public static UsersViewModel UserModelToUserwViewModel(UsersModels usersModels)
        {
            var checUsers = new UsersViewModel
            {
                LoginUser = usersModels.LoginUser,
                Department = usersModels.Department,
            };
            return checUsers;
        }

        public static WorkUserViewModel UserModelToWorkUserViewModel(UsersModels usersModels)
        {
            var checUsers = new WorkUserViewModel
            {
                LoginUser = usersModels.LoginUser,
                Department = usersModels.Department,
            };
            return checUsers;
        }

        public static WorkUserViewModel WorkUserModelToWorkUserViewModel(WorkUserModel usersModels)
        {
            var checUsers = new WorkUserViewModel
            {
                LoginUser = usersModels.LoginUser,
                Department = usersModels.Department,
            };
            return checUsers;
        }

        public static WorkUserViewModel AuthorizationViewModelToWorkUserViewModel(AuthorizationViewModel usersModels)
        {
            var checUsers = new WorkUserViewModel
            {
                LoginUser = usersModels.LoginUser,
                Department = usersModels.Department,
            };
            return checUsers;
        }
    }
}

