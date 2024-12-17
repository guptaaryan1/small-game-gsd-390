using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow (the pill in your case)
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector3 offset = new Vector3(0f, -5f, -10f); // Adjusted to a reasonable offset for third-person perspective

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("No target assigned for CameraFollow script. Please assign a target.");
        }
    }

    void Update()
    {
        transform.position = target.transform.position + new Vector3(10, 10, 0);
    }
}
