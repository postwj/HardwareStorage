using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HardwareStorage.Models;

namespace HardwareStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareItemsController : ControllerBase
    {
        private readonly HardWareStorageContext _context;

        public HardwareItemsController(HardWareStorageContext context)
        {
            _context = context;
        }

        // GET: api/HardwareItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardwareItem>>> GetItems()
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            return await _context.Items.ToListAsync();
        }

        // GET: api/HardwareItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HardwareItem>> GetHardwareItem(int id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var hardwareItem = await _context.Items.FindAsync(id);

            if (hardwareItem == null)
            {
                return NotFound();
            }

            return hardwareItem;
        }

        // PUT: api/HardwareItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHardwareItem(int id, HardwareItem hardwareItem)
        {
            if (id != hardwareItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(hardwareItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HardwareItemExists(id))
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

        // POST: api/HardwareItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HardwareItem>> PostHardwareItem(HardwareItem hardwareItem)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set 'HardWareStorageContext.Items'  is null.");
          }
            _context.Items.Add(hardwareItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHardwareItem), new { id = hardwareItem.Id }, hardwareItem);
        }

        // DELETE: api/HardwareItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHardwareItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var hardwareItem = await _context.Items.FindAsync(id);
            if (hardwareItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(hardwareItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HardwareItemExists(int id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
