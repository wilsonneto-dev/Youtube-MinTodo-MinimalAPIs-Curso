using Microsoft.EntityFrameworkCore;
using MinTodo.Models;

namespace MinTodo;

class MinTodoDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public MinTodoDbContext(DbContextOptions<MinTodoDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.Entity<Todo>(b => b.HasKey(x => x.Id));
}