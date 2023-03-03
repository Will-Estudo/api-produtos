using ApiProdutos.Data.Entities;
using ApiProdutos.Services.Models;
using AutoMapper;

namespace ApiProdutos.Services.Mappings
{
    /// <summary>
    /// Mapeat transferência de dados de Models para Entities
    /// </summary>
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<CategoriasPostModel, Categoria>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<CategoriasPutModel, Categoria>();

            CreateMap<ProdutosPostModel, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.DataHoraCadastro = DateTime.Now;
                }
                );

            CreateMap<ProdutosPutModel, Produto>();
        }
    }
}
