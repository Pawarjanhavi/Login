using Login.Data;
using Login.Model;

namespace Login.Model
{
    public class TokenService
    {

        private readonly ApplicationDBContext _context;

        public TokenService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task SaveRefreshToken(string email, string token)
        {
            var refreshToken = new RefreshToken
            {
                Email = email,
                Token = token,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            };

            _context.RefreshTokens.Add(refreshToken);

            await _context.SaveChangesAsync();

        }

        public async Task<string> Retr
    }
}
