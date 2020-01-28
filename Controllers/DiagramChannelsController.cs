using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RainFall.WebApi.Models;

namespace RainFall.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagramChannelsController : ControllerBase
    {
        private readonly WrmfContext _context;

        public DiagramChannelsController(WrmfContext context)
        {
            _context = context;
        }

        // GET: api/DiagramChannels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagramChannel>>> GetDiagramChannel()
        {
            return await _context.DiagramChannel.ToListAsync();
        }

        // GET: api/DiagramChannels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiagramChannel>> GetDiagramChannel(int id)
        {
            var diagramChannel = await _context.DiagramChannel.FindAsync(id);

            if (diagramChannel == null)
            {
                return NotFound();
            }

            return diagramChannel;
        }

        // PUT: api/DiagramChannels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagramChannel(int id, DiagramChannel diagramChannel)
        {
            if (id != diagramChannel.DiagramMemberId)
            {
                return BadRequest();
            }

            _context.Entry(diagramChannel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagramChannelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DiagramChannels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DiagramChannel>> PostDiagramChannel(DiagramChannel diagramChannel)
        {
            _context.DiagramChannel.Add(diagramChannel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiagramChannelExists(diagramChannel.DiagramMemberId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiagramChannel", new { id = diagramChannel.DiagramMemberId }, diagramChannel);
        }

        // DELETE: api/DiagramChannels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiagramChannel>> DeleteDiagramChannel(int id)
        {
            var diagramChannel = await _context.DiagramChannel.FindAsync(id);
            if (diagramChannel == null)
            {
                return NotFound();
            }

            _context.DiagramChannel.Remove(diagramChannel);
            await _context.SaveChangesAsync();

            return diagramChannel;
        }

        private bool DiagramChannelExists(int id)
        {
            return _context.DiagramChannel.Any(e => e.DiagramMemberId == id);
        }
    }
}
