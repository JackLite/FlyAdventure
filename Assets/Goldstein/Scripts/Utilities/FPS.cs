using UnityEngine;

class FPS : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 300;
    }
}