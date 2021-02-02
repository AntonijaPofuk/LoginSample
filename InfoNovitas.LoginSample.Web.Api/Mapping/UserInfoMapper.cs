using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using InfoNovitas.LoginSample.Web.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Mapping
{
    public static class UserInfoMapper
    {
        public static UserViewModel MapToViewModel(this UserInfo view)
        {
            if (view == null)
                return null;
            return new UserViewModel()
            {
                Id = view.Id,
                Email = view.Email,
                Firstname = view.FirstName,
                Lastname = view.LastName,
                FullName = view.FullName
            };
        }

        public static UserInfo MapToView(this UserViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new UserInfo()
            {
                Id = viewModel.Id,
                Email = viewModel.Email,
                FirstName = viewModel.Firstname,
                LastName = viewModel.Lastname,
                FullName = viewModel.FullName
            };
        }

        public static List<UserViewModel> MapToViewModels(this IEnumerable<UserInfo> views)
        {
            var result = new List<UserViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}