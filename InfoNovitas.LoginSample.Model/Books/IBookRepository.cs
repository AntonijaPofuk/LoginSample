using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Model.Books
{
    public interface IBookRepository:IRepository<Book,int>
    {
    }
}
