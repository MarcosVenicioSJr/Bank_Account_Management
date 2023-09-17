using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Gateway.API.DTO;
using Gateway.API.Interfaces;
using Microsoft.IdentityModel.Tokens;


namespace Gateway.API.Auth
{
    public class Authentication : IAuthenticationJwt
    {
        public static string Secret = "1f9530d24326e14d9431f0134b25ecb5fb33c7ce289a8487f54ca156ea80b02a";

        public UserTokenDTO GenerateToken(LoginRequest user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserTokenDTO()
            {
                Email = user.Email,
                ExpirationDate = tokenDescriptor.Expires,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
