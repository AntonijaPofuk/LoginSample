using System;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Authentication
{
    public class AuthRepository : IDisposable
    {
        private readonly MyUserManager _userManager;
        private readonly ApplicationDbContext _ctx;

        public AuthRepository()
        {
            _userManager = MyUserManager.Initialize();
            _ctx = new ApplicationDbContext();
        }

        public async Task<MyUser> FindUserAsync(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public MyUser FindUser(string username, string password)
        {
            return AsyncHelpers.RunSync<MyUser>(() => _userManager.FindAsync(username, password));
        }


        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}
