using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Service.List
{
    public interface IListService
    {
        Task<ListEntity> Get(Guid id);

        Task<IEnumerable<ListEntity>> GetAll();

        Task<ListEntity> Post(ListEntity list);

        Task<ListEntity> Put(ListEntity list);

        Task<bool> Delete(Guid id);

    }
}
