using InfoNovitas.LoginSample.Services;
using InfoNovitas.LoginSample.Web.Api.Helpers;
using InfoNovitas.LoginSample.Web.Api.Mapping;
using InfoNovitas.LoginSample.Services.Messaging.Books;
using InfoNovitas.LoginSample.Web.Api.Models.Books;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InfoNovitas.LoginSample.Web.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private IBookService _bookService; //injection

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetAllBooksRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var booksResponse = _bookService.GetAllBooks(request);

            if (!booksResponse.Success)
            {
                return BadRequest(booksResponse.Message);
            }

            return Ok(
                new
                {
                    books = booksResponse.Books.MapToViewModels()
                }
            );
        }
    }
}