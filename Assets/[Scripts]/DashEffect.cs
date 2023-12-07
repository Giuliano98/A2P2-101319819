using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    public float fadeDuration = 2f; // Time in seconds for fading out
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, fadeDuration);
    }

    void Update()
    {
        Color color = spriteRenderer.color;
        color.a -= Time.deltaTime / fadeDuration;
        spriteRenderer.color = color;
    }
}
