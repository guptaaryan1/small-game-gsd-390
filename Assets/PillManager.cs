using System.Collections.Generic;
using UnityEngine;

public class PillManager : MonoBehaviour
{
    public GameObject pillPrefab; // The pill prefab to instantiate
    public int pillCount = 1; // Initial pill count (starts with 1)
    private List<GameObject> pills = new List<GameObject>(); // List to hold the spawned pills
    private GameObject player; // Reference to the Player object
    private float spacing = 1f; // Distance between pills in a grid layout

    void Start()
    {
        // Find the player object
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player object not found in the scene. Make sure the Player tag is assigned.");
            return;
        }

        // Spawn the initial pills around the player's position
        SpawnPillsAroundPlayer();
    }

    // Spawn pills around the player's position in a tight grid
    private void SpawnPillsAroundPlayer()
    {
        // Destroy any existing pills
        foreach (var pill in pills)
        {
            Destroy(pill);
        }
        pills.Clear();

        // Get the player's position
        Vector3 centerPosition = player.transform.position;

        // Calculate the grid size
        int gridSide = Mathf.CeilToInt(Mathf.Sqrt(pillCount));
        int pillsSpawned = 0;

        // Spawn pills in a grid layout around the player
        for (int row = 0; row < gridSide; row++)
        {
            for (int col = 0; col < gridSide; col++)
            {
                if (pillsSpawned >= pillCount) break;

                // Adjust the spawn position to make sure the grid is centered around the player
                Vector3 spawnPosition = centerPosition + new Vector3((row - gridSide / 2) * spacing, 0, (col - gridSide / 2) * spacing);
                GameObject newPill = Instantiate(pillPrefab, spawnPosition, Quaternion.identity);
                MaintainUprightPill(newPill);
                pills.Add(newPill);
                pillsSpawned++;
            }
        }
    }

    // Apply a gate effect to the pills
    public void ApplyGateEffect(Transform gateTransform, int operation, int randomValue)
    {
        switch (operation)
        {
            case 0: // Multiply
                MultiplyPills(randomValue);
                break;
            case 1: // Divide
                DividePills(randomValue);
                break;
            case 2: // Add
                AddPills(randomValue);
                break;
            case 3: // Subtract
                SubtractPills(randomValue);
                break;
        }

        // Respawn the updated pills around the player
        SpawnPillsAroundPlayer();
    }

    private void MultiplyPills(int multiplier)
    {
        pillCount *= multiplier;
    }

    private void DividePills(int divisor)
    {
        pillCount = Mathf.Max(1, pillCount / divisor); // Ensure at least one pill remains
    }

    private void AddPills(int count)
    {
        pillCount += count;
    }

    private void SubtractPills(int count)
    {
        pillCount = Mathf.Max(1, pillCount - count); // Ensure at least one pill remains
    }

    // Ensure pills stay upright while still being affected by gravity
    private void MaintainUprightPill(GameObject pill)
    {
        Rigidbody rb = pill.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Prevent rotation along X and Z axes (keep pill upright)
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    // Detect when a pill falls onto the LosingPill plane
    public void ReducePillCount(GameObject pill)
    {
        // Reduce the pill count by 1, but ensure it doesn't go below 0
        pillCount = Mathf.Max(0, pillCount - 1);
        pills.Remove(pill); // Remove the pill from the list
        Destroy(pill); // Destroy the pill
        Debug.Log("Pill lost! Current count: " + pillCount);
    }
}
