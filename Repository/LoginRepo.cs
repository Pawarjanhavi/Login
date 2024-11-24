using Login.Data;
using Login.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Login.Services;

namespace Login.Repository
{
    public class LoginRepo : Services.ILoginService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public LoginRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public User RegisterUser(User user)
        {
            // Don't set the user.Id explicitly
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }



        public User GetUserById(int id)
        {
            User user;
            try
            {
                user = _dbContext.Users.Find(id);
               
            }
            catch (Exception ex)
            {
                throw;
            }

            return user;
        }

        public User UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.Find(user.UserId);

            if (existingUser != null)
            {
                // Update the existing user's properties with new values
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
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
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == userName);

            return user != null && user.Password == password;

        }
    }
}
