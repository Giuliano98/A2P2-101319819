using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public enum CannonDirection
    {
        Left,
        Right
    }

    Animator myAnimator;

    public CannonDirection direction = CannonDirection.Right; 
    public float maxDistance = 10f; 

    public float reloadCooldown = 3f;
    bool isReloading = false;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isReloading && CanSeePlayer())
            Shoot();
    }

    void Shoot()
    {
        // Implement your shooting logic here
        Debug.Log("Shoot!!");
        myAnimator.SetTrigger("Shoot");

        isReloading = true;
        Invoke("ReloadCannon", reloadCooldown);
    }

    void ReloadCannon()
    {
        isReloading = false;
    }

    bool CanSeePlayer()
    {
        Vector2 rayDirection = (direction == CannonDirection.Right) ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, maxDistance);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
            return true;
        return false;
    }
}
