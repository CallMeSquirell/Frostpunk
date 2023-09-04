using GameStateMachine.Project.Scripts.Modules.GameStateMachine;
using Zenject;

namespace Project.GameAssets
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<GameStateMachineInstaller>();
        }
    }
}