using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameplayManager gameplayManager;
    GameOver gameOver;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
        gameOver = FindObjectOfType<GameOver>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        if (gameplayManager.FoundKeys != gameplayManager.TotalKeys)
            return;

        collision.GetComponent<Player>().GameOverFunction();
    }
}
