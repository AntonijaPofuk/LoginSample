using InfoNovitas.LoginSample.Web.Api.Models.Users;
using InfoNovitas.LoginSample.Web.Api.Models.Authors;
using System;

namespace InfoNovitas.LoginSample.Web.Api.Models.Books
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserViewModel UserCreated { get; set; }
        public string Title { get; set; }
        public AuthorViewModel Author { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserViewModel UserLastModified { get; set; }
    }
}