using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float moveDuration = 1f;     // Duration of the movement in seconds
    public float moveHeight = 5f;       // Height to move up

    private Vector2 startPosition;
    private Vector2 targetPosition;

    public float delayOffset = 0f;      // Delay offset for each object
    private float timer;
    private float delayTimer;

    private void Start()
    {
        // Store the initial position
        startPosition = transform.position;

        // Calculate the target position
        targetPosition = startPosition + new Vector2(0f, moveHeight);

        // Start the delay timer with the offset
        delayTimer = delayOffset;
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the delay is over
        if (timer >= delayTimer)
        {
            // Calculate the interpolation factor using the easeInQuad function and ping-pong behavior
            float t = easeInQuad(Mathf.PingPong((timer - delayTimer) / moveDuration, 1f));

            // Interpolate the position
            Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, t);

            // Update the object's position
            transform.position = newPosition;
        }

        /*
         
        TODO: When player gets hit, UI goes AHH

        if (hp goes down) // get set? if old count is lower than current
        {
            // Reuse the shining logic in Mana.cs
            // Heart[index] setActive.False - relative to hp
            // Heart[index] setActive.False - relative to hp
        }

         */
    }

    private float easeInQuad(float x)
    {
        return x * x;
    }
}
