using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void WinGame()
    {
        gameEnded = true;
        winScreen.SetActive(true);
    }

    public void LoseGame()
    {
        gameEnded = true;
        loseScreen.SetActive(true);
    }
}
