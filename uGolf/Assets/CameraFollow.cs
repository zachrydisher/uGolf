using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    public float followSpeed = 5f;
    public float rotationSpeed = 50f;
    public float lookAtHeight = 5.3f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - ball.position;
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            offset = Quaternion.AngleAxis(-rotationSpeed * Time.deltaTime, Vector3.up) * offset;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            offset = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up) * offset;
        }

        Vector3 desiredPosition = ball.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        Vector3 lookAtTarget = new Vector3(ball.position.x, lookAtHeight, ball.position.z);
        transform.LookAt(lookAtTarget);
    }
}
