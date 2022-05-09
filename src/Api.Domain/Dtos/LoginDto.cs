using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é obrigatório para Login")]
        [EmailAddress(ErrorMessage = "Email em Formato Inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caractere")]
        public string Email { get; set; }
    }
}
