using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using Author = InfoNovitas.LoginSample.Model.Authors.Author;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class AuthorsMapper
    {
        public static Author MapToModel(this AuthorData_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Author()
            {
                Id = dbResult.Id,
                DateCreated = dbResult.DateCreated,
                Active = dbResult.Active,
                UserCreated = dbResult.UserCreated.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value,
                    FullName = dbResult.UserCreatedFullName

                } : null,
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName,
                Note = dbResult.Note,
                Description = dbResult.Description,
                LastModified = dbResult.LastModified,
                UserLastModified = dbResult.UserLastModified.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserLastModified.GetValueOrDefault(),
                    FullName = dbResult.UserLastModifiedFullName
                } : null,
            };
        }

        public static Author MapToModels(this Authors_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Author()
            {
                Id = dbResult.Id,
                DateCreated = dbResult.DateCreated,
                Active = dbResult.Active,
                Note = dbResult.Note,
                Description = dbResult.Description,
                UserCreated = dbResult.UserCreated.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value
             
                } : null,
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName              
            };
        }    
    }
}