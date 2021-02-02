using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoNovitas.LoginSample.Model;
using InfoNovitas.LoginSample.Services.Messaging.Views.Books;

namespace InfoNovitas.LoginSample.Services.Mapping
{
    public static class BookMaper
    {
        public static Messaging.Views.Books.Book MapToView(this Book model)
        {
            return Mapper.Map<Messaging.Views.Books.Book>(model);
        }

        public static Book MapToModel(this Messaging.Views.Books.Book view)
        {
            return Mapper.Map<Book>(view);
        }

        public static List<Messaging.Views.Books.Book> MapToViews(this IEnumerable<Book> models)
        {
            var result = new List<Messaging.Views.Books.Book>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }
}
