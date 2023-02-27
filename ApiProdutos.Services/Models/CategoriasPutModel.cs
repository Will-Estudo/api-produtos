using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Services.Models
{
    /// <summary>
    /// Modelo de dados para edição de categoria
    /// </summary>
    public class CategoriasPutModel
    {
        [Required(ErrorMessage ="Informe o ID da categoria")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Descricao { get; set; }
    }
}
