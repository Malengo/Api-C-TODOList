using Api.Domain.Dtos;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Service.User;

namespace Api.Service.Service
{
    public class LoginService : IUserLogon
    {
        private IUserLogonRepository _repository;

        public LoginService(IUserLogonRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByEmail(LoginDto user)
        {
            if (user != null)
            {
                return await _repository.FingByEmail(user.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
