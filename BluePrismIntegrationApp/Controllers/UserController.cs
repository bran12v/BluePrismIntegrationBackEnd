using Microsoft.AspNetCore.Mvc;

namespace BluePrismIntegrationApp.Controllers
{
    using BluePrismIntegrationApp;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }
    }
}
