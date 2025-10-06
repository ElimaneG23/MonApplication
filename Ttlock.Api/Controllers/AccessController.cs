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
    public class AccessController : ControllerBase
    {
        private readonly AppDbContext db;

        public AccessController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpPost("grant")]
        public async Task<IActionResult> Grant([FromBody] GrantRequest request)
        {
            var grant = new AccessGrant
            {
                SmartLockId = request.SmartLockId,
                UserId = request.UserId,
                StartsAtUtc = request.StartsAtUtc,
                EndsAtUtc = request.EndsAtUtc,
                IsPermanent = request.IsPermanent
            };
            db.AccessGrants.Add(grant);
            await db.SaveChangesAsync();
            return Ok(grant);
        }

        [HttpGet("{lockId:guid}")]
        public async Task<ActionResult<IEnumerable<AccessGrant>>> List([FromRoute] Guid lockId)
        {
            var data = await db.AccessGrants.Where(g => g.SmartLockId == lockId)
                .AsNoTracking().ToListAsync();
            return data;
        }
    }

    public record GrantRequest(Guid SmartLockId, string UserId, DateTime? StartsAtUtc, DateTime? EndsAtUtc, bool IsPermanent);
}