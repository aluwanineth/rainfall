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
    public class ChannelsController : ControllerBase
    {
        private readonly WrmfContext _context;

        public ChannelsController(WrmfContext context)
        {
            _context = context;
        }

        // GET: api/Channels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Channel>>> GetChannel()
        {
            return await _context.Channel.ToListAsync();
        }

        // GET: api/Channels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Channel>> GetChannel(int id)
        {
            var channel = await _context.Channel.FindAsync(id);

            if (channel == null)
            {
                return NotFound();
            }

            return channel;
        }

        // PUT: api/Channels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChannel(int id, Channel channel)
        {
            if (id != channel.ChannelId)
            {
                return BadRequest();
            }

            _context.Entry(channel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChannelExists(id))
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

        // POST: api/Channels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Channel>> PostChannel(Channel channel)
        {
            _context.Channel.Add(channel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChannelExists(channel.ChannelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChannel", new { id = channel.ChannelId }, channel);
        }

        // DELETE: api/Channels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Channel>> DeleteChannel(int id)
        {
            var channel = await _context.Channel.FindAsync(id);
            if (channel == null)
            {
                return NotFound();
            }

            _context.Channel.Remove(channel);
            await _context.SaveChangesAsync();

            return channel;
        }

        private bool ChannelExists(int id)
        {
            return _context.Channel.Any(e => e.ChannelId == id);
        }
    }
}
