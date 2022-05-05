using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Service.Task;

namespace Api.Service.Service
{
    public class TaskService : ITaskService
    {
        private IRepository<TaskEntity> _repository;

        public TaskService(IRepository<TaskEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<TaskEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<TaskEntity> Post(TaskEntity task)
        {
            return await _repository.InsertAsync(task);
        }

        public async Task<TaskEntity> Put(TaskEntity task)
        {
            return await _repository.UpdateAsync(task);
        }

    }
}
