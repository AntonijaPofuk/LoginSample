using InfoNovitas.LoginSample.Services;
using InfoNovitas.LoginSample.Services.Messaging.Authors;
using InfoNovitas.LoginSample.Web.Api.Helpers;
using InfoNovitas.LoginSample.Web.Api.Mapping;
using InfoNovitas.LoginSample.Web.Api.Models.Authors;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InfoNovitas.LoginSample.Web.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {

        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetAllAuthorsRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var authorsResponse = _authorService.GetAllAuthors(request);

            if (!authorsResponse.Success)
            {
                return BadRequest(authorsResponse.Message);
            }

            return Ok(
                new
                {
                    authors = authorsResponse.Authors.MapToViewModels()
                }
            );
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetAuthorRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var authorsResponse = _authorService.GetAuthor(request);

            if (!authorsResponse.Success)
            {
                return BadRequest(authorsResponse.Message);
            }

            return Ok(authorsResponse.Author.MapToViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new DeleteAuthorRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var authorsResponse = _authorService.DeleteAuthor(request);

            if (!authorsResponse.Success)
            {
                return BadRequest(authorsResponse.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(AuthorViewModel author)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            author.UserCreated = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            author.DateCreated = DateTimeOffset.Now;

            var request = new SaveAuthorRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Author = author.MapToView()
            };

            var authorsResponse = _authorService.SaveAuthor(request);

            if (!authorsResponse.Success)
            {
                return BadRequest(authorsResponse.Message);
            }

            return Ok(author = authorsResponse.Author.MapToViewModel());
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, AuthorViewModel author)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            author.UserLastModified = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            author.LastModified = DateTimeOffset.Now;

            var request = new SaveAuthorRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Author = author.MapToView()
            };

            var authorsResponse = _authorService.SaveAuthor(request);

            if (!authorsResponse.Success)
            {
                return BadRequest(authorsResponse.Message);
            }

            return Ok(author = authorsResponse.Author.MapToViewModel());
        }
    }
}
