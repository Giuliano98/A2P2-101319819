using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallWeakPoint : MonoBehaviour
{
    GameplayManager gameplayManager;
    public float launchForce = 5f;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);

        gameplayManager.EnemiesDefeated++;

        Destroy(transform.parent.gameObject);
    }
}
