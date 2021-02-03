﻿using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using System.Collections.Generic;
using System.Linq;

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
                Description = dbResult.Description,
                DateCreated =  dbResult.DateCreated,
                Author =new Model.Authors.Author() 
                {
                    Id = dbResult.Author,
                    FullName = dbResult.AuthorFullName
                },
                UserCreated = new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value,
                    FullName = dbResult.UserCreatedFullName
                },
                  UserLastModified = new Model.Users.UserInfo()
                  {
                      Id = dbResult.UserLastModified.Value,
                    FullName = dbResult.UserLastModifiedFullName
                  }


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
                Description = dbResult.Description,
                DateCreated = dbResult.DateCreated,
                Author = new Model.Authors.Author()
                {
                    Id = dbResult.Author                
                },
                UserCreated = new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value
                }
                

            };
        }    
    }
}