using DB_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CodeFirts_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DBContext _context;

        public ValuesController( DBContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Clientes> Get()
        {
          return  _context.Clientes.ToList();           
        }   

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<Clientes> Get(int id)
        {
            var ReturID = from n in _context.Clientes where n.Id.Equals(id) select n;
            return ReturID.ToList();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Clientes cliente )
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                
            }

            

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Clientes cliente)
        {
            try
            {
                var clientes = _context.Clientes.FirstOrDefault(s=> s.Id == id);
                clientes.Nombre = cliente.Nombre;
                clientes.Apellido = cliente.Apellido;
                clientes.DUI = cliente.DUI;
                clientes.NumeroTel = cliente.NumeroTel;
                _context.Update(clientes);
                _context.SaveChanges();



            }
            catch (Exception)
            {

                throw;
            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
