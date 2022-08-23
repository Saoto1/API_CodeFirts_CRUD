using API_CodeFirts_CRUD.Helpers;
using DB_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CodeFirts_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private DBContext _context;

        public ClientesController( DBContext context)
        {
            _context = context;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                var data = _context.Clientes.ToList();
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = true,
                    Message = $"Transaccion exitosa",
                    Data = data

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = false,
                    Message = $"Ocurrio un error{e}",
                    Data = null

                });
                throw;
            }
        
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            try
            {
                var ReturID = from n in _context.Clientes where n.Id.Equals(id) select n;
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = true,
                    Message = $"Transaccion exitosa",
                    Data = ReturID.ToList()

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = false,
                    Message = $"Ocurrio un error{e}",
                    Data = null

                });
                throw;
            }
           
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Clientes cliente )
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = true,
                    Message = $"Transaccion exitosa",
                    Data = null

                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = false,
                    Message = $"Ocurrio un error{e}",
                    Data = null

                });
                throw;

            }

            

        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody] Clientes cliente)
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

                return Json(new GenericResponse<List<Clientes>>
                {
                    State = true,
                    Message = $"Transaccion exitosa",
                    Data = null

                });

            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = false,
                    Message = $"Ocurrio un error{e}",
                    Data = null

                });
                throw;
            }

        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task <JsonResult> Delete(int id)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(s => s.Id == id);
                _context.Remove(cliente);
                _context.SaveChanges();

                return Json(new GenericResponse<List<Clientes>>
                {
                    State = true,
                    Message = $"Transaccion exitosa",
                    Data = null
                });
            }
            catch (Exception e)
            {
                return Json(new GenericResponse<List<Clientes>>
                {
                    State = false,
                    Message = $"Ocurrio un error{e}",
                    Data = null

                });
                throw;
            }
           


        }
    }
}
