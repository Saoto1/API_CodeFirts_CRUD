using DB_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CodeFirts_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private DBContext _context;
        // GET: api/<LibrosController>
        [HttpGet]
        public IEnumerable<Libros> Get()
        {
            return _context.Libros.ToList();
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public IEnumerable<Libros> Get(int id)
        {
            var libro = (from n in _context.Libros where n.Id.Equals(id) select n).ToList();
            return libro;
        }

        // POST api/<LibrosController>
        [HttpPost]
        public async Task <ActionResult> Post([FromBody] Libros libro)
        {
            try
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return Ok(libro);
            }
            catch (Exception e)
            {
                return BadRequest();

            }

        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Libros libro)
        {
            try
            {
                var libros = _context.Libros.First(s => s.Id == id);
                libros.Titulo = libro.Titulo;
                libros.Autor = libro.Autor;
                libros.Estado = libro.Estado;
                libros.Otros = libro.Otros;
                libros.FechaPublicacion = libro.FechaPublicacion;
                libros.Precio = libro.Precio;
                libros.Genero = libro.Genero;            
                _context.SaveChanges();
            }
            catch (Exception)
            {

                BadRequest();
            }
        }



        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public ActionResult<Libros> Delete(int id)
        {

            try
            {
                var cliente = _context.Clientes.FirstOrDefault(s => s.Id == id);
                _context.Remove(cliente);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
