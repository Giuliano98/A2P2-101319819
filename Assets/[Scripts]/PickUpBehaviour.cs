using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PickUpType
{
    Key,
    Diamond
}

public class PickUpBehaviour : MonoBehaviour
{
    public Animator MyAnimator;
    public PickUpType pickUpType = PickUpType.Key;

    private void Awake()
    {
        MyAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        switch (pickUpType)
        {
            case PickUpType.Key:
                MyAnimator.Play("Anim_KeyIdle");
                break;
            case PickUpType.Diamond:
                MyAnimator.Play("Anim_DiamonIdle");
                break;
            default:
                break;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        OnPickUp();
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(DestroyAfterDelay(2f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        switch (pickUpType)
        {
            case PickUpType.Key:
                MyAnimator.Play("Anim_KeyFinish");
                break;
            case PickUpType.Diamond:
                MyAnimator.Play("Anim_DiamonFinish");
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    protected virtual void OnPickUp() { }
}
