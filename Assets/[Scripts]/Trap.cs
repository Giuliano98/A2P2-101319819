using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    GameplayManager gameplayManager;
    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        if (collision.GetComponent<Player>().invincibilityFrames)
            return;

        collision.GetComponent<Player>().DieAndRespawn();
        gameplayManager.PlayerLoseLive();
    }
}
