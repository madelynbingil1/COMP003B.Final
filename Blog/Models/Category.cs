using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<BlogPage> BlogPages { get; set; }
    }
}