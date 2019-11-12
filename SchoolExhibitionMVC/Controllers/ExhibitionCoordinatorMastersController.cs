using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolExhibitionMVC.Data;
using SchoolExhibitionMVC.Models;

namespace SchoolExhibitionMVC.Controllers
{
    [Authorize]
    public class ExhibitionCoordinatorMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExhibitionCoordinatorMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExhibitionCoordinatorMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExhibitionCoordinatorMasters.ToListAsync());
        }

        // GET: ExhibitionCoordinatorMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionCoordinatorMaster = await _context.ExhibitionCoordinatorMasters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (exhibitionCoordinatorMaster == null)
            {
                return NotFound();
            }

            return View(exhibitionCoordinatorMaster);
        }

        // GET: ExhibitionCoordinatorMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExhibitionCoordinatorMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ExhibitionCoordinatorMaster exhibitionCoordinatorMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibitionCoordinatorMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exhibitionCoordinatorMaster);
        }

        // GET: ExhibitionCoordinatorMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionCoordinatorMaster = await _context.ExhibitionCoordinatorMasters.SingleOrDefaultAsync(m => m.ID == id);
            if (exhibitionCoordinatorMaster == null)
            {
                return NotFound();
            }
            return View(exhibitionCoordinatorMaster);
        }

        // POST: ExhibitionCoordinatorMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] ExhibitionCoordinatorMaster exhibitionCoordinatorMaster)
        {
            if (id != exhibitionCoordinatorMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibitionCoordinatorMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionCoordinatorMasterExists(exhibitionCoordinatorMaster.ID))
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
            return View(exhibitionCoordinatorMaster);
        }

        // GET: ExhibitionCoordinatorMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionCoordinatorMaster = await _context.ExhibitionCoordinatorMasters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (exhibitionCoordinatorMaster == null)
            {
                return NotFound();
            }

            return View(exhibitionCoordinatorMaster);
        }

        // POST: ExhibitionCoordinatorMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibitionCoordinatorMaster = await _context.ExhibitionCoordinatorMasters.SingleOrDefaultAsync(m => m.ID == id);
            _context.ExhibitionCoordinatorMasters.Remove(exhibitionCoordinatorMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitionCoordinatorMasterExists(int id)
        {
            return _context.ExhibitionCoordinatorMasters.Any(e => e.ID == id);
        }
    }
}
