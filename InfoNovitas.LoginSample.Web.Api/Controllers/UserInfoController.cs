using System.Web;
using System.Web.Http;
using InfoNovitas.LoginSample.Services;
using InfoNovitas.LoginSample.Web.Api.Helpers;
using InfoNovitas.LoginSample.Web.Api.Models.Users;
using InfoNovitas.LoginSample.Services.Messaging.Users;
using System;
using InfoNovitas.LoginSample.Web.Api.Mapping;
using InfoNovitas.LoginSample.Services.Messaging.Authors;

namespace InfoNovitas.LoginSample.Web.Api.Controllers
{
    [Authorize]
    public class UserInfoController : ApiController
    {
        private IUserService _userService;

        public UserInfoController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var user = _userService.GetUserInfo(id);
            var result = new UserViewModel()
            {
                Id = user.Id,
                Lastname = user.LastName,
                Firstname = user.FirstName,
                Email = user.Email
            };
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            //retrieve userid from Bearer token
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetUserInfoRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var response = _userService.GetUserInfo(request);

            if (response.Success)
            {
                return Ok(response.User.MapToViewModel());
            }

            return BadRequest(response.Message);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(UserViewModel user)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

          

            var request = new SaveUserRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                User = user.MapToView()
            };

            var usersResponse = _userService.SaveUser(request);

            if (!usersResponse.Success)
            {
                return BadRequest(usersResponse.Message);
            }

            return Ok(user = usersResponse.User.MapToViewModel());
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(UserViewModel user)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new SaveUserRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                User = user.MapToView()
            };

            var usersResponse = _userService.SaveUser(request);

            if (!usersResponse.Success)
            {
                return BadRequest(usersResponse.Message);
            }

            return Ok(user = usersResponse.User.MapToViewModel());
        }


    }
}
