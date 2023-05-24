using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class BlogPage
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
