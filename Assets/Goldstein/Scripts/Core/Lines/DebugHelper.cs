using UnityEngine;

namespace Goldstein.Core.Lines
{
    [ExecuteInEditMode]
    public class DebugHelper : MonoBehaviour
    {
        [SerializeField] private LineSettings lineSettings;
        [SerializeField] private int lineLength;

        private void Update()
        {
            foreach (var lineStartPoint in lineSettings.linesStart)
            {
                Debug.DrawLine(
                    lineStartPoint + Vector2.left * lineLength,
                    lineStartPoint + Vector2.right * lineLength,
                    Color.cyan
                );

                Debug.DrawLine(
                    lineStartPoint + Vector2.up * lineLength,
                    lineStartPoint + Vector2.down * lineLength,
                    Color.cyan
                );
            }
        }
    }
}