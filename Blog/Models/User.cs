using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}