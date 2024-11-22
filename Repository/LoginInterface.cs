using Login.Model;

namespace Login.Repository
{
    public interface LoginInterface
    {
        //public User RegisterUser(User user);
        public User GetUserById(int id);
        public User UpdateUser(User user);
        public User DeleteUser(int id);

        public bool LoginUser(string userName, string password);
    }
}
