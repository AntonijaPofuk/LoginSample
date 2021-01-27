using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;

namespace InfoNovitas.LoginSample.Services.Messaging.Authors
{
    public class SaveAuthorResponse: LoginSampleResponseBase<SaveAuthorRequest>
    {
        public Author Author { get; set; }
    }
}
