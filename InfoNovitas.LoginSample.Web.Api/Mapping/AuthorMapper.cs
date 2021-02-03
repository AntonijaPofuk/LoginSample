using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;
using InfoNovitas.LoginSample.Web.Api.Models.Authors;
using System.Collections.Generic;
using System.Linq;

namespace InfoNovitas.LoginSample.Web.Api.Mapping
{
    public static class AuthorMapper
    {
        public static AuthorViewModel MapToViewModel(this Author view)
        {
            if (view == null)
                return null;
            return new AuthorViewModel()
            {
                Id = view.Id,
                DateCreated = view.DateCreated,
                UserCreated = view.UserCreated.MapToViewModel(),
                FirstName = view.FirstName,
                Note = view.Note,
                Description = view.Description,
                LastName = view.LastName,
                LastModified = view.LastModified,
                FullName = view.FullName,
                UserLastModified = view.UserLastModified.MapToViewModel()
            };
        }

        public static Author MapToView(this AuthorViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new Author()
            {
                Id = viewModel.Id,
                DateCreated = viewModel.DateCreated,
                UserCreated = viewModel.UserCreated.MapToView(),
                FirstName = viewModel.FirstName,
                FullName = viewModel.FullName,
                Note = viewModel.Note,
                Description = viewModel.Description,
                LastName = viewModel.LastName,
                LastModified = viewModel.LastModified,
                UserLastModified = viewModel.UserLastModified.MapToView()
            };
        }

       
        public static List<AuthorViewModel> MapToViewModels(this IEnumerable<Author> views)
        {
            var result = new List<AuthorViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}