using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Image image;
    public float shineSpeed = 5f;
    public float shineIntensity = 0.15f;

    private float shineTimer = 0f;
    private Color originalColor;

    public float delayOffset = 0f;      // Delay offset for each object
    private float timer;
    private float delayTimer;

    private void Start()
    {
        // Store the original color of the image
        originalColor = image.color;

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
            // Increment the shine timer based on the shine speed
            shineTimer += Time.deltaTime * shineSpeed;

            // Calculate the shine factor using the sine function
            float shineFactor = Mathf.Sin(shineTimer) * shineIntensity;

            // Apply the shine factor to the image color
            Color newColor = originalColor + new Color(shineFactor, shineFactor, shineFactor, 0f);

            // Update the image color
            image.color = newColor;
        }
    }
}
