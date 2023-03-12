using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace Project.Scripts.Core.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private Camera _camera;
        private EcsFilter<Selected> _selected;
        private EcsFilter<Selectable> _selectable;

        public void Run()
        {
            if (Input.touchCount == 0)
            {
                Clear();
                return;
            }

            foreach (var index in _selectable)
            {
                ref var entity = ref _selectable.GetEntity(index);
                var selected = entity.Has<Selected>();
                var touch = selected ? Input.GetTouch(entity.Get<Selected>().TouchId) : Input.touches.First();
                var plane = entity.Get<Selectable>().Plane;
                var ray = _camera.ScreenPointToRay(touch.position);
                
                if (!plane.Raycast(ray, out var enter)) continue;
                
                var point = ray.GetPoint(enter);

                if (!selected)
                {
                    entity.Replace(new SelectedDown(point));
                }

                entity.Replace(new Selected(point, touch.fingerId));
            }
        }

        private void Clear()
        {
            foreach (var index in _selected)
            {
                ref var entity = ref _selectable.GetEntity(index);

                entity.Replace(new SelectedUp(entity.Get<Selected>().Position));
                entity.Del<Selected>();
            }
        }
    }
}