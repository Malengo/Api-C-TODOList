using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Service
{
    public class LoginService : IUserLogon
    {
        private IUserLogonRepository _repository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;

        private IConfiguration _configuration;

        public LoginService(IUserLogonRepository repository, SigningConfiguration signingConfiguration, TokenConfiguration tokenConfiguration, IConfiguration configuration)
        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }

        public async Task<object> FindByEmail(LoginDto user)
        {
            var baseUser = new UserEntity();
            if (user != null)
            {
                baseUser = await _repository.FingByEmail(user.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]{
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, user);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM--dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM--dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Usuário Logado com sucesso"
            };
        }
    }
}
