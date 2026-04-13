using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float MouseSensitivity = 1000f;

    private float _rotationX;
    
    private void Awake()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
}
