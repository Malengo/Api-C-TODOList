using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<CategoryEntity> categories { get; set; }
        public DbSet<ListEntity> lists { get; set; }
        public DbSet<TaskEntity> tasks { get; set; }
        public DbSet<UserEntity> users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<TaskEntity>(new TaskMap().Configure);
            modelBuilder.Entity<ListEntity>(new ListMap().Configure);
            modelBuilder.Entity<CategoryEntity>(new CategoryMap().Configure); 
        }
    }
}
