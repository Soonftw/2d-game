using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private BoxCollider2D boxCol;

    [Header("Ground collision")]
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private int maxJumps = 1;

    private enum MovementState { idle, running, jumping, falling, double_jumping, wall_jumping }
    private MovementState state = MovementState.idle;

    [Header("Audio")]
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource doubleJumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Move();

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            Jump();
        }
        else if(Input.GetButtonDown("Jump") && extraJumps > 0){
            extraJumps --;
            DoubleJump();
        }

        UpdateAnimationState();
        

        if(IsGrounded()){
            extraJumps = maxJumps;
        }

    }

    private void Move(){
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if(dirX > 0){
            spriteRend.flipX = false;
        }
        else if (dirX < 0){
            spriteRend.flipX = true;
        }

    }

    private void Jump(){
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void DoubleJump(){
        doubleJumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    
    private void UpdateAnimationState(){
        
        if (dirX > 0f){
            state = MovementState.running;
        }
        else if (dirX < 0f){
            state = MovementState.running;
        }
        else{
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f && extraJumps == 0){
            state = MovementState.double_jumping;
        }

        else if (rb.velocity.y > .1f){
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f){
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}