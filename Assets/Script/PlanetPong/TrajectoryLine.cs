using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    LineRenderer line;

    private void Awake() {
        line = GetComponent<LineRenderer>();
    }

    public void renderLine(Vector3 startPos,Vector3 endPos){
        line.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPos;
        points[1] = endPos;

        line.SetPositions(points);
    }
}
