using ApiProdutos.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        /// <summary>
        /// Serviço para cadastro de categoria na API
        /// </summary>        
        [HttpPost]
        public IActionResult Post(CategoriasPostModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para edição de categoria na API
        /// </summary>        
        [HttpPut]
        public IActionResult Put(CategoriasPutModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para exclusão de categoria na API
        /// </summary>        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para consultar todas as categorias na API
        /// </summary>        
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriasGetModel>), 200)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para consultar uma categoria na API
        /// </summary>        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            return Ok();
        }
    }
}
