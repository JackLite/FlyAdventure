using UnityEngine;

namespace Goldstein.Scripts.Utilities
{
    public static class Logger
    {
        public static void LogError(object msg)
        {
            if(Debug.isDebugBuild)
                Debug.LogError(msg.ToString());
        }
        
        public static void Log(object msg)
        {
            if(Debug.isDebugBuild)
                Debug.Log(msg.ToString());
        }
    }
}