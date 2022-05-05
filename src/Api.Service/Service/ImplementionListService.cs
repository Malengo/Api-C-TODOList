using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Service.List;

namespace Api.Service.Service
{
    public class ImplementionListService : IImplementionList
    {
        private IListRepository _repository;

        public ImplementionListService(IListRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ListEntity>> FindByCategory(Guid id)
        {
            return await _repository.FindByCategory(id);
        }

        public async Task<IEnumerable<ListEntity>> FindByName(string name)
        {
            return await _repository.FindByName(name);
        }
    }
}
