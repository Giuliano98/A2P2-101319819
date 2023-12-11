using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsePlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 initialPosition;

    public float resetTime = 3f;
    public float delayBeforeFalling = 0.8f;

    private bool playerTouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerTouching)
        {
            playerTouching = true;
            StartCoroutine(DelayBeforeFalling());
        }
    }

    IEnumerator DelayBeforeFalling()
    {
        yield return new WaitForSeconds(delayBeforeFalling);

        rb.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(resetTime - delayBeforeFalling);

        ResetPlatform();
    }

    private void ResetPlatform()
    {
        rb.bodyType = RigidbodyType2D.Static; 
        rb.velocity = Vector2.zero; 
        transform.position = initialPosition;
        playerTouching = false;
    }
}
