using System;
using UnityEditor;
using UnityEngine;
using Logger = Goldstein.Scripts.Utilities.Logger;

namespace Goldstein.Core.Lines
{
    [CreateAssetMenu(menuName = "Settings/Lines", fileName = "LinesSettings", order = 0)]
    public class LineSettings : ScriptableObject
    {
        public Vector2[] linesStart;
        
        private void OnEnable()
        {
            Logger.Log("Enable");
        }

        private void OnDisable()
        {
            Logger.Log("disables");
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            Debug.DrawLine(linesStart[0] + Vector2.left * 500, linesStart[0] + Vector2.right * 500, Color.cyan);
        }
        #endif
    }
}