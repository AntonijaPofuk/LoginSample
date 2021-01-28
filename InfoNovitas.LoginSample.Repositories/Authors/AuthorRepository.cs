using InfoNovitas.LoginSample.Model.Authors;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System.Collections.Generic;
using System.Linq;

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
                foreach (var item in context.Authors_Get().ToList()) {
                    list.Add(item.MapToModels());
                }
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
