// TaskContext.cs
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ef_trello.Model 
{
    public class TaskContext : DbContext
    {
        public DbSet<Todo> Tasks { get; set; }
        public string DbPath { get; }

        public TaskContext()
        {
            DbPath = "bin/Todo.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Tasks");
        }
    }
}
