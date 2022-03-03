#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWHSAlumni.Data;
using MvcWHSAlumni.Models;
using PagedList;

namespace MvcWHSAlumni.Controllers
{
    public class PassedAlumniController : Controller
    {
        private readonly MvcWHSAlumniContext _context;

        public PassedAlumniController(MvcWHSAlumniContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string AttendedClassResults, string searchString, string HighSchoolResults, string MaidenName, string LastName)
        {


           // LINQ to get list of classes by year.
            IQueryable<string> alumniQuery = from m in _context.tWHSAlumni
                                             orderby m.TheClassAttended
                                             select m.TheClassAttended;

            IQueryable<string> alumniQuery2 = from m in _context.tWHSAlumni
                                             orderby m.HighSchool
                                             select m.HighSchool;


            var deceased = from m in _context.tWHSAlumni
                           select m;

            var deceased2 = from m in _context.tWHSAlumni
                           select m;


            if (!string.IsNullOrEmpty(searchString))
            {
                deceased = deceased.Where(s => s.FirstName!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(LastName))
            {
                deceased = deceased.Where(t => t.LastName!.Contains(LastName));
            }

            if (!string.IsNullOrEmpty(MaidenName))
            {
                deceased = deceased.Where(t => t.MaidenName!.Contains(MaidenName));
            }

            if (!string.IsNullOrEmpty(AttendedClassResults))
            {
                deceased = deceased.Where(x => x.TheClassAttended == AttendedClassResults);
            }

            if (!string.IsNullOrEmpty(HighSchoolResults))
            {
                deceased = deceased.Where(x => x.HighSchool == HighSchoolResults);
            }

            var AttendedClassResultsVM = new AttendedClassResultsViewModel
            {
                AttendedClass = new SelectList(await alumniQuery.Distinct().ToListAsync()),

                HighSchoolClass = new SelectList(await alumniQuery2.Distinct().ToListAsync()),

                PassedAlumni = await deceased.ToListAsync(),
              
            };

            return View(AttendedClassResultsVM);
        }


        // GET: PassedAlumni/Details/5
        public async Task<IActionResult> Details(int? id)
     
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tWHSAlumni

            .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);


        }

        // GET: PassedAlumni/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PassedAlumni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,PassingDate,TheClassAttended,Price,LastName,MaidenName,HighSchool")] tWHSAlumni movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: PassedAlumni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tWHSAlumni.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: PassedAlumni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,PassingDate,TheClassAttended,Price,LastName,MaidenName,HighSchool")] tWHSAlumni movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tWHSAlumniExists(movie.Id))
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
            return View(movie);
        }

        // GET: PassedAlumni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tWHSAlumni
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: PassedAlumni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.tWHSAlumni.FindAsync(id);
            _context.tWHSAlumni.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tWHSAlumniExists(int id)
        {
            return _context.tWHSAlumni.Any(e => e.Id == id);
        }
    }
}
