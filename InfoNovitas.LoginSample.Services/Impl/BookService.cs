using InfoNovitas.LoginSample.Model;
using InfoNovitas.LoginSample.Model.Books;
using InfoNovitas.LoginSample.Services.Mapping;
using InfoNovitas.LoginSample.Services.Messaging;
using InfoNovitas.LoginSample.Services.Messaging.Books;
using System;
using System.Collections.Generic;

namespace InfoNovitas.LoginSample.Services.Impl
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }
        public GetAllBooksResponse GetAllBooks(GetAllBooksRequest request)
        {
            var response = new GetAllBooksResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Books = _repository.FindAll().MapToViews();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public DeleteBookResponse DeleteBook(DeleteBookRequest request)
        {
            var response = new DeleteBookResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Delete(
                    new Book()
                    {
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
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
        public GetBookResponse GetBook(GetBookRequest request)
        {
            var response = new GetBookResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Book = _repository.FindBy(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public SaveBookResponse SaveBook(SaveBookRequest request)
        {
            var response = new SaveBookResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                if (request.Book?.Id == 0)
                {
                    response.Book = request.Book;
                    response.Book.Id = _repository.Add(request.Book.MapToModel());
                    response.Success = true;
                }
                else if (request.Book?.Id > 0)
                {
                    response.Book = _repository.Save(request.Book.MapToModel()).MapToView();
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

