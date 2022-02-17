#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class PassedAlumniController : Controller
    {
        private readonly MvcMovieContext _context;

        public PassedAlumniController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: PassedAlumni
        //public async Task<IActionResult> Index(string searchString)
        //{
          //  var deceased = from m in _context.Movie
           //              select m;

          //  if (!String.IsNullOrEmpty(searchString))
          //  {
           //     deceased = deceased.Where(s => s.FirstName!.Contains(searchString));
          //  }

        //    return View(await deceased.ToListAsync());
        //}


        public async Task<IActionResult> Index(string AttendedClassResults, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.TheClassAttended
                                            select m.TheClassAttended;
            var deceased = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                deceased = deceased.Where(s => s.FirstName!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(AttendedClassResults))
            {
                deceased = deceased.Where(x => x.TheClassAttended == AttendedClassResults);
            }

            var AttendedClassResultsVM = new AttendedClassResultsViewModel
            {
                AttendedClass = new SelectList(await genreQuery.Distinct().ToListAsync()),
                PassedAlumni = await deceased.ToListAsync()
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

            var movie = await _context.Movie
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
        public async Task<IActionResult> Create([Bind("Id,FirstName,PassingDate,TheClassAttended,Price,LastName")] Movie movie)
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

            var movie = await _context.Movie.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,PassingDate,TheClassAttended,Price,LastName")] Movie movie)
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
                    if (!MovieExists(movie.Id))
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

            var movie = await _context.Movie
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
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
