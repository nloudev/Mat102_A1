using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrapolateMovement : MonoBehaviour
{
    public float latencyToServer = 0.5f;
    public float timeUntilUpdatingServer = 0.0f;
    public float futureTimeOffset = 1.0f; // Offset to extrapolate into the future

    public Vector3 lastLocalPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeUntilUpdatingServer -= Time.deltaTime;

        if (timeUntilUpdatingServer <= 0f)
        {
            // Extrapolate position into the future
            Vector3 futurePosition = GameObject.Find("Player").transform.position + (GameObject.Find("Player").transform.position - lastLocalPosition) * futureTimeOffset;

            transform.position = futurePosition;
            lastLocalPosition = GameObject.Find("Player").transform.position;

            timeUntilUpdatingServer += latencyToServer;
        }
    }
}
