using Commands.Project.Scripts.Modules.Commands.Core.Impl;
using Project.GameAssets.Commands;
using UnityEngine;
using Zenject;

namespace Project.GameAssets
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private SceneContext _sceneContext;
        
        private void Start()
        {
            var container = _sceneContext.Container;
            var 
            container.Resolve<CommandExecutor>().Execute<IGoLocationCommand>(ApplicationContext.Token);
        }
    }
}