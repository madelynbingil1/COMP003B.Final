using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogPageController : Controller
    {
        private readonly AppDbContext _context;

        public BlogPageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BlogPage
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BlogPage.Include(b => b.Categories).Include(b => b.Comments).Include(b => b.Posts).Include(b => b.Tags).Include(b => b.Users);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BlogPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPage = await _context.BlogPage
                .Include(m => m.Categories)
                .Include(m => m.Comments)
                .Include(m => m.Posts)
                .Include(m => m.Tags)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPage == null)
            {
                return NotFound();
            }

            return View(blogPage);
        }

        // GET: BlogPage/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name");
            ViewData["CommentId"] = new SelectList(_context.Comment, "CommentId", "Content");
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "Title");
            ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Name");
            return View();
        }

        // POST: BlogPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,CommentId,PostId,TagId,UserId")] BlogPage blogPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", blogPage.CategoryId);
            ViewData["CommentId"] = new SelectList(_context.Comment, "CommentId", "Content", blogPage.CommentId);
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "Title", blogPage.PostId);
            ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "Name", blogPage.TagId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Name", blogPage.UserId);

            return View(blogPage);
        }

        // GET: BlogPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPage = await _context.BlogPage.FindAsync(id);
            if (blogPage == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", blogPage.CategoryId);
            ViewData["CommentId"] = new SelectList(_context.Comment, "CommentId", "Content", blogPage.CommentId);
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "Title", blogPage.PostId);
            ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "Name", blogPage.TagId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Name", blogPage.UserId);


            return View(blogPage);
        }

        // POST: BlogPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,CommentId,PostId,TagId,UserId")] BlogPage blogPage)
        {
            if (id != blogPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPageExists(blogPage.Id))
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

            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", blogPage.CategoryId);
            ViewData["CommentId"] = new SelectList(_context.Comment, "CommentId", "Content", blogPage.CommentId);
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "Title", blogPage.PostId);
            ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "Name", blogPage.TagId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Name", blogPage.UserId);


            return View(blogPage);
        }

        // GET: BlogPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPage = await _context.BlogPage
                .Include(m => m.Categories)
                .Include(m => m.Comments)
                .Include(m => m.Posts)
                .Include(m => m.Tags)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPage == null)
            {
                return NotFound();
            }

            return View(blogPage);
        }

        // POST: BlogPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPage = await _context.BlogPage.FindAsync(id);
            _context.BlogPage.Remove(blogPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPageExists(int id)
        {
            return _context.BlogPage.Any(e => e.Id == id);
        }
    }
}
