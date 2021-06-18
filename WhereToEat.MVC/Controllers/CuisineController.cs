using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhereToEat.MVC.Contracts;
using WhereToEat.MVC.Data;
using WhereToEat.MVC.Models.Cuisines;

namespace WhereToEat.MVC.Controllers
{
    public class CuisineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICuisineServices _services;

        public CuisineController(ApplicationDbContext context, ICuisineServices services)
        {
            _context = context;
            _services = services;
        }

        // GET: Cuisine
        public async Task<IActionResult> Index()
        {
            var cuisines = await _services.ListCuisines();
            return View(cuisines);
        }

        // GET: Cuisine/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var cuisine = await _services.GetCuisineById(id);
            if (cuisine == null)
            {
                return NotFound();
            }

            return View(cuisine);
        }

        // GET: Cuisine/Create
        public IActionResult Create()
        {
            return View();
        }

        public PartialViewResult CreatePartial()
        {
            return PartialView("_CreatePartial");
        }

        // POST: Cuisine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CuisineId,Name")] CuisineViewModel cuisine)
        {
            if (!ModelState.IsValid)
            {
                return View(cuisine);
            }
            
            await _services.CreateCuisine(cuisine);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Cuisine/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var cuisine = await _services.GetCuisineById(id);
            if (cuisine == null)
            {
                return NotFound();
            }
            return View(cuisine);
        }

        // POST: Cuisine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CuisineId,Name")] CuisineViewModel newCuisine)
        {
            if (id != newCuisine.CuisineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuisine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuisineExists(cuisine.CuisineId))
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
            return View(cuisine);
        }

        // GET: Cuisine/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var cuisine = await _services.GetCuisineById(id);
            if (cuisine == null)
            {
                return NotFound();
            }

            return View(cuisine);
        }

        // POST: Cuisine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cuisine = await _context.Cuisines.FindAsync(id);
            _context.Cuisines.Remove(cuisine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
