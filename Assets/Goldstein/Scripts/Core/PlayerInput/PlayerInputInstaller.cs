using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.PlayerInput
{
    public class PlayerInputInstaller : AbstractSystemInstaller
    {
        private EcsWorld _world;
        [SerializeField] private Camera leftCam;
        [SerializeField] private Camera rightCam;
#if UNITY_EDITOR
        [SerializeField] private Mode _mode;
#else
        private Mode _mode = Mode.Touch;
#endif
        
        public override void RegisterSystems(EcsWorld world, EcsSystems systems)
        {
            if (_mode == Mode.Keyboard)
                systems.Add(new KeyboardInputSystem());
            else
                systems.Add(new TouchscreenInputSystem(Camera.main, leftCam, rightCam));
        }

        private enum Mode
        {
            Keyboard,
            Touch
        }
    }
}