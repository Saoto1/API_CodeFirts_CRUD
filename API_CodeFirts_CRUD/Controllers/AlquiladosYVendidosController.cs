using API_CodeFirts_CRUD.Helpers;
using DB_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CodeFirts_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquiladosYVendidosController : Controller
    {

        private DBContext _context;

        public AlquiladosYVendidosController(DBContext context)
        {
            _context = context;
        }


        // GET: api/<AlquiladosYVendidosController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                var data = _context.AlquiladosYVendidos.ToList();
                return Json(new GenericResponse<List<AlquiladosYVendidos>>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = data

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<AlquiladosYVendidos>>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
                throw;
            }
           
        }

        // GET api/<AlquiladosYVendidosController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            try
            {
                var data = _context.AlquiladosYVendidos.Where(x => x.Id.Equals(id)).ToList();
                return Json(new GenericResponse<List<AlquiladosYVendidos>>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = data

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<AlquiladosYVendidos>>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
                throw;
            }
           
        }

        // POST api/<AlquiladosYVendidosController>
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] AlquiladosYVendidos alquiladosYVendidos)
        {
            try
            {
                _context.AlquiladosYVendidos.Add(alquiladosYVendidos);
                await _context.SaveChangesAsync();
                return Json(new GenericResponse<AlquiladosYVendidos>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = null

                });

            }
            catch (Exception e)
            {

   
                return Json(new GenericResponse<AlquiladosYVendidos>
                {
                    State = false,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
                throw;
            }


        }

        // PUT api/<AlquiladosYVendidosController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult>  Put (int id, [FromBody] AlquiladosYVendidos alquiladosYVendidos)
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
                return Json(new GenericResponse<AlquiladosYVendidos>
                {
                    State = true,
                    Message = $"Transaccion exitosa",
                    Data = null

                });

            }
            catch (Exception e)
            {


                return Json(new GenericResponse<AlquiladosYVendidos>
                {
                    State = true,
                    Message = $"Ocurrio un error {e}",
                    Data = null

                });
                throw;
            }
        }

        // DELETE api/<AlquiladosYVendidosController>/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var alquiladoYVendido = _context.AlquiladosYVendidos.First(s => s.Id.Equals(id));
                _context.Remove(alquiladoYVendido);
                _context.SaveChangesAsync();
                return Json(new GenericResponse<AlquiladosYVendidos>
                {
                    State = true,
                    Message = "Transaccione exitosa",
                    Data = null

                });

            }
            catch (Exception e)
            {

                return Json(new
                   GenericResponse<List<AlquiladosYVendidos>>
                {
                    State = false,
                    Message = $"Ocurrio un error: {e}",
                    Data = null
                });
                throw;
            }
            
        }
    }
}
