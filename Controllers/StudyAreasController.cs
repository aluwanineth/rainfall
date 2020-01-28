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
    public class StudyAreasController : ControllerBase
    {
        private readonly WrmfContext _context;

        public StudyAreasController(WrmfContext context)
        {
            _context = context;
        }

        // GET: api/StudyAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyArea>>> GetStudyArea()
        {
            return await _context.StudyArea.ToListAsync();
        }

        // GET: api/StudyAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyArea>> GetStudyArea(int id)
        {
            var studyArea = await _context.StudyArea.FindAsync(id);

            if (studyArea == null)
            {
                return NotFound();
            }

            return studyArea;
        }

        // PUT: api/StudyAreas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyArea(int id, StudyArea studyArea)
        {
            if (id != studyArea.StudyAreaId)
            {
                return BadRequest();
            }

            _context.Entry(studyArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyAreaExists(id))
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

        // POST: api/StudyAreas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudyArea>> PostStudyArea(StudyArea studyArea)
        {
            _context.StudyArea.Add(studyArea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudyAreaExists(studyArea.StudyAreaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudyArea", new { id = studyArea.StudyAreaId }, studyArea);
        }

        // DELETE: api/StudyAreas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudyArea>> DeleteStudyArea(int id)
        {
            var studyArea = await _context.StudyArea.FindAsync(id);
            if (studyArea == null)
            {
                return NotFound();
            }

            _context.StudyArea.Remove(studyArea);
            await _context.SaveChangesAsync();

            return studyArea;
        }

        private bool StudyAreaExists(int id)
        {
            return _context.StudyArea.Any(e => e.StudyAreaId == id);
        }
    }
}
