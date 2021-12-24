using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Rigidbody ref
    private Rigidbody2D rb;
    // animator ref
    private Animator ani;
    // Sprite red, will be used to turn the direction of character
    private SpriteRenderer sprite;
    // Box collidor. Used in jumping mechanics
    private BoxCollider2D coll;

    // setting [SerializeField] before variables I want to be able to edit in unity editor - Amazing!
    // initialise movement 
    private float xVel = 0f;
    // movement speed
    [SerializeField] private float moveSpeed = 7f;
    // jump height
    [SerializeField] private float jumpH = 14f;
    // varible of type layer, which is created in terrain 
    [SerializeField] private LayerMask jumpableGround;

    // Making an enum to cater to all movement states // 0 , 1 , 2 , 3  which are used in animator editor
    private enum MovementState { idle, running, jumping, falling }

    // Audio variable
    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    private void Start()
    {
        // making an instance of GetComponent upon first load so we don't need to load it on ever frame (save on resources)
        rb = GetComponent<Rigidbody2D>(); 
        // Instance of animator
        ani = GetComponent<Animator>();    
        // insntance of sprite
        sprite = GetComponent<SpriteRenderer>();
        // instance of box collidor 
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // this controls the characters left and right movement, inc/dec x , GetAxisRaw will stop character slide
        xVel = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVel * moveSpeed, rb.velocity.y);

        // GetButtonDown uses the 'input manager' key stroke detections, saves on hard coding
        // This will also call the IsGrounded method as part of the conditions, stops character from jumping more than once
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // Adding jump capabilities 
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
            // Calling play method on jumpSound every jump
            jumpSound.Play();
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // making local variable of type MovementState
        MovementState state;

        // change running to idle - animations
        if (xVel > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(xVel < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // Checking if character is jumping
        if (rb.velocity.y >.01f)
        {
            state = MovementState.jumping;
        }
        // Checking if character is falling
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        // stat now assigned correctly, parse the enum as the corresponding int - Use it in the unity animator
        ani.SetInteger("state", (int)state);
    }

    // Box Cast, creates a box around the player which will overlap with other objects, gives detection of touching/impact
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
