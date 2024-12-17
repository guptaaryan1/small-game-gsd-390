using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public static GameManager Instance;
    public int pillCount = 1;

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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ModifyPillCount(int newCount)
    {
        pillCount = Mathf.Max(1, newCount); // Ensure at least one pill remains
        Debug.Log($"Pill Count: {pillCount}");
    }
}
