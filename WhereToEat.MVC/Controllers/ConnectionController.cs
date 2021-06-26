using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhereToEat.MVC.Data;

namespace WhereToEat.MVC.Controllers
{
    [Authorize]
    public class ConnectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userId;

        public ConnectionController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        // GET: Connections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Connections.Include(c => c.Receiver).Include(c => c.Sender);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Connections/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connection = await _context.Connections
                .Include(c => c.Receiver)
                .Include(c => c.Sender)
                .FirstOrDefaultAsync(m => m.ConnectionId == id);
            if (connection == null)
            {
                return NotFound();
            }

            return View(connection);
        }

        // GET: Connections/Create
        public IActionResult Create()
        {
            ViewData["ReceiverId"] = new SelectList(_context.ApplicationUsers, "Id", "Email");
            //ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Connections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConnectionId,SenderId,ReceiverId,IsAccepted")] Connection connection)
        {
            if (ModelState.IsValid)
            {
                connection.ConnectionId = Guid.NewGuid();
                connection.Sender = await _context.ApplicationUsers.FindAsync(_userId);
                _context.Add(connection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceiverId"] = new SelectList(_context.ApplicationUsers, "Id", "Email", connection.ReceiverId);
            //ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Email", connection.SenderId);
            return View(connection);
        }

        // GET: Connections/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connection = await _context.Connections.FindAsync(id);
            if (connection == null)
            {
                return NotFound();
            }
            ViewData["ReceiverId"] = new SelectList(_context.ApplicationUsers, "Id", "Email", connection.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Email", connection.SenderId);
            return View(connection);
        }

        // POST: Connections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ConnectionId,SenderId,ReceiverId,IsAccepted")] Connection connection)
        {
            if (id != connection.ConnectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(connection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnectionExists(connection.ConnectionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceiverId"] = new SelectList(_context.ApplicationUsers, "Id", "Email", connection.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Email", connection.SenderId);
            return View(connection);
        }

        // GET: Connections/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connection = await _context.Connections
                .Include(c => c.Receiver)
                .Include(c => c.Sender)
                .FirstOrDefaultAsync(m => m.ConnectionId == id);
            if (connection == null)
            {
                return NotFound();
            }

            return View(connection);
        }

        // POST: Connections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var connection = await _context.Connections.FindAsync(id);
            _context.Connections.Remove(connection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnectionExists(Guid id)
        {
            return _context.Connections.Any(e => e.ConnectionId == id);
        }
    }
}
