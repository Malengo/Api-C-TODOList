using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Service.User
{
    public interface IUserLogon
    {
        Task<object> FindByEmail(UserEntity user);
    }
}
