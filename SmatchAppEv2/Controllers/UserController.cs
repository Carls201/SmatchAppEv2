using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmatchAppEv2.Models;
using SmatchAppEv2.Response;

namespace SmatchAppEv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // CREAR BD
        private readonly SmatchAppEv2DbContext db = new();

        // READ ALL.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Resp r = new();
            try
            {
                //TRAER TODA LA INFORMACION
                var users = await db.Usuarios.Select(a => new
                {
                    id = a.IdUsuario,
                    nombre = a.Nombre,
                    fecha_nac = a.FechaNac,
                    altura = a.Altura,
                    peso = a.Peso,
                    sexo = a.Sexo,
                    correo = a.Correo
                }).ToListAsync();
                if (users.Any())
                {
                    r.Data = users;
                    r.Success = true;
                    r.Message = "Los datos se han mostrado con éxito";
                    return Ok(r);
                }
                r.Message = "No existen registros";
                r.Success = true;
                return Ok(r);
            }
            catch (Exception ex)
            {
                r.Message = ex.Message;
                return BadRequest(r);
            }
        }

        // CREATE.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario u)
        {
            Resp r = new();
            if(u.Nombre == null || u.Nombre == "")
            {
                r.Message = "Los campos no pueden quedar vacio";
                return BadRequest(r);
            }
            db.Usuarios.Add(u);
            await db.SaveChangesAsync();
            r.Message = "Se ha guardado con éxito";
            r.Success = true;
            r.Data = u.IdUsuario;
            return CreatedAtAction("Get",r,u);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            Resp r = new();
            var user = await db.Usuarios.FindAsync(id);
            
            if (user == null)
            {
                r.Message = "No existe el usuario";
                return BadRequest(r);
            }

            db.Usuarios.Remove(user);
            await db.SaveChangesAsync();
            r.Success = true;
            r.Message = "El usuario se ha eliminado con éxito";
            return Ok(r);
        }

        // EDITAR
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario user)
        {
            Resp r = new();
            try
            {
                var u = await db.Usuarios.FindAsync(id);
                if (u == null)
                {
                    r.Message = "No existe el usuario";
                    return BadRequest(r);
                }
                else
                {
                    u.IdUsuario = user.IdUsuario;
                    u.Nombre = user.Nombre;
                    u.FechaNac = user.FechaNac;
                    u.Altura = user.Altura;
                    u.Peso = user.Peso;
                    u.Sexo = user.Sexo;
                    u.Correo = user.Correo;
                    u.Pass = user.Pass;

                    db.Usuarios.Update(u);
                    await db.SaveChangesAsync();
                    r.Success = true;
                    r.Message = "Se ha editado correctamente";
                    r.Data = u;
                    return Ok(r);
                }
            }
            catch (Exception ex)
            {
                r.Message = ex.Message;
                return BadRequest(r);
            }          
            
        }
    }
}
