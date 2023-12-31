using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public int TotalKeys = 0;
    public int FoundKeys = 0;
    public int FoundDiamonds = 0;
    public int EnemiesDefeated = 0;
    public int playerLives = 3;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void PlayerLoseLive()
    {
        playerLives--;

        if (playerLives == 0) 
        {
            // Gameover UI
            player.DisablePlayerButtonAction();
        }
    }
}
