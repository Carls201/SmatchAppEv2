using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmatchAppEv2.Models;
using SmatchAppEv2.Response;

namespace SmatchAppEv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : Controller
    {
        
        private readonly SmatchAppEv2DbContext db = new();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Resp r = new();
            try
            {
                var lugares = await db.Lugars.Select(a => new
                {
                    id = a.IdLugar,
                    nombre = a.NombreLugar,
                    direccion = a.Direccion,
                    descripcion = a.Descripcion
                }).ToListAsync();

                if(lugares.Any())
                {
                    r.Data = lugares;
                    r.Success = true;
                    r.Message = "Los datos se cargaron exitosamente";
                    return Ok(r);
                }
                r.Message = "No se encontraron datos";
                r.Success = true;
                return Ok(r);

            }catch (Exception ex)
            {
                r.Message = ex.Message;
                return BadRequest(r);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Lugar>> PostLugar(Lugar lugar)
        {
            Resp r = new();
            if(lugar.NombreLugar == "" || lugar.Direccion == "" || lugar.Descripcion == "")
            {
                r.Message = "Primero tiene que completar los campos vacios";
                return BadRequest(r);
            }
            db.Lugars.Add(lugar);
            await db.SaveChangesAsync();
            r.Message = "Lugar guardado";
            r.Success= true;
            r.Data = lugar.IdLugar;
            return CreatedAtAction("Get", r, lugar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLugar(int id)
        {
            Resp r = new();
            var lugar = await db.Lugars.FindAsync(id);
            if(lugar == null)
            {
                r.Message = "El Lugar que desea eliminar no se encuentra";
                return BadRequest(r);
            }
            db.Lugars.Remove(lugar);
            await db.SaveChangesAsync();    
            r.Success = true;
            r.Message = "Lugar eliminado";
            return Ok(r);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLugar(int id, Lugar lugar)
        {
            Resp r = new();
            var l = await db.Lugars.Select(l => new
            {
                id = l.IdLugar,
                nombre = l.NombreLugar,
                direccion = l.Direccion,
                descripcion = l.Descripcion
            }).FirstOrDefaultAsync(x => x.id == id);

            if (l == null)
            {
                r.Message = "El lugar que desea modificar no e encuentra";
                return BadRequest(r);
            }
            if (id != lugar.IdLugar)
            {
                r.Message = "El id que ingreso no coincide con el ud del lugar que desea modificar";
                return BadRequest(r);
            }
            db.Lugars.Update(lugar);
            await db.SaveChangesAsync();
            return Ok("Lugar editado con exito");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLugar(int id)
        {
            Resp r = new();
            var lugar = await db.Lugars.Select(l => new
            {
                id = l.IdLugar,
                nombre = l.NombreLugar,
                direccion = l.Direccion,
                descripcion = l.Descripcion
            }).FirstOrDefaultAsync(x => x.id == id);

            if(lugar == null)
            {
                r.Message = $"No se encuentra el lugar de id :{id}";
                return NotFound(r);
            }
            r.Success = true;
            r.Data = lugar;
            return Ok(r);
        }
    }
}
