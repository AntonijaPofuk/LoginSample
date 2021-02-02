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
    }
    }

