using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Authors
{
    public class SaveUserRequest: LoginSampleRequestBase
    {
        public UserInfo User { get; set; }
    }
}
