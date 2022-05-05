using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Service.List;

namespace Api.Service.Service
{
    public class ListService : IListService
    {
        private IRepository<ListEntity> _repository;


        public ListService(IRepository<ListEntity> repository)
        {
            _repository = repository;

        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }



        public async Task<ListEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ListEntity>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<ListEntity> Post(ListEntity list)
        {
            return await _repository.InsertAsync(list);
        }

        public async Task<ListEntity> Put(ListEntity list)
        {
            return await _repository.UpdateAsync(list);
        }
    }
}
