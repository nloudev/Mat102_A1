using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 125f;

    private void Update()
    {
        // Calculate the interpolation factor using the easeInOutExpo function
        float t = easeInOutExpo(Time.time);

        // Calculate the new rotation
        Quaternion newRotation = Quaternion.Euler(0f, rotationSpeed * t * Time.deltaTime, 0f) * transform.rotation;

        // Apply the new rotation
        transform.rotation = newRotation;
    }

    private float easeInOutExpo(float x)
    {
        if (x == 0f)
            return 0f;
        else if (x == 1f)
            return 1f;
        else if (x < 0.5f)
            return Mathf.Pow(2f, 20f * x - 10f) / 2f;
        else
            return (2f - Mathf.Pow(2f, -20f * x + 10f)) / 2f;
    }
}
