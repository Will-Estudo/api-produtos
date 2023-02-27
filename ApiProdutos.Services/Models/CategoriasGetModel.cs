using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Services.Models
{
    /// <summary>
    /// Modelo de dados para consulta de categoria
    /// </summary>
    public class CategoriasGetModel
    {        
        public Guid Id { get; set; }
                
        public string? Nome { get; set; }
                
        public string? Descricao { get; set; }
    }
}
