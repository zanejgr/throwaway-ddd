using System.Collections.Generic;
namespace domain;
public class Root
{
    private string _name;
    public string Name { get => _name; set { if (value.Length > 7) { throw new Exception(); } else { _name = value; } } }
    public bool IsOkay { get; init; } = false;
    public List<UniqueProperty> UniqueProperties { get; init; } = new();
    public List<SharedObject> SharedObjects { get; init; } = new();
}
public class UniqueProperty{
    public string Id { get; init; }
}
public class SharedObject{
    public string Id { get; set; }
    public List<Root> Roots { get; init; } = new();
}
