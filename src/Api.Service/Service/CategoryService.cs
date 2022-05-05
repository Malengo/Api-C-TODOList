using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Service.Category;

namespace Api.Service.Service
{
    public class CategoryService : ICategoryService
    {
        private IRepository<CategoryEntity> _repository;

        public CategoryService(IRepository<CategoryEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CategoryEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<CategoryEntity>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<CategoryEntity> Post(CategoryEntity category)
        {
            return await _repository.InsertAsync(category);
        }

        public async Task<CategoryEntity> Put(CategoryEntity category)
        {
            return await _repository.UpdateAsync(category);
        }
    }
}
