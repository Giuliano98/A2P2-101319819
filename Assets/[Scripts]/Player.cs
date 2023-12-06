using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1f;

    public MyInputSystem playerControls;

    private InputAction Move;
    private InputAction Jump;
    private InputAction Dash;

    private float moveDir = 0f;

    void Awake()
    {
        playerControls = new MyInputSystem();
    }

    void OnEnable()
    {
        Move = playerControls.MyController.Movement;
        Move.Enable();
        Jump = playerControls.MyController.Jump;
        Jump.Enable();
        Dash = playerControls.MyController.Dash;
        Dash.Enable();
    }

    void OnDisable()
    {
        Move.Disable();
        Jump.Disable();
        Dash.Disable();
    }

    void Start()
    {

    }


    void Update()
    {
        moveDir = Move.ReadValue<float>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (moveDir * moveSpeed, rb.velocity.y);
    }
}
