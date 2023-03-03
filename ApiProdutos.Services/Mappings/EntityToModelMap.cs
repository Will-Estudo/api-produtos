using ApiProdutos.Data.Entities;
using ApiProdutos.Services.Models;
using AutoMapper;

namespace ApiProdutos.Services.Mappings
{
    /// <summary>
    /// Mapeat transferência de dados de Entities para Models
    /// </summary>
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Categoria,CategoriasGetModel>();

            CreateMap<Produto, ProdutosGetModel>();
        }
    }
}
