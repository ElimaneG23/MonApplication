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
    public class HistoryController : ControllerBase
    {
        private readonly AppDbContext db;

        public HistoryController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("{lockId:guid}")]
        public async Task<ActionResult<IEnumerable<AccessLog>>> Get([FromRoute] Guid lockId)
        {
            var data = await db.AccessLogs
                .Where(l => l.SmartLockId == lockId)
                .OrderByDescending(l => l.TimestampUtc)
                .AsNoTracking()
                .ToListAsync();
            return data;
        }
    }
}