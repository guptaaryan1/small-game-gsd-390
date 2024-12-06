using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinningBlock"))
        {
            gameManager.WinGame();
        }
        else if (collision.gameObject.CompareTag("LosingPlane"))
        {
            gameManager.LoseGame();
        }
    }
}

