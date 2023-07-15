using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMovement : MonoBehaviour
{
    public float latencyToServer = 0.5f;
    public float timeUntilUpdatingNetwork = 0.0f;

    public Vector3 lastLocalPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeUntilUpdatingNetwork -= Time.deltaTime;

        if (timeUntilUpdatingNetwork <= 0f)
        {
            transform.position = lastLocalPosition;
            lastLocalPosition = GameObject.Find("ServerMovement (Green)").transform.position;
            transform.position = lastLocalPosition;

            timeUntilUpdatingNetwork += latencyToServer;
        }
    }
}
