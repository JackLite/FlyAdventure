using UnityEngine;
using UnityEngine.UI;

namespace Goldstein.Scripts.Utilities
{
    [RequireComponent(typeof(Text))]
    public sealed class FpsVisualizer : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            /*if(!Debug.isDebugBuild) DestroyImmediate(gameObject);*/
        }

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            var fps = (int)(1.0f / Time.deltaTime);
            _text.text = $"FPS:{fps}";
        }
    }
}