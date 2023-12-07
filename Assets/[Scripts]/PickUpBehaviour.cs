using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public enum PickUpType
{
    Key,
    Diamond
}

public class PickUpBehaviour : MonoBehaviour
{
    Animator MyAnimator;
    [SerializeField] PickUpType pickUpType = PickUpType.Key;
    [SerializeField] float fadeTime = 1f;
    SpriteRenderer spriteRenderer;
    bool flag = false;

    private void Start()
    {
        MyAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (pickUpType == PickUpType.Key) 
            MyAnimator.Play("Anim_KeyIdle");
        else if (pickUpType == PickUpType.Diamond)
            MyAnimator.Play("Anim_DiamondIdle");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        GetComponent<Collider2D>().enabled = false;
        OnPickUp();

        flag = true;

        if (pickUpType == PickUpType.Key)
            MyAnimator.Play("Anim_KeyFinish");
        else if (pickUpType == PickUpType.Diamond)
            MyAnimator.Play("Anim_DiamondFinish");

        Destroy(gameObject, fadeTime);
    }

    void Update()
    {
        if (!flag)
            return;

        Color color = spriteRenderer.color;
        color.a -= Time.deltaTime / fadeTime;
        spriteRenderer.color = color;
    }

    protected virtual void OnPickUp() { }
}
