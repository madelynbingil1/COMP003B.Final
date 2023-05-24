using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Blog.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<BlogPage> BlogPages { get; set; }
    }
}