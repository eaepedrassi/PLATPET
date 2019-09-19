using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatPetWebApplicationAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatPetWebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatPetUsuarioController : ControllerBase
    {
        private readonly PlatPetContext _context;

        public PlatPetUsuarioController(PlatPetContext context)
        {
            _context = context;

            if (_context.PlatPetUsuarios.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.PlatPetUsuarios.Add(new PlatPetUsuario { UserUsuario = "Admin" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatPetUsuario>>> GetPlatPetUsuarios()
        {
            return await _context.PlatPetUsuarios.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{IdUsuario}")]
        public async Task<ActionResult<PlatPetUsuario>> GetPlatPetUsuario(int IdUsuario)
        {
            var PlatPetUsuario = await _context.PlatPetUsuarios.FindAsync(IdUsuario);

            if (PlatPetUsuario == null)
            {
                return NotFound();
            }

            return PlatPetUsuario;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<PlatPetUsuario>> PostTodoItem(PlatPetUsuario user)
        {
            _context.PlatPetUsuarios.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlatPetUsuario), new { IdUsuario = user.IdUsuario }, user);
        }

        // PUT: api/Todo/5
        [HttpPut("{IdUsuario}")]
        public async Task<IActionResult> PutPlatPetUsuario(long IdUsuario, PlatPetUsuario user)
        {
            if (IdUsuario != user.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> DeletePlatPetUsuario(int IdUsuario)
        {
            var PlatPetUsuario = await _context.PlatPetUsuarios.FindAsync(IdUsuario);

            if (PlatPetUsuario == null)
            {
                return NotFound();
            }

            _context.PlatPetUsuarios.Remove(PlatPetUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
