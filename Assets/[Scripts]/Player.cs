using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float jumpSpeed = 5f;

    public MyInputSystem playerControls;
    InputAction Move;
    InputAction Jump;
    InputAction Dash;

    public Animator MyAnimator;

    float moveDir = 0f;

    public bool onGround = false;
    public bool canJump = true;
    public bool isFalling = true;
    //public bool inAirCheck = false;

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
        if (!onGround)
            CheckInAirState();
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
        if (!canJump)
            return;
        canJump = false;
        MyAnimator.SetBool("Jumping", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        MyAnimator.SetBool("Jumping", false);
        //Debug.Log("Jump!");
    }

    private void DashAction(InputAction.CallbackContext context) 
    {
        Debug.Log("Dash!");    
    }

    void CheckInAirState()
    {
        float Yaxis = rb.velocity.y;

        isFalling = Mathf.Sign(Yaxis) < Mathf.Epsilon;

        MyAnimator.SetBool("Falling", isFalling);
        MyAnimator.SetFloat("Yaxis", Yaxis);

    }

}
