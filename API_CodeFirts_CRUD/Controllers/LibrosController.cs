using API_CodeFirts_CRUD.Helpers;
using DB_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CodeFirts_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private DBContext _context;

        public LibrosController(DBContext context)
        {
            _context = context;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
           
            try
            {
                var data = _context.Libros.ToList();
                return Json(new GenericResponse<List<Libros>>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = data

                });

            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Libros>>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
                throw;
            }
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            try
            {
                var libro = (from n in _context.Libros where n.Id.Equals(id) select n).ToList();
                return Json(new GenericResponse<List<Libros>>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = libro

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Libros>>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
                throw;
            }
         
        }

        // POST api/<LibrosController>
        [HttpPost]
        public async Task <JsonResult> Post([FromBody] Libros libro)
        {
            try
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return Json(new GenericResponse<List<Libros>>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = null

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Libros>>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });

            }

        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody] Libros libro)
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

                return Json(new GenericResponse<List<Libros>>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = null

                });
            }
            catch (Exception e)
            {

                return Json(new GenericResponse<List<Libros>>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
            }
        }



        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                var cliente = _context.Clientes.FirstOrDefault(s => s.Id == id);
                _context.Remove(cliente);
                _context.SaveChanges();
                return Json(new GenericResponse<List<Libros>>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = null

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Libros>>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
                throw;
            }
        }
    }
}
