using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using Project.Scripts.Core.Systems;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Core
{
    public class EcsManager : ITickable, IDisposable, IInitializable
    {
        private EcsWorld _world;
        private List<EcsSystems> _systems;

        public void Initialize()
        {
            _world = new EcsWorld();
            CreateSystems();
            foreach (var system in _systems)
            {
                system.ProcessInjects().Init();
            }
            
            
#if UNITY_EDITOR
            EcsWorldObserver.Create(_world);
            foreach (var system in _systems)
            {
                EcsSystemsObserver.Create(system);
            }
#endif
        }

        private void CreateSystems()
        {
            _systems.Add(CreateInputSystems());
        }

        private EcsSystems CreateInputSystems()
        {
            return new EcsSystems(_world)
                .Add(new InputSystem())
                .OneFrame<SelectedDown>()
                .OneFrame<SelectedUp>()
                .Inject(Camera.main);
        }

        public void Tick()
        {
            foreach (var system in _systems)
            {
                system.Run();
            }
        }

        public void Dispose()
        {
            foreach (var system in _systems)
            {
                system.Destroy();
            }
            _systems.Clear();
            _world.Destroy();
            _world = null;
        }
    }
}