using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Users
{
    public class GetUserInfoResponse:LoginSampleResponseBase<GetUserInfoRequest>
    {
        public UserInfo User { get; set; }
    }
}
