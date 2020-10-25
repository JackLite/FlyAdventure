using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Scripts.Utilities
{
    public abstract class AbstractSystemInstaller : MonoBehaviour, IDisposable
    {
        public abstract void RegisterSystems(EcsWorld world, EcsSystems ecsSystems);
        public virtual void Dispose() {}
    }
}