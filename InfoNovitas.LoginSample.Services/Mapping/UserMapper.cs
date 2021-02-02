using AutoMapper;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System.Collections.Generic;
using System.Linq;
using InfoNovitas.LoginSample.Model.Users;


namespace InfoNovitas.LoginSample.Services.Mapping
{
    public static class UserMapper
    {
        public static Messaging.Views.Users.UserInfo MapToView(this Model.Users.UserInfo model)
        {
            return Mapper.Map<Messaging.Views.Users.UserInfo>(model);
        }
              
        public static Model.Users.UserInfo MapToModel(this Messaging.Views.Users.UserInfo view)
        {
            if (view == null)
                return null;
            return new Model.Users.UserInfo()
            {
                Id = view.Id,
                Email = view.Email,
                FirstName = view.FirstName,
                LastName = view.LastName
            };
        }

        public static Model.Users.UserInfo MapToModel2(this Messaging.Views.Users.UserInfo view)
        {
            return Mapper.Map<Model.Users.UserInfo>(view);
        }

        public static List<Messaging.Views.Users.UserInfo> MapToViews(this IEnumerable<Model.Users.UserInfo> models) {
            var result = new List<Messaging.Views.Users.UserInfo>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }

    }
}
