using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalMovement : MonoBehaviour
{
    public float power = 10f;
    Rigidbody2D rigidbody;

    TrajectoryLine trajectoryLine;

    Camera camera;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    float distance;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        trajectoryLine = GetComponent<TrajectoryLine>();
    }

    private void Start() {
        camera = Camera.main;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            rigidbody.velocity = Vector3.zero;

            startPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 0;
        }

        if(Input.GetMouseButton(0)){
            Vector3 currentPos = camera.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 0;

            trajectoryLine.renderLine(startPoint,currentPos);
        }

        if(Input.GetMouseButtonUp(0)){
            endPoint = camera.ScreenToWorldPoint(Input.mousePosition);      
            endPoint.z = 0;

            // force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x,minPower.x,maxPower.x),Mathf.Clamp(startPoint.y - endPoint.y,minPower.y,maxPower.y));
            force = (startPoint - endPoint).normalized;

            distance = Vector2.Distance(startPoint,endPoint);

            rigidbody.AddForce(force * distance,ForceMode2D.Impulse);
        }
    }
}
