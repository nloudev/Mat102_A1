using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallIntoPlace : MonoBehaviour
{
    public RectTransform imageTransform;
    public Vector2 targetPosition;
    public float fallDuration = 1f; // The duration of the fall-in effect

    private Vector2 initialPosition;
    private float elapsedTime = 0f;

    public float delayOffset = 0f;      // Delay offset for each object
    private float timer;
    private float delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the image
        initialPosition = imageTransform.anchoredPosition;

        // Set the image's position to the initial position
        imageTransform.anchoredPosition = initialPosition;

        // Start the delay timer with the offset
        delayTimer = delayOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the delay is over
        if (timer >= delayTimer)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the current progress based on the elapsed time and fall duration
            float progress = Mathf.Clamp01(elapsedTime / fallDuration);

            // Apply the easing function to the progress value
            float easedProgress = EaseOutBounce(progress); ;

            // Calculate the new position using a simple linear interpolation between initial and target positions
            Vector2 newPosition = Vector2.Lerp(initialPosition, targetPosition, easedProgress);

            // Set the image's position to the new position
            imageTransform.anchoredPosition = newPosition;
        }
    }

    private float EaseOutBounce(float x)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (x < 1f / d1)
        {
            return n1 * x * x;
        }
        else if (x < 2f / d1)
        {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        else if (x < 2.5f / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        else
        {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }
}
