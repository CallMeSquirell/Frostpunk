using Project.Scripts.Core;
using Zenject;

namespace Project.GameAssets.Core
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EcsManager>().AsSingle();
        }
    }
}