using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Controllers
{
    public class CoffeesController : Controller
    {
        private readonly AppzContext _context;

        public CoffeesController(AppzContext context)
        {
            _context = context;    
        }

        // GET: Coffees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coffee.ToListAsync());
        }

        // GET: Coffees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .SingleOrDefaultAsync(m => m.ID == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // GET: Coffees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coffees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Origin,Roast")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: Coffees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee.SingleOrDefaultAsync(m => m.ID == id);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }

        // POST: Coffees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Origin,Roast")] Coffee coffee)
        {
            if (id != coffee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeExists(coffee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: Coffees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .SingleOrDefaultAsync(m => m.ID == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffee = await _context.Coffee.SingleOrDefaultAsync(m => m.ID == id);
            _context.Coffee.Remove(coffee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CoffeeExists(int id)
        {
            return _context.Coffee.Any(e => e.ID == id);
        }
    }
}
