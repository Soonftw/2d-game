using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX;

    [SerializeField] private int jumpForce = 5;
    [SerializeField] private int moveSpeed = 5;


    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D boxCol;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void UpdateAnimationState(){
        if (dirX > 0){
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if(dirX < 0){
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else {
            anim.SetBool("Running", false);
        }
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
