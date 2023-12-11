using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallWeakPoint : MonoBehaviour
{
    public float launchForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);

        Destroy(transform.parent.gameObject);
    }
}
