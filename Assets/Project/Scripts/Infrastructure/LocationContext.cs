using Project.GameAssets.Commands;

namespace Project.GameAssets
{
    public interface ILocationContext
    {
        ILocationModel Model { get; set; }
    }
    
    public class LocationContext : ILocationContext
    {
        public ILocationModel Model { get; set; }
    }
}