using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraHelper : MonoBehaviour
{
    public Camera leftCamera;
    public Camera rightCamera;

    private Camera mainCamera;

    public static CameraHelper instance;
    void Awake()
    {
        instance = this;
        mainCamera = GetComponent<Camera>();

    }
    
    public Vector3 CalculateDiffWithLeftCamera()
    {
        return leftCamera.transform.position - mainCamera.transform.position;
    }

    public Vector3 CalculateDiffWithRightCamera()
    {
        return rightCamera.transform.position - mainCamera.transform.position;
    }
}
