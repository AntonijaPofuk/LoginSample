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
using InfoNovitas.LoginSample.Services.Messaging.Authors;
using InfoNovitas.LoginSample.Services.Messaging.User;

namespace InfoNovitas.LoginSample.Services.Impl
{
    public class UserService:IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
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
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = GenericErrorMessageFactory.GeneralError;
            }

            return response;
        }
        public SaveUserResponse SaveUser(SaveUserRequest request)
        {
            var response = new SaveUserResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                if (request.User?.Id == 0)
                {
                    response.User = request.User;
                    response.User.Id = _repository.Add(request.User.MapToModel());
                    response.Success = true;
                }
                else if (request.User?.Id > 0)
                {
                    response.User = _repository.Save(request.User.MapToModel()).MapToView();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        GetAllUsersResponse IUserService.GetAllUsers(GetAllUsersRequest request)
        {
            var response = new GetAllUsersResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Users = _repository.FindAll().MapToViews();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
