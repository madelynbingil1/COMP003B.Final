using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPageApiController : Controller
    {
        private List<BlogPage> _blogpages = new List<BlogPage>();

        public BlogPageApiController()
        {
            _blogpages.Add(new BlogPage { Id = 1, CategoryId = 1, CommentId = 1, PostId = 1, TagId = 1, UserId = 1});
            _blogpages.Add(new BlogPage { Id = 2, CategoryId = 2, CommentId = 2, PostId = 2, TagId = 2, UserId = 2});

            _blogpages.Add(new BlogPage { Id = 3, CategoryId = 3, CommentId = 3, PostId = 3, TagId = 3, UserId = 3});

            _blogpages.Add(new BlogPage { Id = 4, CategoryId = 4, CommentId = 4, PostId = 4, TagId = 4, UserId = 4});

            _blogpages.Add(new BlogPage { Id = 5, CategoryId = 5, CommentId = 5, PostId = 5, TagId = 5, UserId = 5});
        }

        // read

        [HttpGet]
        public ActionResult<IEnumerable<BlogPage>> GetAllBlogPages()
        {
            return _blogpages;
        }

        // Read
        [HttpGet("{id}")]
        public ActionResult<BlogPage> GetBlogPageById (int id)
        {
            var blogPage = _blogpages.Find(b => b.Id == id);

            if (blogPage == null)
            {
                return NotFound();
            }

            return blogPage;
        }

        // Create
        [HttpPost]
        public ActionResult<BlogPage> CreateBlogPage(BlogPage blogPage)
        {
            blogPage.Id = _blogpages.Max(b => b.Id) + 1;
            _blogpages.Add(blogPage);

            return CreatedAtAction(nameof(GetBlogPageById), new Object{ id = blogPage.Id}, blogPage);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateBlogPage(int id, BlogPage updatedBlogPage)
        {
            var blogPage = _blogpages.Find(b => b.Id == id);

            if (blogPage == null)
            {
                return BadRequest();
            }

            blogPage.CategoryId = updatedBlogPage.CategoryId;
            blogPage.CommentId = updatedBlogPage.CommentId;
            blogPage.PostId = updatedBlogPage.PostId;
            blogPage.TagId = updatedBlogPage.TagId;
            blogPage.UserId = updatedBlogPage.UserId;

            return NoContent();
        }

        // Delete

        [HttpDelete]
        public IActionResult DeleteBlogPage(int id)
        {
            var blogPage = _blogpages.Find(b => b.Id == id);
            if (blogPage == null)
            {
                return NotFound();
            }

            _blogpages.Remove(blogPage);

            return NoContent();
        }
    }
}