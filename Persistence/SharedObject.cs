using System.Text.Json.Serialization;
namespace Persistence;
public class SharedObject{
    public string Id { get; set; }
    [JsonIgnore]
    public List<Root> Roots {get; set;} = new();
}
