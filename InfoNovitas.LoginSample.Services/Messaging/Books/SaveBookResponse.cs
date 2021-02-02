using InfoNovitas.LoginSample.Services.Messaging.Views.Books;

namespace InfoNovitas.LoginSample.Services.Messaging.Books
{
    public class SaveBookResponse: LoginSampleResponseBase<SaveBookRequest>
    {
        public Book Book { get; set; }
    }
}
