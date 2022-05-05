using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implemention
{
    public class ListImplemention : BaseRepository<ListEntity>, IListRepository
    {
        private DbSet<ListEntity> _dataset;

        public ListImplemention(MyContext context) : base(context)
        {
            _dataset = context.Set<ListEntity>();
        }

        public async Task<IEnumerable<ListEntity>> FindByCategory(Guid id)
        {
            return await _dataset.Where(p => p.categoryId == id).ToListAsync();
        }

        public async Task<IEnumerable<ListEntity>> FindByName(string name)
        {
            return await _dataset.Where(p => p.Name == name).ToListAsync();
        }
    }
}
