using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject debugMovement;

    public float speed = 5f;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        debugMovement = GameObject.Find("DebugMovement");
    }

    private void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        direction.x = Input.GetAxisRaw("Horizontal"); // -1, 0, 1 = left, no input, right
        direction.y = Input.GetAxisRaw("Vertical"); // -1, 0, 1 = down, no input, up

        direction = Vector3.ClampMagnitude(direction, 1); // to fix diagonal speed, max length = 1

        transform.position += direction * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Toggle enable or disable the DebugMovement object
            debugMovement.SetActive(!debugMovement.activeSelf);
        }
    }
}
