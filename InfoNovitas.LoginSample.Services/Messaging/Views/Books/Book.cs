using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;

namespace InfoNovitas.LoginSample.Services.Messaging.Views.Books
{
    public class Book
    {
        public int Id { get; set; }
        public Boolean Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserInfo UserLastModified { get; set; }
    }
}
