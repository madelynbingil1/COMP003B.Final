using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }
    }
}