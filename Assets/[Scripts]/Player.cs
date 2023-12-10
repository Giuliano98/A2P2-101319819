using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator MyAnimator;
    GameplayManager gameplayManager;

    [Header("Movement Settings")]
    public float moveSpeed = 1f;
    public float jumpSpeed = 5f;
    float moveDir = 0f;

    public bool onGround = false;
    public bool canJump = true;

    [SerializeField]
    MyInputSystem playerControls;
    InputAction Move;
    InputAction Jump;
    InputAction Dash;

    [Header("Dash Settings")]
    [SerializeField] GameObject DashEffectPrefab;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing = false;
    bool canDash = true;

    [Header("Respawn Settings")]
    public ScreenFade screenFade;
    public Vector3 lastCheckpoint;
    public bool invincibilityFrames = false;

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
        lastCheckpoint = transform.position;
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    void Update()
    {
        if (isDashing)
            return;

        moveDir = Move.ReadValue<float>();

        if (!onGround)
            CheckInAirState();
    }

    void FixedUpdate()
    {
        if (isDashing)
            return;

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

        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    private void DashAction(InputAction.CallbackContext context) 
    {
        if (!canDash)
            return;

        StartCoroutine(Dashing());
        GameObject spawnedPrefab = Instantiate(DashEffectPrefab, transform.position, Quaternion.identity);
        Vector3 tempScale = spawnedPrefab.transform.localScale;
        tempScale.x *= Mathf.Sign(transform.localScale.x);
        spawnedPrefab.transform.localScale = tempScale;
    }

    private IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;
        MyAnimator.SetBool("Dashing", true);

        float tempGrav = rb.gravityScale;
        rb.gravityScale = 0f;

        float tempDir = Mathf.Sign(transform.localScale.x);
        rb.velocity = new Vector2(tempDir * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        MyAnimator.SetBool("Dashing", false);
        rb.gravityScale = tempGrav;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void CheckInAirState()
    {
        float Yaxis = rb.velocity.y;
        MyAnimator.SetFloat("Yaxis", Yaxis);
    }

    public void DieAndRespawn()
    {
        MyAnimator.SetTrigger("Die");
        DisablePlayerButtonAction();
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        screenFade.FadeOut();

        yield return new WaitForSeconds(screenFade.fadeDuration);

        if (gameplayManager.playerLives > 0)
        {
            EnablePlayerButtonAction();
            transform.position = lastCheckpoint;
            screenFade.FadeIn();
        }
        
    }

    public void EnablePlayerButtonAction()
    {
        Move.Enable();
        Jump.Enable();
        Dash.Enable();
    }
    public void DisablePlayerButtonAction()
    {
        Move.Disable();
        Jump.Disable();
        Dash.Disable();
    }
}
