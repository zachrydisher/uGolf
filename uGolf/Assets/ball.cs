using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class Ball : MonoBehaviour
{
    public float ballRadius = 0.3f;
    private Rigidbody rb;
    private LineRenderer lineRenderer;
    private bool hasWon = false;
    public Vector3 lastPosition;
    public int levelNum;
    public LevelManager levelManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        levelNum = SceneManager.GetActiveScene().buildIndex;
    }

    public bool IsBallMoving()
    {
        return rb.linearVelocity.magnitude > 0.05f || rb.angularVelocity.magnitude > 0.05f;
    }

    public void Shoot(Vector3 direction, float force)
    {
        rb.AddForce(direction * force);
        levelManager.PlayGolfHit();
    }

    public void SetLineGradient(Color lineColor)
    {
        Gradient dynamicGradient = new Gradient();
        dynamicGradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(lineColor, 0f),
                new GradientColorKey(lineColor, 1f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0f),
                new GradientAlphaKey(1f, 1f)
            }
        );
        lineRenderer.colorGradient = dynamicGradient;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup") && !hasWon)
        {
            hasWon = true;
            levelManager.WinHole();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Level" + levelNum + "Bounds")){
            StartCoroutine(ResetAfterDelay());
        }
    }

    public IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        //resets velocity so the reset doesnt have residual force
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = lastPosition;

    }
}
