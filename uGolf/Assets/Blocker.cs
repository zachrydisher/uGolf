using UnityEngine;

public class Blocker : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 direction = Vector3.left;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plank"){
            direction = -direction;
        }
    }
}
