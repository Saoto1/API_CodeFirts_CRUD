using DB_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CodeFirts_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquiladosYVendidosController : ControllerBase
    {

        private DBContext _context;

        public AlquiladosYVendidosController(DBContext context)
        {
            _context = context;
        }


        // GET: api/<AlquiladosYVendidosController>
        [HttpGet]
        public IEnumerable<AlquiladosYVendidos> Get()
        {
            return _context.AlquiladosYVendidos.ToList();
        }

        // GET api/<AlquiladosYVendidosController>/5
        [HttpGet("{id}")]
        public IEnumerable<AlquiladosYVendidos> Get(int id)
        {
            var data = _context.AlquiladosYVendidos.Where(x => x.Id.Equals(id)).ToList();
            return data;
        }

        // POST api/<AlquiladosYVendidosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlquiladosYVendidos alquiladosYVendidos)
        {
            try
            {
                _context.AlquiladosYVendidos.Add(alquiladosYVendidos);
                await _context.SaveChangesAsync();
                return Ok(alquiladosYVendidos);
            }
            catch (Exception)
            {

                throw;
                return BadRequest();
            }
          

        }

        // PUT api/<AlquiladosYVendidosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult>  Put (int id, [FromBody] AlquiladosYVendidos alquiladosYVendidos)
        {

            try
            {
                var AlquiladosYV = _context.AlquiladosYVendidos.First(x=> x.Id.Equals(id));
                AlquiladosYV.IdCliente = alquiladosYVendidos.IdCliente;
                AlquiladosYV.IdLibro = alquiladosYVendidos.IdLibro;
                AlquiladosYV.Estado = alquiladosYVendidos.Estado;
                AlquiladosYV.Desde = alquiladosYVendidos.Desde;
                AlquiladosYV.Hasta = alquiladosYVendidos.Hasta;
                _context.SaveChanges();
                return Ok("Modificacion exitosa");

            }
            catch (Exception e)
            {

           
                return BadRequest("Ocurrio un error al modificar el registro "+ e);
                throw;
            }
        }

        // DELETE api/<AlquiladosYVendidosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var alquiladoYVendido = _context.AlquiladosYVendidos.First(s => s.Id.Equals(id));
                _context.Remove(alquiladoYVendido);
                _context.SaveChangesAsync();
                return Ok("Registro eliminado");

            }
            catch (Exception e)
            {
                return BadRequest("Ocurrio un erro " + e);
                throw;
            }
            
        }
    }
}
