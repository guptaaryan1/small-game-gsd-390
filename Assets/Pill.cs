using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pill : MonoBehaviour
{
    private PillManager pillManager; // Reference to the PillManager
    private Rigidbody rb; // Rigidbody to apply physics to the pill

    void Start()
    {
        // Find the PillManager in the scene
        pillManager = GameObject.FindObjectOfType<PillManager>();
        if (pillManager == null)
        {
            Debug.LogError("PillManager not found in the scene!");
        }

        // Get the Rigidbody to ensure it can be affected by gravity
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the pill object!");
        }
    }

    // Detect collision with the LosingPill plane
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as LosingPill
        if (other.CompareTag("LosingPlane"))
        {
            // Reduce the pill count and destroy the pill
            pillManager.ReducePillCount(gameObject);

            // Destroy this pill object
            Destroy(gameObject);
        }
    }
}

