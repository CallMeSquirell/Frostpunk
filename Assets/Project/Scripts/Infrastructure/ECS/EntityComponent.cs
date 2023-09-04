using Leopotam.Ecs;
using UnityEngine;

namespace Project.Scripts.Core.Features.Minions.Components
{
    public interface IEntityComponent
    {
        void Produce(ref EcsEntity entity);
    }

    public abstract class EntityComponent<T> : MonoBehaviour, IEntityComponent where T : struct
    {
        [SerializeField]
        private T _value;

        public void Produce(ref EcsEntity entity)
        {
            entity.Replace(_value);
        }
    }
}