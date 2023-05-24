using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }

        public virtual ICollection<BlogPage> BlogPages { get; set; }
    }
}