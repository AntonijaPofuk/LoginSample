using InfoNovitas.LoginSample.Model.Authors;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
