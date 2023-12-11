using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public enum CannonBallDirection
    {
        Left,
        Right
    }
    CannonBallDirection dir = CannonBallDirection.Left;
    GameplayManager gameplayManager;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        gameplayManager.PlayerLoseLive();
        collision.GetComponent<Player>().DieAndRespawn();

        //destroy actor
    }

}
