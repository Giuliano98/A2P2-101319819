using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonBall : MonoBehaviour
{
    public enum CannonBallDirection
    {
        Left,
        Right
    }

    GameplayManager gameplayManager;
    public float speed = 5f;

    private Vector2 moveDirection = Vector2.right;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
        Destroy(gameObject, 3f);
    }
    public void SetDirection(Cannon.CannonDirection direction)
    {
        moveDirection = (direction == Cannon.CannonDirection.Right) ? Vector2.right : Vector2.left;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        if (collision.GetComponent<Player>().invincibilityFrames)
            return;

        Destroy(gameObject);
        gameplayManager.PlayerLoseLive();
        collision.GetComponent<Player>().DieAndRespawn();
    }

}
