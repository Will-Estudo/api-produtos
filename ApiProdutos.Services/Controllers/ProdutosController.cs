using ApiProdutos.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        /// <summary>
        /// Serviço para cadastro de categoria na API
        /// </summary>        
        [HttpPost]
        public IActionResult Post(ProdutosPostModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para edição de produto na API
        /// </summary>        
        [HttpPut]
        public IActionResult Put(ProdutosPutModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para exclusão de produto na API
        /// </summary>        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para consultar todos os produtos na API
        /// </summary>        
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para consultar um produto na API
        /// </summary>        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            return Ok();
        }
    }
}
