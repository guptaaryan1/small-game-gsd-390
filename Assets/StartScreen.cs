using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreen; // Reference to the UI Canvas or Text

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Disable the start screen
            startScreen.SetActive(false);
        }
    }
}

