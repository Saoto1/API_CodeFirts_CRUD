using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CodeFirts_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquiladosYVendidosController : ControllerBase
    {
        // GET: api/<AlquiladosYVendidosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlquiladosYVendidosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlquiladosYVendidosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlquiladosYVendidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlquiladosYVendidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
