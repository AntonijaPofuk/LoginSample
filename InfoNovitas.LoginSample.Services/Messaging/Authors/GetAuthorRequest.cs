using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Authors
{
    public class GetAuthorRequest : LoginSampleRequestBase
    {
        public int Id { get; set; }
    }
}
