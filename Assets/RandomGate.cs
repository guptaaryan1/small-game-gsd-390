using UnityEngine;
using TMPro;

public class RandomGate : MonoBehaviour
{
    public PillManager pillManager; // Reference to the PillManager
    public TextMeshPro effectText; // TextMeshPro to display the gate's effect
    private int randomValue;
    private int operation;
    private string effectSymbol; // Holds the operation text, e.g., "+5", "x3"

    void Start()
    {
        if (effectText == null)
        {
            effectText = GetComponentInChildren<TextMeshPro>();
        }

        GenerateRandomEffect();
        DisplayEffect();
    }

    // Generate a random effect
    private void GenerateRandomEffect()
    {
        operation = Random.Range(0, 4); // Random between 0 (Multiply) to 3 (Subtract)
        randomValue = Random.Range(1, 11); // Random value between 1 and 10

        switch (operation)
        {
            case 0: effectSymbol = "x" + randomValue; break; // Multiply
            case 1: effectSymbol = "/" + randomValue; break; // Divide
            case 2: effectSymbol = "+" + randomValue; break; // Add
            case 3: effectSymbol = "-" + randomValue; break; // Subtract
        }
    }

    // Display the effect on the gate
    private void DisplayEffect()
    {
        if (effectText != null)
        {
            effectText.text = effectSymbol;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pillManager.ApplyGateEffect(transform, operation, randomValue);
            GenerateRandomEffect(); // Refresh the gate effect after being triggered
            DisplayEffect();
        }
    }
}
