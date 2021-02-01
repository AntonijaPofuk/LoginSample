using InfoNovitas.LoginSample.Services.Messaging.Views.Users;

namespace InfoNovitas.LoginSample.Services.Messaging.Authors
{
    public class SaveUserResponse: LoginSampleResponseBase<SaveUserRequest>
    {
        public UserInfo User { get; set; }
    }
}
