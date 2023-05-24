using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; }

       public virtual ICollection<BlogPage> BlogPages { get; set; }
    }
}