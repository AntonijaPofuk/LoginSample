using AutoMapper;
using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;

namespace InfoNovitas.LoginSample.Services
{
    public class CommonProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<UserInfo, Model.Users.UserInfo>();
            CreateMap<Author, Model.Authors.Author>();

            CreateMap<Model.Users.UserInfo, UserInfo>();
            CreateMap<Model.Authors.Author, Author>();
        }
    }
}
