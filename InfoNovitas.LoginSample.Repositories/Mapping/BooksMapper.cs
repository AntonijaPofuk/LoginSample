using InfoNovitas.LoginSample.Model.Books;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using Book = InfoNovitas.LoginSample.Model.Books.Book;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class BooksMapper
    {
        public static Model.Books.Book MapToModel(this BookData_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Book()
            {
                Id = dbResult.Id,
                DateCreated = dbResult.DateCreated,
                Active = dbResult.Active,
                UserCreated = dbResult.UserCreated.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value

                } : null,
                Title = dbResult.Title,   
                Description = dbResult.Description,
                UserLastModified = dbResult.UserLastModified.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserLastModified.GetValueOrDefault(),
                    FullName = dbResult.UserLastModifiedFullName
                } : null,
                LastModified = (System.DateTimeOffset)dbResult.LastModified,
              

            };
        }

        public static Book MapToModels(this Books_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Books.Book()
            {
                Id = dbResult.Id,
                DateCreated = dbResult.DateCreated,
                Active = dbResult.Active,
                UserCreated = dbResult.UserCreated.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value

                } : null,
                Title = dbResult.Title,
                Description = dbResult.Description,      
               
               
            };
        }    
    }
}