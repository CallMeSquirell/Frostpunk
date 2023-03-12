using System.Linq;
using System.Threading;
using Commands.Project.Scripts.Modules.Commands.BaseCommands;
using Cysharp.Threading.Tasks;
using Utils.Project.Scripts.Modules.Utils.Extensions;
using Zenject;

namespace Project.GameAssets.Commands
{
    public interface IGoLocationCommand : IExecutableCommand<ILocationModel>
    {
    }

    public class GoLocationCommand : Command, IGoLocationCommand
    {
        private readonly ILocationContext _locationContext;

        public GoLocationCommand(ILocationContext locationContext)
        {
            _locationContext = locationContext;
        }
        
        public async UniTask Execute(ILocationModel payload, CancellationToken cancellationToken = default)
        {
            var scene = await payload.SceneAsset.LoadSceneAsync();
            var sceneContext = scene.Scene.GetRootGameObjects().Select(go => go.GetComponent<SceneContext>()).FirstOrDefault(go => go.NonNull());
            if (sceneContext.NonNull())
            {
                var locationContext = sceneContext.Container.Resolve<ILocationContext>();
                locationContext.Model = payload;
            }
        }
    }
}