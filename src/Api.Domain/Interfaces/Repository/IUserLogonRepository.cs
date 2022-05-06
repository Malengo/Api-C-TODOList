using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IUserLogonRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FingByEmail(string email);
    }
}
