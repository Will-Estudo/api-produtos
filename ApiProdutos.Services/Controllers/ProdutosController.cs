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
    public class ProdutosController : ControllerBase
    {
        #region AutoMapper
        // atributo AutoMapper
        private readonly IMapper _mapper;

        // Construtor para inicializar o atributo do mapper
        public ProdutosController(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        /// <summary>
        /// Serviço para cadastro de categoria na API
        /// </summary>        
        [HttpPost]
        public IActionResult Post(ProdutosPostModel model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Add(produto);

                // HTTP 201 Created
                return StatusCode(201, new
                {
                    mensagem = "Produto cadastrado com sucesso.",
                    produto = _mapper.Map<ProdutosGetModel>(produtoRepository.GetById(produto.Id.Value))
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao cadastrar produto: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para edição de produto na API
        /// </summary>        
        [HttpPut]
        public IActionResult Put(ProdutosPutModel model)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var registro = produtoRepository.GetById(model.Id.Value);

                if (registro == null)
                    return StatusCode(404, new { mensagem = "Produto não encontrado." });

                var produto = _mapper.Map<Produto>(model);
                produto.DataHoraCadastro = registro.DataHoraCadastro;
                produtoRepository.Update(produto);

                // HTTP 200 OK
                return StatusCode(201, new
                {
                    mensagem = "Produto atualizado com sucesso.",
                    produto = _mapper.Map<ProdutosGetModel>(produtoRepository.GetById(produto.Id.Value))
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao editar produto: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para exclusão de produto na API
        /// </summary>        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(id.Value);

                if (produto == null)
                    return StatusCode(404, new { mensagem = "Produto não encontrado." });

                
                produtoRepository.Delete(produto);

                // HTTP 200 OK
                return StatusCode(200, new
                {
                    mensagem = "Produto excluído com sucesso.",
                    produto = _mapper.Map<ProdutosGetModel>(produto)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao excluir produto: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para consultar todos os produtos na API
        /// </summary>        
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.GetAll();

                return StatusCode(200, _mapper.Map<List<ProdutosGetModel>>(produtos));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao consultar produtos: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para consultar um produto na API
        /// </summary>        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(id.Value);

                if (produto == null)
                    return StatusCode(404, new { mensagem = "Produto não encontrado." });
                else
                    return StatusCode(200, _mapper.Map<ProdutosGetModel>(produto));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao obter produto: " + e.Message });
            }
        }
    }
}
