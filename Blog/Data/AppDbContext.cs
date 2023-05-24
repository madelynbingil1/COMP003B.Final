using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog.Models.Category> Category { get; set; }

        public DbSet<Blog.Models.Comment> Comment { get; set; }

        public DbSet<Blog.Models.Post> Post { get; set; }

        public DbSet<Blog.Models.User> User { get; set; }

        public DbSet<Blog.Models.Tag> Tag { get; set; }
    }
