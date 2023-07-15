using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
    public Transform player;                    // Reference to the player's transform

    // Variables for position and velocity updates
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private Vector3 velocity;

    // Variables for dead reckoning
    public float updateInterval = 1f;           // Time between updates (in seconds)
    public float interpolationDelay = 0.5f;     // Delay for interpolation (in seconds)
    private float interpolationTimer = 0f;

    public bool extrapolate = false;            // Flag to enable extrapolation

    // Start is called before the first frame update
    private void Start()
    {
        // Initialise lastPosition and currentPosition
        lastPosition = player.position;
        currentPosition = player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // Perform dead reckoning interpolation
        interpolationTimer += Time.deltaTime;

        if (interpolationTimer >= interpolationDelay)
        {
            // Update position and velocity
            lastPosition = currentPosition;
            currentPosition = player.position;
            velocity = (currentPosition - lastPosition) / interpolationDelay;

            // Reset interpolation timer
            interpolationTimer = 0f;
        }

        if (extrapolate)
        {
            Vector3 futurePosition = player.position + velocity * (interpolationDelay + Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, futurePosition, Time.deltaTime * 10f); // Use Lerp for smooth extrapolation
        }
        else
        {
            // Move the object based on dead reckoned position and velocity
            transform.position += velocity * Time.deltaTime;
        }
    }
}
