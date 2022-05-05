using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
