using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Persistence;
public class ApplicationContext : DbContext{
    public DbSet<Root> Roots { get; set; } = default!;
    public DbSet<UniqueProperty> UniqueProperties { get;set;} = default!;
    public DbSet<SharedObject> SharedObjects { get;set;} = default!;
    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlite("Data Source=persistence.db");
    }
}
