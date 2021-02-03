using FSharp.Data.Runtime.StructuralTypes;
using InfoNovitas.LoginSample.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Model.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public Boolean Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserInfo UserLastModified { get; set; }
    }
}
