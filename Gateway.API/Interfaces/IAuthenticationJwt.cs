using Gateway.API.DTO;

namespace Gateway.API.Interfaces
{
    public interface IAuthenticationJwt
    {
        UserTokenDTO GenerateToken(LoginRequest user);
    }
}
