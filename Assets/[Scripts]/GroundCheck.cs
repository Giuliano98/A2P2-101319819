using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player playerScript;

    private void Start()
    {
        playerScript = transform.parent.gameObject.GetComponent<Player>();
        Debug.Log(playerScript);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript.canJump = true;
    }
}
