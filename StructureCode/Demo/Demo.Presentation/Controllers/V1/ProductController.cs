using Demo.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class ProductController : ApiController
    {

        public ProductController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
