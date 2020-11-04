using System.Collections.Generic;
using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Scripts.Global
{
    public class MenuInstaller : MonoBehaviour
    {
        [SerializeField] private List<AbstractSystemInstaller> installers;

        private bool _wasCreate;
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            CreateEcs();
        }

        private void CreateEcs()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            foreach (var installer in installers) installer.RegisterSystems(_world, _systems);
            _systems.Init();            
        }
        

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            foreach (var installer in installers) installer.Dispose();
            _systems.Destroy();
            _world.Destroy();
        }
    }
}