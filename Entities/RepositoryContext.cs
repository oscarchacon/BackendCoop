using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskWork> TaskWorks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskWork>()
                        .Property(taskWork => taskWork.CreateDate)
                        .HasDefaultValue(DateTime.UtcNow);

            base.OnModelCreating(modelBuilder);
        }
    }
}
