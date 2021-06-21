using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhereToEat.MVC.Contracts;
using WhereToEat.MVC.Data;
using WhereToEat.MVC.Models.Styles;

namespace WhereToEat.MVC.Controllers
{
    public class StyleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStyleServices _services;

        public StyleController(ApplicationDbContext context, IStyleServices services)
        {
            _context = context;
            _services = services;
        }

        // GET: Style
        public async Task<IActionResult> Index()
        {
            return View(await _services.ListStyles());
        }

        // GET: Style/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var style = await _services.GetStyleById(id);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // GET: Style/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Style/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StyleId,Name")] StyleViewModel newStyle)
        {
            if (!ModelState.IsValid)
            {
                return View(newStyle);
            }

            await _services.CreateStyle(newStyle);
            return RedirectToAction(nameof(Index));
        }

        // GET: Style/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var style = await _services.GetStyleById(id);
            if (style == null)
            {
                return NotFound();
            }
            return View(style);
        }

        // POST: Style/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StyleId,Name")] StyleViewModel updatedStyle)
        {
            if (id != updatedStyle.StyleId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(updatedStyle);
            }

            if (await _services.UpdateStyle(updatedStyle) == false)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Style/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var style = await _services.GetStyleById(id);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // POST: Style/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _services.DeleteStyle(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StyleExists(Guid id)
        {
            return _context.Styles.Any(e => e.StyleId == id);
        }
    }
}
