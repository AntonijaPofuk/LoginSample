using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging
{
    public abstract class LoginSampleRequestBase
    {
        public Guid RequestToken { get; set; }
        public int UserId { get; set; }
    }
}
