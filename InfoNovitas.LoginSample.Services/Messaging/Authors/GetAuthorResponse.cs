using InfoNovitas.LoginSample.Services.Messaging.Views.Authors;

namespace InfoNovitas.LoginSample.Services.Messaging.Authors
{
    public class GetAuthorResponse: LoginSampleResponseBase<GetAuthorRequest>
    {
        public Author Author { get; set; }
    }
}
