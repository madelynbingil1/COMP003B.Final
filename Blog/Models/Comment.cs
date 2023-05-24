using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}