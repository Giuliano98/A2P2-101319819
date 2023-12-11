using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float verticalDistance = 3f;

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            if (transform.position.y < startPosition.y + verticalDistance)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (transform.position.y > startPosition.y)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
            else
            {
                movingUp = true;
            }
        }
    }
}
