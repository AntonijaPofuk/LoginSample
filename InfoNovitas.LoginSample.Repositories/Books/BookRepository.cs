using InfoNovitas.LoginSample.Model;
using InfoNovitas.LoginSample.Model.Books;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoNovitas.LoginSample.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        public int Add(Model.Books.Book item)
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Book_Insert(item.Title, item.Author?.Id, item.Description, item.UserCreated?.Id);
            }
        }

        public bool Delete(Model.Books.Book item)
        {
            try
            {
                using (var context = new IdentityExDbEntities())
                {
                    context.Book_Delete(item.Id, item.UserLastModified?.Id);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The exception is: '{e}'");
                return false;
            }
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

        public Model.Books.Book FindBy(int key)
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.BookData_Get(key).SingleOrDefault().MapToModel();

            }
        }

        public Model.Books.Book Save(Model.Books.Book item)
        {
            using (var context = new IdentityExDbEntities())
            {
                context.Book_Save(item.Id, item.Title, item.Author?.Id, item.Description, item.UserLastModified?.Id);
                return item;
            }
        }
    }
}
