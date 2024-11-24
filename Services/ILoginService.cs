using Login.Model;

namespace Login.Services
{
    public interface ILoginService
    {
        public User RegisterUser(User user);
        public User GetUserById(int UserId);
        public User UpdateUser(User user);
        public User DeleteUser(int UserId);

        public bool LoginUser(string UserName, string Password);
    }
}
