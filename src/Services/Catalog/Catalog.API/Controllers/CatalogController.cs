using Catalog.API.Entities;
using Catalog.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(IProductService productService, ILogger<CatalogController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        // GET: api/<CatalogController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var result = await _productService.GetProducts();
            _logger.LogInformation("get Product");
            return Ok(result);
        }

        // GET api/<CatalogController>/5
        [HttpGet]
        [Route("[action]/{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var result = await _productService.GetProductById(id);
            if (result == null)
            {
                _logger.LogError($"not found id={id} ");
                return NotFound();
            }
            return Ok(result);
        }

        [Route("[action]/{category}", Name = "GetProductsByCategory")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductsByCategory(string category)
        {
            var result = await _productService.GetProductsByCategory(category);
            if (result == null)
            {
                _logger.LogError($"not found category ={category} ");
                return NotFound();
            }
            return Ok(result);
        }


        [Route("[action]", Name = "CreateProduct")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _productService.CreateProduct(product);
            _logger.LogInformation($"  create ", product);
            return CreatedAtRoute("GetProduct", new { Id = product.Id }, product);
        }

        [Route("[action]", Name = "UpdateProduct")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotModified)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _productService.UpdateProduct(product));
        }

        [Route("[action]/{id:length(24)}", Name = "DeleteProduct")]
        [HttpDelete] 
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            return Ok(await _productService.DeleteProductById(id));
        }

    }
}
