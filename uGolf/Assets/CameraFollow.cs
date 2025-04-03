using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the golf ball here in the Inspector
    public Vector3 offset; // Adjust for a better view

    void LateUpdate()
    {
        if (target == null) return;

        // Set the camera's position directly to the target's position + offset
        transform.position = target.position + offset;
        // transform.rotation *= Quaternion.Euler(20, 0, 0);
        

        // Optionally, make the camera look at the ball
        transform.LookAt(target);
        transform.rotation *= Quaternion.Euler(-20, 0, 0);
    }
}