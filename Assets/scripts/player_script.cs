using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float speed = 5.0f;

    private void Update()
    {
        // Get the current mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Make sure the Z-coordinate is appropriate for 2D

        // Clamp the X position of the mouse within the specified range
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);

        // Move the game object towards the clamped X position
        Vector3 targetPosition = new Vector3(clampedX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
