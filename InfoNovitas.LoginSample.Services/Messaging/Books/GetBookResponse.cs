using InfoNovitas.LoginSample.Services.Messaging.Views.Books;

namespace InfoNovitas.LoginSample.Services.Messaging.Books
{
    public class GetBookResponse: LoginSampleResponseBase<GetBookRequest>
    {
        public Book Book { get; set; }
    }
}
