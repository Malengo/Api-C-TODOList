using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IListRepository : IRepository<ListEntity>
    {
        Task<IEnumerable<ListEntity>> FindByCategory(Guid id);
        Task<IEnumerable<ListEntity>> FindByName(string name);

    }
}
