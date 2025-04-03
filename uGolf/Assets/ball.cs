using UnityEngine;

public class ball : MonoBehaviour
{

    private PhysicsMaterial physMaterial;
    private Rigidbody rigidBody;
    private Terrain terrain;
    public float speed;
    public float drag;
    public bool isShooting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessShot();
    }

    void ProcessShot(){
        if(Input.GetMouseButtonDown(0)){
            isShooting = true;
            Shoot(speed);
        }
    }

    void Shoot(float speed){
        // rigidBody.AddForce(transform.forward * -speed);
        float launchAngle = 45f; // Angle in degrees
        Vector3 shotDirection = Quaternion.Euler(launchAngle, 0, 0) * transform.forward;
    
        rigidBody.AddForce(shotDirection * speed, ForceMode.Impulse); // Apply instant force

    }

    void OnCollisionEnter(Collision collision)
    {
        if(isShooting){
            rigidBody.linearDamping = 0.6f;
            rigidBody.angularDamping = 1.5f;
        }
    }
}
