using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Service.List
{
    public interface IImplementionList
    {
        Task<IEnumerable<ListEntity>> FindByCategory(Guid id);
        Task<IEnumerable<ListEntity>> FindByName(string name);

    }
}
