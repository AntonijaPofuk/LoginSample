using InfoNovitas.LoginSample.Model.Authors;
using InfoNovitas.LoginSample.Services.Mapping;
using InfoNovitas.LoginSample.Services.Messaging.Authors;
using System;
using System.Collections.Generic;

namespace InfoNovitas.LoginSample.Services.Impl
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public DeleteAuthorResponse DeleteAuthor(DeleteAuthorRequest request)
        {
            var response = new DeleteAuthorResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Delete(
                    new Author() {
                        Id = request.Id,
                        LastModified = DateTimeOffset.Now,
                        UserLastModified = new Model.Users.UserInfo()
                            {
                                Id = request.UserId
                            }
                    }
                    );
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public GetAllAuthorsResponse GetAllAuthors(GetAllAuthorsRequest request)
        {
            var response = new GetAllAuthorsResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Authors = _repository.FindAll().MapToViews();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public GetAuthorResponse GetAuthor(GetAuthorRequest request)
        {
            var response = new GetAuthorResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Author = _repository.FindBy(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public SaveAuthorResponse SaveAuthor(SaveAuthorRequest request)
        {
            var response = new SaveAuthorResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                if(request.Author?.Id == 0)
                {
                    response.Author = request.Author;
                    response.Author.Id = _repository.Add(request.Author.MapToModel());
                    response.Success = true;
                }
                else if(request.Author?.Id > 0)
                {
                    response.Author = _repository.Save(request.Author.MapToModel()).MapToView();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
