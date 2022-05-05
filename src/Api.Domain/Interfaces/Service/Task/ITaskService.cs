using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Service.Task
{
    public interface ITaskService
    {
        Task<TaskEntity> Get(Guid id);

        Task<IEnumerable<TaskEntity>> GetAll();

        Task<TaskEntity> Post(TaskEntity task);

        Task<TaskEntity> Put(TaskEntity task);

        Task<bool> Delete(Guid id);

    }
}
