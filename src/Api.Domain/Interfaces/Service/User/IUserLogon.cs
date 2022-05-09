using Api.Domain.Dtos;

namespace Api.Domain.Interfaces.Service.User
{
    public interface IUserLogon
    {
        Task<object> FindByEmail(LoginDto user);
    }
}
