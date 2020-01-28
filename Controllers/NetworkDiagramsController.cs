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
    public class NetworkDiagramsController : ControllerBase
    {
        private readonly WrmfContext _context;

        public NetworkDiagramsController(WrmfContext context)
        {
            _context = context;
        }

        // GET: api/NetworkDiagrams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NetworkDiagram>>> GetNetworkDiagram()
        {
            return await _context.NetworkDiagram.ToListAsync();
        }

        // GET: api/NetworkDiagrams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NetworkDiagram>> GetNetworkDiagram(int id)
        {
            var networkDiagram = await _context.NetworkDiagram.FindAsync(id);

            if (networkDiagram == null)
            {
                return NotFound();
            }

            return networkDiagram;
        }

        // PUT: api/NetworkDiagrams/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNetworkDiagram(int id, NetworkDiagram networkDiagram)
        {
            if (id != networkDiagram.DiagramId)
            {
                return BadRequest();
            }

            _context.Entry(networkDiagram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetworkDiagramExists(id))
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

        // POST: api/NetworkDiagrams
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NetworkDiagram>> PostNetworkDiagram(NetworkDiagram networkDiagram)
        {
            _context.NetworkDiagram.Add(networkDiagram);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NetworkDiagramExists(networkDiagram.DiagramId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNetworkDiagram", new { id = networkDiagram.DiagramId }, networkDiagram);
        }

        // DELETE: api/NetworkDiagrams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NetworkDiagram>> DeleteNetworkDiagram(int id)
        {
            var networkDiagram = await _context.NetworkDiagram.FindAsync(id);
            if (networkDiagram == null)
            {
                return NotFound();
            }

            _context.NetworkDiagram.Remove(networkDiagram);
            await _context.SaveChangesAsync();

            return networkDiagram;
        }

        private bool NetworkDiagramExists(int id)
        {
            return _context.NetworkDiagram.Any(e => e.DiagramId == id);
        }
    }
}
