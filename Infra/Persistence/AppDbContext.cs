using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TaskToDo = Domain.Models.TaskToDo;
using Domain.Models;

namespace Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskToDo> Tasks => Set<TaskToDo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskToDo>(entity =>
            {

                entity.HasKey(t => t.Id);

                entity.Property(t => t.Title)   // ✅ CORRECT
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(t => t.Description)
                    .HasMaxLength(1000);

                entity.OwnsOne(t => t.Status, owned =>
                {
                    owned.Property(s => s.Value)
                        .IsRequired()
                        .HasMaxLength(50);
                });
            });
        }
    }
}

