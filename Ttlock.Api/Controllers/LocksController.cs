using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ttlock.Api.Data;
using Ttlock.Api.Models;

namespace Ttlock.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LocksController : ControllerBase
    {
        private readonly AppDbContext db;

        public LocksController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmartLock>>> GetLocks()
        {
            return await db.SmartLocks.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<SmartLock>> Create([FromBody] CreateLockRequest request)
        {
            var entity = new SmartLock { Name = request.Name, TtlockId = request.TtlockId };
            db.SmartLocks.Add(entity);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SmartLock>> GetById([FromRoute] Guid id)
        {
            var entity = await db.SmartLocks.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var entity = await db.SmartLocks.FindAsync(id);
            if (entity == null) return NotFound();
            db.SmartLocks.Remove(entity);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }

    public record CreateLockRequest(string Name, string TtlockId);
}