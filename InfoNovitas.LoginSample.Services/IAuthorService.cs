using InfoNovitas.LoginSample.Services.Messaging.Authors;
using System.Collections.Generic;

namespace InfoNovitas.LoginSample.Services
{
    public interface IAuthorService
    {
        GetAllAuthorsResponse GetAllAuthors(GetAllAuthorsRequest request);
        GetAuthorResponse GetAuthor(GetAuthorRequest request);
        DeleteAuthorResponse DeleteAuthor(DeleteAuthorRequest request);
        SaveAuthorResponse SaveAuthor(SaveAuthorRequest request);
    }
}
