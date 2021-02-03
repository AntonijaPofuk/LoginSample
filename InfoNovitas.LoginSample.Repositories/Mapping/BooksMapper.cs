using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using System.Collections.Generic;
using System.Linq;
using Author = InfoNovitas.LoginSample.Model.Authors.Author;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class BooksMapper
    {
        public static Model.Books.Book MapToModel(this BookData_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Books.Book()
            {
                Id = dbResult.Id,
                Title = dbResult.Title,
                Active = dbResult.Active,
                Description = dbResult.Description
              

            };
        }

        public static Model.Books.Book MapToModels(this Books_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Books.Book()
            {
                Id = dbResult.Id,
                Active = dbResult.Active,
                Title = dbResult.Title,
                Description = dbResult.Description              
            };
        }    
    }
}