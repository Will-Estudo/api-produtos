using ApiProdutos.Data.Entities;
using ApiProdutos.Data.Repositories;
using ApiProdutos.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        #region AutoMapper
        // atributo AutoMapper
        private readonly IMapper _mapper;

        // Construtor para inicializar o atributo do mapper
        public CategoriasController(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        /// <summary>
        /// Serviço para cadastro de categoria na API
        /// </summary>        
        [HttpPost]
        public IActionResult Post(CategoriasPostModel model)
        {
            try
            {
                /*var categoria = new Categoria
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Descricao = model.Descricao
                };*/
                var categoria = _mapper.Map<Categoria>(model);

                var categoriaRepository = new CategoriaRepository();
                categoriaRepository.Add(categoria);

                // HTTP 201 Created
                return StatusCode(201, new {
                    mensagem = "Categoria cadastrada com sucesso." ,
                    categoria = _mapper.Map<CategoriasGetModel>(categoria)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao cadastrar categoria: " + e.Message });
            }            
        }

        /// <summary>
        /// Serviço para edição de categoria na API
        /// </summary>        
        [HttpPut]
        public IActionResult Put(CategoriasPutModel model)
        {
            try
            {
                var categoriaRepository = new CategoriaRepository();

                if (categoriaRepository.GetById(model.Id) == null)
                    return StatusCode(404, new {mensagem = "Categoria não encontrada."});

                var categoria = _mapper.Map<Categoria>(model);
                
                categoriaRepository.Update(categoria);

                // HTTP 200 OK
                return StatusCode(200, new
                {
                    mensagem = "Categoria atualizada com sucesso.",
                    categoria = _mapper.Map<CategoriasGetModel>(categoria)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao editar categoria: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para exclusão de categoria na API
        /// </summary>        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                var categoriaRepository = new CategoriaRepository();
                
                var categoria = categoriaRepository.GetById(id.Value);

                if (categoria == null)
                    return StatusCode(404, new { mensagem = "Categoria não encontrada." });

                categoriaRepository.Delete(categoria);

                // HTTP 200 OK
                return StatusCode(200, new
                {
                    mensagem = "Categoria excluída com sucesso.",
                    categoria = _mapper.Map<CategoriasGetModel>(categoria)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao excluir categoria: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para consultar todas as categorias na API
        /// </summary>        
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriasGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var categoriaRepository = new CategoriaRepository();
                var categorias = categoriaRepository.GetAll();

                // HTTP 200 OK
                return StatusCode(200, _mapper.Map<List<CategoriasGetModel>>(categorias));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao consultar categorias: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para consultar uma categoria na API
        /// </summary>        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var categoriaRepository = new CategoriaRepository();
                var categoria = categoriaRepository.GetById(id.Value);

                if (categoria == null)
                    return StatusCode(404, new { mensagem = "Categoria não encontrada." });
                else
                    return StatusCode(200, _mapper.Map<CategoriasGetModel>(categoria));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao obter categoria: " + e.Message });
            }
        }
    }
}
