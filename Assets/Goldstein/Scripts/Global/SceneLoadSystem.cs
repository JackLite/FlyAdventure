using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Goldstein.Scripts.Global
{
    public sealed class SceneLoadSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SceneLoadEvent> _filter;
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() == 0)
                return;
            ref var sceneLoadEvent = ref _filter.Get1(0);

            SceneManager.LoadScene(sceneLoadEvent.sceneName);
        }
    }
}