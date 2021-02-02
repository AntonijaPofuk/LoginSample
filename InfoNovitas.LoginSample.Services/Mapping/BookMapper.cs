using AutoMapper;
using InfoNovitas.LoginSample.Model.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views = InfoNovitas.LoginSample.Services.Messaging.Views;

namespace InfoNovitas.LoginSample.Services.Mapping
{
    public static class BookMapper
    {
        public static Views.Books.Book MapToView(this Book model)
        {


            return Mapper.Map<Views.Books.Book>(model);

            // return Mapper.Map<Views.Books.Book>(model); 
        }

        public static Book MapToModel(this Views.Books.Book view)
        {
            return Mapper.Map<Book>(view);
        }

        public static List<Views.Books.Book> MapToViews(this IEnumerable<Book> models)
        {
            var result = new List<Views.Books.Book>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }
}
