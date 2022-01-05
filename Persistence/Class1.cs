using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class Root{
    public int RootId {get;set;}
    public string Name{get;set;}
    public bool IsOkay { get;set;}
    public List<UniqueProperty> UniqueProperties { get; set; } = new();
    public List<SharedObject> SharedObjects { get; set; } = new();
}
public class UniqueProperty{
    public string Id { get; set; }
}
public class SharedObject{
    public string Id { get; set; }
    public List<Root> Roots {get; set;} = new();
}
public class ApplicationContext : DbContext{
    public DbSet<Root> Roots { get; set; } = default!;
    public DbSet<UniqueProperty> UniqueProperties { get;set;} = default!;
    public DbSet<SharedObject> SharedObjects { get;set;} = default!;
    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlite("Data Source=persistence.db");
    }
}
