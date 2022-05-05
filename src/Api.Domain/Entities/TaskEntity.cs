using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public int listId { get; set; }
        public string Name { get; set; }
        public bool Finished { get; set; }
        public int userId { get; set; }
    }
}
