using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player playerScript;

    private void Start()
    {
        playerScript = transform.parent.gameObject.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript.onGround = true;
        playerScript.canJump = true;
        playerScript.MyAnimator.SetFloat("Yaxis", 0f);
        playerScript.MyAnimator.SetBool("Ground", true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerScript.onGround = false;
    }
}
