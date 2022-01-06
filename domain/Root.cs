using System.Collections.Generic;
namespace Domain;
public class Root
{
    private string _name;
    public string Name { get => _name; set { if (value.Length > 7) { throw new Exception(); } else { _name = value; } } }
    public bool IsOkay { get; init;} = false;
    public List<UniqueProperty> UniqueProperties { get; set; } = new();
    public List<SharedObject> SharedObjects { get; set; } = new();
}
