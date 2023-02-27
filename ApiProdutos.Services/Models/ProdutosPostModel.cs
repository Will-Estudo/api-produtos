using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Services.Models
{
    /// <summary>
    /// Modelo de dados para cadastro de produto
    /// </summary>
    public class ProdutosPostModel
    {
        [Required(ErrorMessage = "Informe o nome do produto")]
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(500, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o ID da categoria")]
        public Guid? IdCategoria { get; set; }
    }
}
