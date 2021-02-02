﻿using InfoNovitas.LoginSample.Services.Messaging.Views.Books;
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
                Active = view.Active,
                Title = view.Title,
                Description = view.Description
               
             
            };
        }

        public static Book MapToView(this BookViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new Book()
            {
                Id = viewModel.Id,
                Active = viewModel.Active,           
                Description = viewModel.Description,
                Title = viewModel.Title
             
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