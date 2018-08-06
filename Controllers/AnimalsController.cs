using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LostandFoundAnimals.Models;
using Microsoft.AspNetCore.Http;

namespace LostandFoundAnimals.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly LostandFoundAnimalsContext _context;

        public AnimalsController(LostandFoundAnimalsContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var lostandFoundAnimalsContext = _context.Animal.Include(a => a.Post).Include(a => a.Species);
            return View(await lostandFoundAnimalsContext.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Post)
                .Include(a => a.Species)
                .SingleOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["PostID"] = new SelectList(_context.Post, "PostID", "LostOrFound");
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "SpeciesID");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalName,AnimalID,Gender,Image,PostID,SpeciesID")] Animal animal, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                //byte[] imageData = null;
                //HttpPostedFileBase postedFileBase = Request.Files["ImageFile"];
                //using(var binary = new System.IO.BinaryReader(postedFileBase.InputStream)){
                //    imageData = binary.ReadBytes(postedFileBase.ContentLength);
                //}
                //animal.Image = imageData;
                //if(image != null){
                //    var fileName = Path.
                //}
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostID"] = new SelectList(_context.Post, "PostID", "LostOrFound", animal.PostID);
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "SpeciesID", animal.SpeciesID);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.SingleOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["PostID"] = new SelectList(_context.Post, "PostID", "LostOrFound", animal.PostID);
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "SpeciesID", animal.SpeciesID);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalName,AnimalID,Gender,Image,PostID,SpeciesID")] Animal animal)
        {
            if (id != animal.AnimalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalID))
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
            ViewData["PostID"] = new SelectList(_context.Post, "PostID", "LostOrFound", animal.PostID);
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "SpeciesID", animal.SpeciesID);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Post)
                .Include(a => a.Species)
                .SingleOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animal.SingleOrDefaultAsync(m => m.AnimalID == id);
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.AnimalID == id);
        }
    }
}
