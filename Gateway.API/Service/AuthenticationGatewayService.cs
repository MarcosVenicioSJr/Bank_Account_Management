using Gateway.API.Auth;
using Gateway.API.DTO;
using Gateway.API.Interfaces;
using Gateway.API.Model;

namespace Gateway.API.Service
{
    public class AuthenticationGatewayService : IAuthenticationGatewayService
    {
        private readonly IAuthenticationJwt _authentication;
        private readonly IRepository _repository;

        public AuthenticationGatewayService(IRepository repository, IAuthenticationJwt authentication)
        {
            _repository = repository;
            _authentication = authentication;
        }

        public async Task<UserTokenDTO> Login(LoginRequest model)
        {
            User user = await _repository.GetUserByEmail(model.Email);

            if (user == null)
                throw new Exception("User not found");

            if (user.Password != model.Password)
                throw new Exception("Credentials invalid.");

            UserTokenDTO userToken = _authentication.GenerateToken(model);
            return userToken;
        }

    }
}
