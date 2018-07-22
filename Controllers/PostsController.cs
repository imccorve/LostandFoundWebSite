using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LostandFoundAnimals.Models;

namespace LostandFoundAnimals.Controllers
{
    public class PostsController : Controller
    {
        private readonly LostandFoundAnimalsContext _context;

        public PostsController(LostandFoundAnimalsContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(string searchString)
        {
            searchString = "muuuusssssaaaa";
            ViewData["Message"] = searchString;

            var lostandFoundAnimalsContext = _context.Post.Include(p => p.Address);
            var posts = from s in _context.Post.Include(p => p.Address)
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(s => s.PostText.Contains(searchString));
            }
            return View(await lostandFoundAnimalsContext.ToListAsync());
        }

        public async Task<IActionResult> Lost(string searchString)
        {
            ViewData["Message"] = searchString;
            var posts = from s in _context.Post.Include(p => p.Address)
                           select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    posts = posts.Where(s => s.PostText.Contains(searchString));
            //}
            posts = posts.Where(s => s.LostOrFound == "Found");
            //// Retrieve Genre and its Associated Albums from database
            //var genreModel = this.storeDB.Post
                //.Single(g => g.LostOrFound == lost);
            //var lostandFoundAnimalsContext = _context.Post.Include(p => p.Address);
            //return View(await lostandFoundAnimalsContext.ToListAsync());
            //return View(posts.ToList());
            return View(await posts.ToListAsync());

        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Address)
                .SingleOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "AddressID");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,PostText,AddressID,Date,LostOrFound,Resolved")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "AddressID", post.AddressID);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.SingleOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "AddressID", post.AddressID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostID,PostText,AddressID,Date,LostOrFound,Resolved")] Post post)
        {
            if (id != post.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostID))
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
            ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "AddressID", post.AddressID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Address)
                .SingleOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.SingleOrDefaultAsync(m => m.PostID == id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.PostID == id);
        }
    }
}
