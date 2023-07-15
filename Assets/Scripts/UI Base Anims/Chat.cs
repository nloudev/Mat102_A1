using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    public float pulseSpeed = 1f;   // Speed at which the image pulses
    public float minScale = 0.8f;   // Minimum scale of the image during the pulse
    public float maxScale = 1.2f;   // Maximum scale of the image during the pulse

    public RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Calculate the pulse scale using the easeInBack function
        float t = Mathf.Sin(Time.time * pulseSpeed) + 1f;                           // Map the sine wave to the range [0, 2] that should be [-1, 1]
        float scale = minScale + (maxScale - minScale) * easeInBack(t * 0.5f);      // Apply easeInBack function

        // Apply the new scale to the image
        rectTransform.localScale = new Vector3(scale, scale, 1f);
    }

    private float easeInBack(float x)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1f;
        return c3 * x * x * x - c1 * x * x;
    }
}
