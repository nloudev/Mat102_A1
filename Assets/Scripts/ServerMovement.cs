using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMovement : MonoBehaviour
{
    public float latencyToServer = 0.5f;
    public float timeUntilUpdatingServer = 0.0f;

    public Vector3 lastLocalPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilUpdatingServer -= Time.deltaTime;

        if(timeUntilUpdatingServer <= 0f )
        {
            transform.position = lastLocalPosition;
            lastLocalPosition = GameObject.Find("Player").transform.position;
            transform.position = lastLocalPosition;

            timeUntilUpdatingServer += latencyToServer;
        }
    }
}
