namespace ApiProdutos.Services.Models
{
    /// <summary>
    /// Modelo de dados para consulta de produto
    /// </summary>
    public class ProdutosGetModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

        public CategoriasGetModel? Categoria { get; set; }
    }
}
