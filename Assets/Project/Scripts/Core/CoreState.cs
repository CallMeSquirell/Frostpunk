using System.Threading;
using Cysharp.Threading.Tasks;
using GameStateMachine.Project.Scripts.Modules.GameStateMachine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using Utils.Modules.Utils.Extensions;

namespace Project.Scripts.Core
{
    public class CoreState : IGameState
    {
        private SceneInstance _scene;

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _scene = await Addressables.LoadSceneAsync("Assets/Project/GameAssets/Scenes/CoreScene.unity").ToUniTask(cancellationToken: cancellationToken);
            var context = _scene.Scene.GetSceneContext<CoreStateContext>();
        }

        public void Dispose()
        {
            Addressables.Release(_scene);
        }
    }
}