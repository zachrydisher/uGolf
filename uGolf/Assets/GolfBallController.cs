using System;
using UnityEngine;

public class GolfBallController : MonoBehaviour
{
    [Header("Force Settings")]
    public float maxForce = 200;
    public float maxDistance = 10f;

    [Header("References")]
    public Ball ball;
    public LayerMask ballLayerMask;

    private LineRenderer lineRenderer;
    private bool isAiming = false;
    private bool isOutsideBall = false;
    private Vector3 aimPoint;
    public LevelManager levelManager;
    private bool shotTaken = false;
    private bool ballWasMoving = false;


    void Start()
    {
        lineRenderer = ball.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (ball.IsBallMoving()){
            if (shotTaken){ //only updates after a shot has been taken
                ballWasMoving = true; //set so that strokes left is decremented after the ball has been hit
                return;
            }
        } 

        if (!ball.IsBallMoving() && shotTaken && ballWasMoving)
        {
            levelManager.strokesLeft--;
            levelManager.SetStrokesLeft(levelManager.strokesLeft);
            shotTaken = false;
            ballWasMoving = false;
        }

        ball.lastPosition = ball.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, ballLayerMask))
            {
                isAiming = true;
                isOutsideBall = false;
                lineRenderer.enabled = true;
            }
        }

        if (Input.GetMouseButton(0) && isAiming)
        {
            aimPoint = GetMouseWorldPoint();
            float distanceFromBall = Vector3.Distance(ball.transform.position, aimPoint);
            float forceFactor = Mathf.Clamp01(distanceFromBall / maxDistance);
            Color lineColor = Color.Lerp(Color.green, Color.red, forceFactor);

            ball.SetLineGradient(lineColor);

            if (distanceFromBall > ball.ballRadius)
            {
                isOutsideBall = true;
                Vector3 direction = (aimPoint - ball.transform.position).normalized;
                lineRenderer.SetPosition(0, ball.transform.position);
                lineRenderer.SetPosition(1, ball.transform.position + direction * Mathf.Clamp(distanceFromBall, 0, maxDistance));
            }
            else
            {
                isOutsideBall = false;
                lineRenderer.SetPosition(0, ball.transform.position);
                lineRenderer.SetPosition(1, ball.transform.position);
            }
        }

        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            if (isOutsideBall)
            {
                Vector3 direction = (aimPoint - ball.transform.position).normalized;
                float distance = Vector3.Distance(ball.transform.position, aimPoint);
                float force = Mathf.Clamp01(distance / maxDistance) * maxForce;

                ball.Shoot(direction, force);
                shotTaken = true;
            }

            isAiming = false;
            isOutsideBall = false;
            lineRenderer.enabled = false;
        }
    }

    Vector3 GetMouseWorldPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, ball.transform.position);
        if (groundPlane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }
        return ball.transform.position;
    }
}
