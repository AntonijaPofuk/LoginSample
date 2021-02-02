using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Books
{
    public class GetBookRequest : LoginSampleRequestBase
    {
        public int Id { get; set; }
    }
}
