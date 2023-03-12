using UnityEngine.AddressableAssets;

namespace Project.GameAssets.Commands
{
    public interface ILocationModel
    {
        AssetReference SceneAsset { get; }
    }

    public class LocationModel : ILocationModel
    {
        public AssetReference SceneAsset { get; }
        
        public LocationModel(LocationConfig config)
        {
            SceneAsset = config.Scene;
        }
    }
}