using Gateway.API.DTO;

namespace Gateway.API.Interfaces
{
    public interface IAuthenticationGatewayService
    {
        Task<UserTokenDTO> Login(LoginRequest model);
    }
}
