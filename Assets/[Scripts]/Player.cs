using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1f;

    public MyInputSystem playerControls;

    InputAction Move;
    InputAction Jump;
    InputAction Dash;

    Animator MyAnimator;

    float moveDir = 0f;

    bool canJump = true;

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
        Jump.performed += JumpAction;

        Dash = playerControls.MyController.Dash;
        Dash.Enable();
        Dash.performed += DashAction;
    }

    void OnDisable()
    {
        Move.Disable();
        Jump.Disable();
        Dash.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        moveDir = Move.ReadValue<float>();
    }
    void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);
        bool isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        FlipSprite(isMoving);
        MyAnimator.SetBool("Running", isMoving);
    }

    void FlipSprite(bool moving)
    {
        if (!moving)
            return;

        transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
    }

    void JumpAction(InputAction.CallbackContext context)
    {
        Debug.Log("Jump!");
        canJump = false;
    }

    private void DashAction(InputAction.CallbackContext context) 
    {
        Debug.Log("Dash!");    
    }
}
