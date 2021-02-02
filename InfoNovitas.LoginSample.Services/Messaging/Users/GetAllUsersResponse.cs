using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.User
{
    public class GetAllUsersResponse: LoginSampleResponseBase<GetAllUsersRequest>
    {
        public List<UserInfo> Users { get; set; }
    }
}
