using InfoNovitas.LoginSample.Model.Books;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using Book = InfoNovitas.LoginSample.Model.Books.Book;

namespace InfoNovitas.LoginSample.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        public int Add(Book item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Book item)
        {
            throw new NotImplementedException();
        }

        public List<Model.Books.Book> FindAll()
        {
            using (var context = new IdentityExDbEntities())
            {
                List<Model.Books.Book> list = new List<Model.Books.Book>();
                foreach (var item in context.Books_Get().ToList())
                {
                    list.Add(item.MapToModels());
                }
                return list;
            }
        }

        public Book FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public Book Save(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
