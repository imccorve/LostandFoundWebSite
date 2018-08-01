using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LostandFoundAnimals.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.ObjectModel;

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
        public  IActionResult Index(int? id)
        //public async Task<IActionResult> Index(int? id)
        {
            //searchString = "muuuusssssaaaa";
            //ViewData["Message"] = searchString;
            // .Include is eager loading
            var viewModel = new PostIndexData();
            viewModel.Posts = _context.Post
                .Include(i => i.Address)
                .Include(i => i.Animal)
                .Include(i => i.Animal.Species);
            //.Include(i => i.Animal.Breeds);
            //viewModel.Breeds = _context.Breed;
            if (id != null)
            {
                ViewBag.PostID = id.Value;
                viewModel.Animal = viewModel.Posts.Where(i => i.PostID == id.Value).Single().Animal;
                //viewModel.Species = viewModel.Posts.Where(i => i.PostID == id.Value).Single().Animal.Species;
                //viewModel.Breeds = _context.Breed;
                //viewModel.Breeds = viewModel.Posts.Where(i => i.PostID == id.Value).Single().Animal.Breeds;
                viewModel.Breeds = from s in _context.Breed.Where(i => i.AnimalID == viewModel.Animal.AnimalID) select s;
                viewModel.Address = viewModel.Posts.Where(i => i.PostID == id.Value).Single().Address;
            }
            return View(viewModel);
            //var lostandFoundAnimalsContext = _context.Post.Include(p => p.Address);
            //var posts = from s in _context.Post.Include(p => p.Address)
            //            select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    posts = posts.Where(s => s.PostText.Contains(searchString));
            //}
            //return View(await lostandFoundAnimalsContext.ToListAsync());
        }

        public async Task<IActionResult> Lost()
        {
            var posts = from s in _context.Post.Include(p => p.Address)
                           select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    posts = posts.Where(s => s.PostText.Contains(searchString));
            //}
            posts = posts.Where(s => s.LostOrFound == "Lost");
            //// Retrieve Genre and its Associated Albums from database
            //var genreModel = this.storeDB.Post
                //.Single(g => g.LostOrFound == lost);
            //var lostandFoundAnimalsContext = _context.Post.Include(p => p.Address);
            //return View(await lostandFoundAnimalsContext.ToListAsync());
            //return View(posts.ToList());
            return View(await posts.ToListAsync());

        }

        public async Task<IActionResult> Found()
        {
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
            //var post = new Post();
            //post.Animal = new Animal();
            //post.Animal.Breeds = new List<Breed>();
            //post.Address = new Address();
            //ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "AddressID");
            //return View();

            var model = new PostViewModel();

            model.SpeciesList = _context.Species.ToList();
            //ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "SpeciesID");

            //viewModel.Posts = _context.Post
                //.Include(i => i.Address)
                //.Include(i => i.Animal);
            return View(model);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PostText,Date,LostOrFound,Resolved")] Post post)
        public IActionResult Create(PostViewModel model)
        {
            var item = new Post();
            item = model.Post;
            item.Address = model.Address;
            item.Animal = model.Animal;

            var breed1 = new Breed();
            breed1 = model.Breed1;

            _context.Post.Add(item);
            _context.SaveChanges();

            //model.Breeds = new Collection<Breed>();

            //breed1.AnimalID = model.Animal.AnimalID;
            breed1.AnimalID = _context.Animal.OrderByDescending(p => p.AnimalID)
                .FirstOrDefault().AnimalID;
            //item.Animal.Breeds.Add(breed1);

            //var breed2 = new Breed();
            //breed2 = model.Breed2;
            //item.Animal.Breeds = model.Breeds;
            //ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "SpeciesID", model.Animal.SpeciesID);

            _context.Breed.Add(breed1);
            _context.SaveChanges();


            return RedirectToAction("Create");
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
