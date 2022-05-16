using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class Userdto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = " O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
