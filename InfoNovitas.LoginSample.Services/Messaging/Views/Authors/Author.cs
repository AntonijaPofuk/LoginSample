using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;

namespace InfoNovitas.LoginSample.Services.Messaging.Views.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public Boolean Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserInfo UserLastModified { get; set; }
    }
}
