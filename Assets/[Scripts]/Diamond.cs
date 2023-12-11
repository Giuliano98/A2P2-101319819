using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    Animator myAnimator;
    GameplayManager gameplayManager;

    void Start()
    {
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
            Destroy(gameObject);


        myAnimator = GetComponent<Animator>();
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), true);
        gameplayManager.FoundDiamonds++;
        myAnimator.SetBool("Finish", true);
        Destroy(gameObject, .7f);
    }
}
