using InfoNovitas.LoginSample.Services.Messaging.Books;
using System.Collections.Generic;

namespace InfoNovitas.LoginSample.Services
{
    public interface IBookService
    {
        GetAllBooksResponse GetAllBooks(GetAllBooksRequest request);
        GetBookResponse GetBook(GetBookRequest request);
        DeleteBookResponse DeleteBook(DeleteBookRequest request);
        SaveBookResponse SaveBook(SaveBookRequest request);
    }
}
