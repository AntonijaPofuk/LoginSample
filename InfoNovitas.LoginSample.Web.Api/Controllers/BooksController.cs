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

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetBookRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var booksResponse = _bookService.GetBook(request);

            if (!booksResponse.Success)
            {
                return BadRequest(booksResponse.Message);
            }

            return Ok(booksResponse.Book.MapToViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new DeleteBookRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var booksResponse = _bookService.DeleteBook(request);

            if (!booksResponse.Success)
            {
                return BadRequest(booksResponse.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(BookViewModel book)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            book.UserCreated = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            book.DateCreated = DateTimeOffset.Now;

            var request = new SaveBookRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Book = book.MapToView()
            };

            var booksResponse = _bookService.SaveBook(request);

            if (!booksResponse.Success)
            {
                return BadRequest(booksResponse.Message);
            }

            return Ok(book = booksResponse.Book.MapToViewModel());
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, BookViewModel book)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            book.UserLastModified = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            book.LastModified = DateTimeOffset.Now;

            var request = new SaveBookRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Book = book.MapToView()
            };

            var booksResponse = _bookService.SaveBook(request);

            if (!booksResponse.Success)
            {
                return BadRequest(booksResponse.Message);
            }

            return Ok(book = booksResponse.Book.MapToViewModel());
        }
    }
}