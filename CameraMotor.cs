using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    // Reference to the object that the camera should follow
    public Transform lookAt;

    // Boundaries for camera movement on the X and Y axes
    public float boundX = 0.015f;
    public float boundY = 0.05f;

    // LateUpdate is called after all Update functions have been called
    private void LateUpdate()
    {
        // Delta represents the change in position for the camera
        Vector3 delta = Vector3.zero;

        // Calculate the difference between the camera's X position and the target's X position
        float deltaX = (lookAt.position.x) - (transform.position.x);

        // Check if the difference exceeds the X boundary
        if (deltaX > boundX || deltaX < -boundX)
        {
            // Adjust the camera's X position based on its relationship to the target
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // Calculate the difference between the camera's Y position and the target's Y position
        float deltaY = lookAt.position.y - transform.position.y;

        // Check if the difference exceeds the Y boundary
        if (deltaY > boundY || deltaY < -boundY)
        {
            // Adjust the camera's Y position based on its relationship to the target
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        // Update the camera's position with the calculated delta values
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
