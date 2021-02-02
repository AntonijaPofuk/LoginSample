using InfoNovitas.LoginSample.Services.Messaging.Views.Books;
using System;
using System.Collections.Generic;
using InfoNovitas.LoginSample.Services.Messaging.Views.Books;

namespace InfoNovitas.LoginSample.Services.Messaging.Books
{
    public class GetAllBooksResponse: LoginSampleResponseBase<GetAllBooksRequest>
    {
        public List<Book> Books { get; set; }
    }
}
