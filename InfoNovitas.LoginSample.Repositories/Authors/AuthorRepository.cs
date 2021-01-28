using InfoNovitas.LoginSample.Model.Authors;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System.Collections.Generic;
using System.Linq;
using InfoNovitas.LoginSample.Model.Authors;


namespace InfoNovitas.LoginSample.Repositories.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        public int Add(Model.Authors.Author item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Model.Authors.Author item)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Authors.Author> FindAll()
        {
            using (var context = new IdentityExDbEntities())
            {
                List<Model.Authors.Author> list = new List<Model.Authors.Author>();
                list.Add(context.Author_Get(2).SingleOrDefault().MapToModel());
                return list;
            }
        }

        public Model.Authors.Author FindBy(int key)
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Author_Get(key).SingleOrDefault().MapToModel();
            }
        }

        public Model.Authors.Author Save(Model.Authors.Author item)
        {
            throw new System.NotImplementedException();
        }
    }
}
