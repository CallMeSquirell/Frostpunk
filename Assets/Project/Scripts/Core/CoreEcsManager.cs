using Project.Scripts.Core.Systems;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class CoreEcsManager : EcsManager
    {
        protected override void Prepare()
        {
            CreateSystem().Add(new InputSystem())
                .OneFrame<SelectedDown>()
                .OneFrame<SelectedUp>()
                .Inject(Camera.main);
        }
    }
}