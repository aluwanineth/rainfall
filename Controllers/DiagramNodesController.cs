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
    public class DiagramNodesController : ControllerBase
    {
        private readonly WrmfContext _context;

        public DiagramNodesController(WrmfContext context)
        {
            _context = context;
        }

        // GET: api/DiagramNodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagramNode>>> GetDiagramNode()
        {
            return await _context.DiagramNode.ToListAsync();
        }

        // GET: api/DiagramNodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiagramNode>> GetDiagramNode(int id)
        {
            var diagramNode = await _context.DiagramNode.FindAsync(id);

            if (diagramNode == null)
            {
                return NotFound();
            }

            return diagramNode;
        }

        // PUT: api/DiagramNodes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagramNode(int id, DiagramNode diagramNode)
        {
            if (id != diagramNode.DiagramMemberId)
            {
                return BadRequest();
            }

            _context.Entry(diagramNode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagramNodeExists(id))
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

        // POST: api/DiagramNodes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DiagramNode>> PostDiagramNode(DiagramNode diagramNode)
        {
            _context.DiagramNode.Add(diagramNode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiagramNodeExists(diagramNode.DiagramMemberId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiagramNode", new { id = diagramNode.DiagramMemberId }, diagramNode);
        }

        // DELETE: api/DiagramNodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiagramNode>> DeleteDiagramNode(int id)
        {
            var diagramNode = await _context.DiagramNode.FindAsync(id);
            if (diagramNode == null)
            {
                return NotFound();
            }

            _context.DiagramNode.Remove(diagramNode);
            await _context.SaveChangesAsync();

            return diagramNode;
        }

        private bool DiagramNodeExists(int id)
        {
            return _context.DiagramNode.Any(e => e.DiagramMemberId == id);
        }
    }
}
