using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateInitialPosition : MonoBehaviour
{
    public float timeToEase = 5.0f;

    public enum EasingType
    {
        LINEAR,
        SQUARED,
        CUBED,
        EXPO_100,
        EASE_OUT_ELASTIC
    }
    public EasingType easingType = EasingType.LINEAR;

    void Update()
    {
        float x = Time.time / timeToEase;
        float y = 0f;
        float z = 0f;
        z = Exponential(x, 3);

        switch (easingType)
        {
            case EasingType.LINEAR:
                y = Linear(x);
                break;
            case EasingType.SQUARED:
                y = Exponential(x, 2);
                break;
            case EasingType.CUBED:
                y = Exponential(x, 3);

                break;
            case EasingType.EXPO_100:
                y = Exponential(x, 100);
                break;
            case EasingType.EASE_OUT_ELASTIC:
                y = EaseOutElastic(x);
                break;
        }

        transform.localPosition = new Vector3(y, 0f, z);
    }

    float Linear(float time)
    {
        if (time > 1.0f) return 1.0f;
        return time;
    }

    float Exponential(float time, float exponent)
    {
        if (time > 1.0f) return 1.0f;
        return Mathf.Pow(time, exponent);
    }

    float EaseOutElastic(float x)
    {
        float c4 = (2 * Mathf.PI) / 3;

        return x == 0
            ? 0
            : x == 1
            ? 1
            : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }
}
