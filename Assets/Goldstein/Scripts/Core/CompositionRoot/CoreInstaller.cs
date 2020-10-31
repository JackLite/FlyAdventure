using System.Collections.Generic;
using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.CompositionRoot
{
    public class CoreInstaller : MonoBehaviour
    {
        [SerializeField] private List<AbstractSystemInstaller> installers;
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            CoreStart();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            CoreEnd();
        }

        public void Restart()
        {
            CoreEnd();
            CoreStart();
        }

        private void CoreStart()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            foreach (var installer in installers) installer.RegisterSystems(_world, _systems);
            _systems.Init();
            Time.timeScale = 1;
        }

        private void CoreEnd()
        {
            foreach (var installer in installers) installer.Dispose();
            _systems.Destroy();
            _world.Destroy();
        }
    }
}