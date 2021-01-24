using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{

    public float moveSpeed;
    public Vector3[] cameraPoints;
    public int pointsIndex;


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, cameraPoints[pointsIndex], moveSpeed * Time.deltaTime);

        if (transform.position == cameraPoints[pointsIndex])
        {
            //Next point of the array of Locations
            pointsIndex++;
        }

        if (pointsIndex == (cameraPoints.Length))
        {
            //Going Back to the start point
            pointsIndex = 0;
        }
    }
}
