using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlideIntoPlace : MonoBehaviour
{
    public RectTransform imageTransform;
    public MonoBehaviour scriptToEnable;

    public bool scriptEnabled = false;

    public Vector2 targetPosition;
    public float slideDuration = 1f; // The duration of the fall-in effect

    private Vector2 initialPosition;
    public float elapsedTime = 0f;

    public enum EasingType
    {
        EaseOutBounce,
        EaseInExpo,
        EaseInBack,
        EaseInOutBack,
        EaseOutElastic
    }

    public EasingType easingType = EasingType.EaseOutBounce;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the image
        initialPosition = imageTransform.anchoredPosition;

        // Set the image's position to the initial position
        imageTransform.anchoredPosition = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Calculate the current progress based on the elapsed time and fall duration
        float progress = Mathf.Clamp01(elapsedTime / slideDuration);

        // Apply the easing function to the progress value
        float easedProgress;

        switch (easingType)
        {
            case EasingType.EaseOutBounce:
                easedProgress = EaseOutBounce(progress);
                break;
            case EasingType.EaseInExpo:
                easedProgress = EaseInExpo(progress);
                break;
            case EasingType.EaseInBack: 
                easedProgress = EaseInBack(progress);
                break;
            case EasingType.EaseInOutBack:
                easedProgress = EaseInOutBack(progress);
                break;
            case EasingType.EaseOutElastic:
                easedProgress = EaseOutElastic(progress);
                break;
            default:
                easedProgress = EaseOutBounce(progress); // Default to EaseOutBounce
                break;
        }

        // Calculate the new position using a simple linear interpolation between initial and target positions
        Vector2 newPosition = Vector2.Lerp(initialPosition, targetPosition, easedProgress);

        // Set the image's position to the new position
        imageTransform.anchoredPosition = newPosition;

        if (elapsedTime >= slideDuration && !scriptEnabled)
        {
            enabled = false;
            scriptToEnable.enabled = true;
            scriptEnabled = true;
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

    private float EaseInExpo(float x)
    {
        return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
    }

    private float EaseInBack(float x)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        return c3 * x * x * x - c1 * x * x;
    }

    private float EaseInOutBack(float x)
    {
        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;

        return x < 0.5
          ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
          : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }

    private float EaseOutElastic(float x)
    {
        const float c4 = (2 * Mathf.PI) / 3;

        return x == 0
          ? 0
          : x == 1
          ? 1
          : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10f - 0.75f) * c4) + 1;
    }
}
