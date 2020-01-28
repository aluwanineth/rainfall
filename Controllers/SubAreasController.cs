﻿using System;
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
    public class SubAreasController : ControllerBase
    {
        private readonly WrmfContext _context;

        public SubAreasController(WrmfContext context)
        {
            _context = context;
        }

        // GET: api/SubAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubArea>>> GetSubArea()
        {
            return await _context.SubArea.ToListAsync();
        }

        // GET: api/SubAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubArea>> GetSubArea(int id)
        {
            var subArea = await _context.SubArea.FindAsync(id);

            if (subArea == null)
            {
                return NotFound();
            }

            return subArea;
        }

        // PUT: api/SubAreas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubArea(int id, SubArea subArea)
        {
            if (id != subArea.SubAreaId)
            {
                return BadRequest();
            }

            _context.Entry(subArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubAreaExists(id))
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

        // POST: api/SubAreas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SubArea>> PostSubArea(SubArea subArea)
        {
            _context.SubArea.Add(subArea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubAreaExists(subArea.SubAreaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubArea", new { id = subArea.SubAreaId }, subArea);
        }

        // DELETE: api/SubAreas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubArea>> DeleteSubArea(int id)
        {
            var subArea = await _context.SubArea.FindAsync(id);
            if (subArea == null)
            {
                return NotFound();
            }

            _context.SubArea.Remove(subArea);
            await _context.SaveChangesAsync();

            return subArea;
        }

        private bool SubAreaExists(int id)
        {
            return _context.SubArea.Any(e => e.SubAreaId == id);
        }
    }
}
