using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyV2 : MonoBehaviour
{
    Animator myAnimator;
    GameplayManager gameplayManager;
    public AudioClip pickSound;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        gameplayManager = FindObjectOfType<GameplayManager>();

        gameplayManager.TotalKeys++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        AudioSource.PlayClipAtPoint(pickSound, transform.position);
        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), true);
        gameplayManager.FoundKeys++;
        myAnimator.SetBool("Finish", true);
        Destroy(gameObject, .65f);
    }
}
