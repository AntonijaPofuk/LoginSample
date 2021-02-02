﻿using InfoNovitas.LoginSample.Services.Messaging.Views;
using InfoNovitas.LoginSample.Services.Messaging.Views.Books;
using InfoNovitas.LoginSample.Web.Api.Models;
using InfoNovitas.LoginSample.Web.Api.Models.Books;
using System.Collections.Generic;
using System.Linq;

namespace InfoNovitas.LoginSample.Web.Api.Mapping
{
    public static class BookMapper
    {
        public static BookViewModel MapToViewModel(this Book view)
        {
            if (view == null)
                return null;
            return new BookViewModel()
            {
                Id = view.Id,
                DateCreated = view.DateCreated,
                UserCreated = view.UserCreated.MapToViewModel(),
                Title = view.Title,
                Author = view.Author.MapToViewModel(),
                Description = view.Description,
                LastModified = view.LastModified,
                UserLastModified = view.UserLastModified.MapToViewModel()
            };
        }

        public static Book MapToView(this BookViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new Book()
            {
                Id = viewModel.Id,
                DateCreated = viewModel.DateCreated,
                UserCreated = viewModel.UserCreated.MapToView(),
                Title = viewModel.Title,
                Author = viewModel.Author.MapToView(),
                Description = viewModel.Description,
                LastModified = viewModel.LastModified,
                UserLastModified = viewModel.UserLastModified.MapToView()
            };
        }

        public static List<BookViewModel> MapToViewModels(this IEnumerable<Book> views)
        {
            var result = new List<BookViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}