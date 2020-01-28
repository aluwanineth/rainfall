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
    public class ScenariosController : ControllerBase
    {
        private readonly WrmfContext _context;

        public ScenariosController(WrmfContext context)
        {
            _context = context;
        }

        // GET: api/Scenarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scenario>>> GetScenario()
        {
            return await _context.Scenario.ToListAsync();
        }

        // GET: api/Scenarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scenario>> GetScenario(int id)
        {
            var scenario = await _context.Scenario.FindAsync(id);

            if (scenario == null)
            {
                return NotFound();
            }

            return scenario;
        }

        // PUT: api/Scenarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScenario(int id, Scenario scenario)
        {
            if (id != scenario.ScenarioId)
            {
                return BadRequest();
            }

            _context.Entry(scenario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioExists(id))
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

        // POST: api/Scenarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Scenario>> PostScenario(Scenario scenario)
        {
            _context.Scenario.Add(scenario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScenarioExists(scenario.ScenarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScenario", new { id = scenario.ScenarioId }, scenario);
        }

        // DELETE: api/Scenarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scenario>> DeleteScenario(int id)
        {
            var scenario = await _context.Scenario.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            _context.Scenario.Remove(scenario);
            await _context.SaveChangesAsync();

            return scenario;
        }

        private bool ScenarioExists(int id)
        {
            return _context.Scenario.Any(e => e.ScenarioId == id);
        }
    }
}
