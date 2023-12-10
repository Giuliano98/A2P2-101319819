using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyV2 : MonoBehaviour
{
    Animator playerAnimator;
    GameplayManager gameplayManager;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        gameplayManager = FindObjectOfType<GameplayManager>();

        gameplayManager.TotalKeys++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), true);
        gameplayManager.FoundKeys++;
        playerAnimator.SetBool("Finish", true);
        Destroy(gameObject, .65f);
    }
}
