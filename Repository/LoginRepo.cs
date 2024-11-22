using Login.Data;
using Login.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Login.Repository
{
    public class LoginRepo : LoginInterface
    {
        private ApplicationDBContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public LoginRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public User RegisterUser(User user)
        {
            // Don't set the user.Id explicitly
            _dbContext.UserDB.Add(user);
            _dbContext.SaveChanges();
            return user;
        }



        public User GetUserById(int id)
        {
            User user;
            try
            {
                user = _dbContext.UserDB.Find(id);
               
            }
            catch (Exception ex)
            {
                throw;
            }

            return user;
        }

        public User UpdateUser(User user)
        {
            var existingUser = _dbContext.UserDB.Find(user.Id);

            if (existingUser != null)
            {
                // Update the existing user's properties with new values
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.UserName = user.UserName;
                existingUser.EmailId = user.EmailId;
                existingUser.Password = user.Password;

                // Save changes to the database
                _dbContext.SaveChanges();

                // Return the updated user
                return existingUser;
            }

            // Return null or throw an exception if user is not found
            return null;
        }



        public User DeleteUser(int id)
        {
            User user;
            try
            {
                user = _dbContext.Find<User>(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return user;
        }

        public bool LoginUser(string userName, string password)
        {
            // Find the user by username
            var user = _dbContext.UserDB.FirstOrDefault(u => u.UserName == userName);

            return user != null && user.Password == password;

        }
    }
}
