using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Service.Category
{
    public interface ICategoryService
    {
        Task<CategoryEntity> Get(Guid id);

        Task<IEnumerable<CategoryEntity>> GetAll();

        Task<CategoryEntity> Post(CategoryEntity category);

        Task<CategoryEntity> Put(CategoryEntity category);

        Task<bool> Delete(Guid id);

    }
}
