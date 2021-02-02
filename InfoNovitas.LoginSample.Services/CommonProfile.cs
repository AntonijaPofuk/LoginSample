using AutoMapper;
using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using InfoNovitas.LoginSample.Services.Messaging.Views.Books;

namespace InfoNovitas.LoginSample.Services
{
    /// <summary>
    /// Creates a mapping between source (Domain) and destination (ViewModel)
    /// </summary>
    public class CommonProfile: Profile
    {
        
        protected override void Configure()
        {
            CreateMap<UserInfo, Model.Users.UserInfo>();
            CreateMap<Author, Model.Authors.Author>();
            CreateMap<Book, Model.Books.Book>();


            CreateMap<Model.Users.UserInfo, UserInfo>();
            CreateMap<Model.Authors.Author, Author>();
            CreateMap<Model.Books.Book, Book>();

        }
    }
}
