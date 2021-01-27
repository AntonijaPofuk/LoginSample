using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoNovitas.LoginSample.Repositories;
using InfoNovitas.LoginSample.Services.Mapping;
using InfoNovitas.LoginSample.Services.Messaging.Users;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using InfoNovitas.LoginSample.Services.Messaging;

namespace InfoNovitas.LoginSample.Services.Impl
{
    public class UserService:IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public GetUserInfoResponse GetUserInfo(GetUserInfoRequest request)
        {
            var response = new GetUserInfoResponse()
            {
                ResponseToken = Guid.NewGuid(),
                Request = request
            };

            try
            {
                response.User = _repository.FindBy(request.UserId).MapToView();
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = GenericErrorMessageFactory.GeneralError;
            }

            return response;
        }

        public UserInfo GetUserInfo(int userId)
        {
            try
            {
                return _repository.FindBy(userId).MapToView();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
