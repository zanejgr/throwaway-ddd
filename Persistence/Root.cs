namespace Persistence;
public class Root{
    public int RootId {get;set;}
    public string Name{get;set;}
    public bool IsOkay { get;set;}
    public List<UniqueProperty> UniqueProperties { get; set; } = new();
    public List<SharedObject> SharedObjects { get; set; } = new();
}
