using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image image;
    public MonoBehaviour scriptToEnable;

    public bool scriptEnabled = false;

    public float elapsedTime = 0f;
    private Color targetColor;
    private Color initialColor;

    public float fadeDuration = 1f; // The duration of the fade-in effect

    public float delayOffset = 0f;      // Delay offset for each object
    private float timer;
    private float delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial color of the image
        initialColor = image.color;

        // Set the target color
        targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);

        // Set the image's color to the initial color
        image.color = initialColor;

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

            // Calculate the current alpha value based on the elapsed time and fade duration
            float alpha = Mathf.Lerp(initialColor.a, targetColor.a, elapsedTime / fadeDuration);

            // Set the new color with the calculated alpha value
            image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);

            if (elapsedTime >= fadeDuration && !scriptEnabled)
            {
                enabled = false;
                scriptToEnable.enabled = true;
                scriptEnabled = true;
            }
        }
    }
}
