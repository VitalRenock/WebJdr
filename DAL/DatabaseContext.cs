using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebJdr.Models;

namespace WebJdr.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
		public DbSet<Story> Stories { get; set; }
		public DbSet<Sequence> Sequences { get; set; }
		public DbSet<Choice> Choices { get; set; }
	}
}