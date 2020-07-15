using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BPO_API.Data;
using BPO_API.Models;

namespace BPO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public AuthenticationsController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Authentications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authentication>>> GetAuthentication()
        {
            return await _context.Authentication.ToListAsync();
        }

        // GET: api/Authentications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authentication>> GetAuthentication(int id)
        {
            var authentication = await _context.Authentication.FindAsync(id);

            if (authentication == null)
            {
                return NotFound();
            }

            return authentication;
        }

        // PUT: api/Authentications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthentication(int id, Authentication authentication)
        {
            if (id != authentication.Id)
            {
                return BadRequest();
            }

            _context.Entry(authentication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthenticationExists(id))
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

        // POST: api/Authentications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Authentication>> PostAuthentication(Authentication authentication)
        {
            _context.Authentication.Add(authentication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthentication", new { id = authentication.Id }, authentication);
        }

        // DELETE: api/Authentications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Authentication>> DeleteAuthentication(int id)
        {
            var authentication = await _context.Authentication.FindAsync(id);
            if (authentication == null)
            {
                return NotFound();
            }

            _context.Authentication.Remove(authentication);
            await _context.SaveChangesAsync();

            return authentication;
        }

        private bool AuthenticationExists(int id)
        {
            return _context.Authentication.Any(e => e.Id == id);
        }
    }
}
