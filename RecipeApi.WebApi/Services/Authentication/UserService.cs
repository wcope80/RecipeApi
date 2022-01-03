using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RecipeApi.WebApi.Models;
using RecipeApi.WebApi.Services.Authentication.Interfaces;

namespace RecipeApi.WebApi.Services.Authentication
{
    public class UserService : IUserService
    {
        private readonly JWTKey _jwtKey;
        private readonly IUserContext _userContext;

        public UserService(IOptions<JWTKey> jwtKey, IUserContext userContext)
        {
            _jwtKey = jwtKey.Value;
            _userContext = userContext;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userContext.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users;
        }

        public User GetById(int id)
        {
            return _userContext.Users.FirstOrDefault(x => x.Id == id);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}