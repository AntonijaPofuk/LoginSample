using AutoMapper;
using InfoNovitas.LoginSample.Model.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views = InfoNovitas.LoginSample.Services.Messaging.Views;

namespace InfoNovitas.LoginSample.Services.Mapping
{
    public static class AuthorMapper
    {
        public static Views.Authors.Author MapToView(this Author model)
        {
            return Mapper.Map<Views.Authors.Author>(model);
        }

        public static Author MapToModel(this Views.Authors.Author view)
        {
            return Mapper.Map<Author>(view);
        }

        public static List<Views.Authors.Author> MapToViews(this IEnumerable<Author> models)
        {
            var result = new List<Views.Authors.Author>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }
}
