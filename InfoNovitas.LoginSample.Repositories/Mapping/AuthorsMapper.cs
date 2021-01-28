using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using System.Collections.Generic;
using System.Linq;
using Author = InfoNovitas.LoginSample.Model.Authors.Author;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class AuthorsMapper
    {
        public static Author MapToModel(this Author_Get_Result dbResult)
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
                UserCreated = dbResult.UserCreated.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value
                } : null,
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName,
                LastModified = dbResult.LastModified,
                UserLastModified = dbResult.UserLastModified.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserLastModified.GetValueOrDefault()
                } : null,
            };
        }


      public static Model.Authors.Author MapToAuthor(this DatabaseModel.Author model)
        {
            if (model == null)
                return null;
            return new Model.Authors.Author()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public static List<Model.Authors.Author> MapToModels(this List<DatabaseModel.Author> item)
        {
            var result = new List<Author>();
            if (item == null)
                return null;
            result.AddRange(item.Select(u => u.MapToAuthor()));
            return result;
        }
    }
}