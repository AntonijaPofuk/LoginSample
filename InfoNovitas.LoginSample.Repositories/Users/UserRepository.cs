using System;
using System.Collections.Generic;
using System.Linq;
using InfoNovitas.LoginSample.Model.Users;
using Context = InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;

namespace InfoNovitas.LoginSample.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        public List<Model.Users.UserInfo> FindAll()
        {
            using (var context = new Context.IdentityExDbEntities())
            {
                return context.UserInfoes.MapToUserInfos();
            }
        }

        public Model.Users.UserInfo FindBy(int key)
        {
            using (var context = new Context.IdentityExDbEntities())
            {
                return context.UserInfoes.FirstOrDefault(user => user.Id == key).MapToUserInfo();
            }
        }

        public int Add(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public UserInfo Save(UserInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
