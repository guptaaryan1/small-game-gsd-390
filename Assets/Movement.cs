using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    [SerializeField]
    public float jumpForce = 5f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get input from A/D keys
        float verticalInput = Input.GetAxis("Vertical"); // Get input from W/S keys

        // Calculate movement based on input
        Vector3 movement = new Vector3(-verticalInput, 0f, horizontalInput); 
        movement = transform.TransformDirection(movement); // Apply movement in local space 
        movement *= speed * Time.deltaTime; // Scale movement by speed and time

        // Move the object
        transform.position += movement;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply upward force for jump
        }
    }
}