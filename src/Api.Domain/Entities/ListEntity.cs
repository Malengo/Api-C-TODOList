using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class ListEntity : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("categoryId")]
        public Guid categoryId { get; set; }
        public bool Finished { get; set; }
    }
}
