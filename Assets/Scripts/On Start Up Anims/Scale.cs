using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    public Vector3 initialScale = Vector3.zero;
    public Vector3 targetScale = Vector3.one;
    public float duration = 1f;

    private float currentTime = 0f;

    public float delayOffset = 0f;      // Delay offset for each object
    private float timer;
    private float delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Start the delay timer with the offset
        delayTimer = delayOffset;
    }

    void Awake()
    {
        // Set the initial scale to zero
        transform.localScale = initialScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the delay is over
        if (timer >= delayTimer)
        {
            // Increase the current time based on the elapsed time
            currentTime += Time.deltaTime;

            // Calculate the current scale based on the current time and duration
            float t = Mathf.Clamp01(currentTime / duration);
            float ease = EaseInOutElastic(t);
            Vector3 currentScale = Vector3.Lerp(initialScale, targetScale, ease);

            // Apply the current scale to the UI image
            transform.localScale = currentScale;
        }
    }

    private float EaseInOutElastic(float x)
    {
        const float c5 = (2f * Mathf.PI) / 4.5f;

        return x == 0f
            ? 0f
            : x == 1f
            ? 1f
            : x < 0.5f
                ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
                : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }
}
